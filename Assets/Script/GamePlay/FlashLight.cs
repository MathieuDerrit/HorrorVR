using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class FlashLight : HandSelected
{
    [SerializeField]
    private InputActionProperty _PrimaryLeftBtn;
    [SerializeField]
    private InputActionProperty _PrimaryRightBtn;

    [SerializeField]
    private Light _SpotLight;

    [SerializeField]
    private GameObject _Keys;

    [SerializeField]
    private float _SphereRadius;

    [SerializeField]
    private float _MaxDistance;

    [SerializeField]
    private LayerMask _LayerMask;

    private Vector3 _Direction;
    private float _CurrentHitDistance;
    private Vector3 _CurrentHitPosition;

    private GameObject _BoxCollider;


    public Mesh _Sphere;

    public GameObject Key;
    void Start()
    {
    }

    protected override void UpdateChild()
    {
        if (_SpotLight.enabled)
        {
            if (_BoxCollider == null)
            {
                CreateSphere();
            }
            _Direction = transform.forward;
            RaycastHit hit;
            Ray ray = new Ray(transform.position, _Direction);

            if (Physics.Raycast(ray, out hit, _MaxDistance, _LayerMask))
            {
                //_BoxCollider.GetComponent<DetectChestKey>().DisableOutline();
                
                _Keys = hit.transform.gameObject;
                _CurrentHitDistance = hit.distance;
                _CurrentHitPosition = hit.point;

                SetSphereCollider();
            }
            else
            {
                _CurrentHitDistance = _MaxDistance;
                _Keys = null;
            }
        }
        else
        {
            if (_BoxCollider != null)
            {
                DetectChestKey._Key.GetComponent<Outline>().enabled = false;
                Destroy(_BoxCollider);
            }
            
        }
        

    }

    private void OnDrawGizmosSelected()
    {
        Debug.DrawLine(transform.position, transform.position + _Direction * _CurrentHitDistance, Color.red);
    }

    protected override void OnLeftHandGrap()
    {
        if (_PrimaryLeftBtn.action.WasPressedThisFrame())
        {
            if (!_SpotLight.enabled)
            {
                _SpotLight.enabled = true;
            }
            else
            {
                _SpotLight.enabled = false;
            }
        }
    }

    protected override void OnRightHandGrap()
    {
        if (_PrimaryRightBtn.action.WasPressedThisFrame())
        {
            if (!_SpotLight.enabled)
            {
                _SpotLight.enabled = true;
            }
            else
            {
                _SpotLight.enabled = false;
            }
        }
    }

    private float ClampRadius(float distance)
    {
        return distance * 0.5f / 10f;
    }

    private float ClampRadiusSphereRender(float distance)
    {
        return distance * 4.5f / 10f;
    }

    private void SetSphereCollider()
    {
        _BoxCollider.transform.SetPositionAndRotation(_CurrentHitPosition, Quaternion.identity);
        _BoxCollider.transform.localScale = new Vector3(ClampRadiusSphereRender(_CurrentHitDistance), ClampRadiusSphereRender(_CurrentHitDistance), ClampRadiusSphereRender(_CurrentHitDistance));

        //SphereColliderGO.radius = ClampRadius(_CurrentHitDistance);
    }

    private void CreateSphere()
    {
        _BoxCollider = new GameObject("Cool GameObject made from Code");
        _BoxCollider.transform.SetPositionAndRotation(_CurrentHitPosition, Quaternion.identity);
        SphereCollider SphereColliderGO = _BoxCollider.AddComponent<SphereCollider>();
        MeshFilter MeshFilterGO = _BoxCollider.AddComponent<MeshFilter>();
        //MeshFilterGO.mesh = _Sphere;
        MeshRenderer MeshRendererGO = _BoxCollider.AddComponent<MeshRenderer>();
        _BoxCollider.AddComponent<DetectChestKey>();
        SphereColliderGO.isTrigger = true;
    }
}