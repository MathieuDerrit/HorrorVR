using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : HandSelected
{

    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;


    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [SerializeField] private InputActionProperty _Fire1;
    [SerializeField] private InputActionProperty _Fire2;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")][SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")][SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")][SerializeField] private float ejectPower = 150f;

    public GameObject startRayGO;


    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
    }

    protected override void UpdateChild()
    {

    }


    //This function creates the bullet behavior
    void Shoot()
    {
        if (muzzleFlashPrefab)
        {
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //cancels if there's no bullet prefeb
        /*if (!bulletPrefab)
        { return; }

        // Create a bullet and add force on it in direction of the barrel
        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);*/
        Fire();

        if (GetComponent<PlaySound>() != null)
        {
            GetComponent<PlaySound>().playSound();
        }
        Debug.DrawRay(startRayGO.transform.position, startRayGO.transform.forward * 20, Color.red);

    }

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }

    protected override void OnLeftHandGrap()
    {
        if (_Fire1.action.WasPressedThisFrame())
        {
            gunAnimator.SetTrigger("Fire");
        }
    }

    protected override void OnRightHandGrap()
    {
        if (_Fire2.action.WasPressedThisFrame())
        {
            gunAnimator.SetTrigger("Fire");
        }
    }

    void Fire()
    {

        RaycastHit hit;
        Ray ray = new Ray(startRayGO.transform.position, startRayGO.transform.forward);

        int layer_mask = LayerMask.GetMask("Default");

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //pt.transform.position = hit.point;

            if (hit.transform.gameObject.tag == "Monster")
            {
                hit.transform.gameObject.GetComponent<EnnemyBoss>().TakeDamage(10);
            }
        }
    }
}
