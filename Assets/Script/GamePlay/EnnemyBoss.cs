using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyBoss : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float Health;
    float lastAttackTime = 0;
    float attackCooldown = 2;

    [SerializeField] float stoppingDistance;

    public NavMeshAgent Agent;
    public Transform Player;
    [SerializeField] public GameObject XROrigin;

    Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        stoppingDistance = Agent.stoppingDistance;

        Player = GameObject.Find("Main Camera").transform;
        XROrigin = GameObject.Find("XR Origin");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, Player.transform.position);

        if (dist < stoppingDistance)
        {
            StopEnemy();
            Attack();
        } else
        {
            GoToTarget();
        }
    }

    private void GoToTarget()
    {
        Agent.isStopped = false;
        Agent.SetDestination(Player.position);
        Anim.SetBool("isWalking", true);
        Anim.SetBool("isAttacking", false);
    }

    private void StopEnemy()
    {
        Agent.isStopped = true;
        Anim.SetBool("isWalking", false);
    }

    private void Attack()
    {
        if(Time.time - lastAttackTime >= attackCooldown)
        {
            Anim.SetBool("isAttacking", true);
            lastAttackTime = Time.time;
            XROrigin.GetComponent<Player>().TakeDamage(1);
        }
    }
    public void TakeDamage(int value)
    {
        Health -= value;
        if (Health <= 0)
        {
            StopEnemy();
            Anim.SetBool("isDead", true);
            AppSceneManager.instance.GoToMenu();
        }
        Anim.SetBool("isTakingDamage", true);

        Debug.Log("TookDamage " + Health);
        //Anim.SetBool("isTakingDamage", false);
        // Damages au monstre
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision.gameObject.tag " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(1);
        }

    }
}