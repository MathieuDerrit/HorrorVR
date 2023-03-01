using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float health;
    float lastAttackTime = 0;
    float attackCooldown = 2;

    [SerializeField] float stoppingDistance;

    public NavMeshAgent Agent;
    public Transform Player;

    Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        stoppingDistance = Agent.stoppingDistance;
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

        if (health == 0)
        {
            Agent.isStopped = true;
            Anim.SetBool("isDead", true);
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

        }
    }

    public void TakeDamage()
    {
        Anim.SetBool("isTakingDamage", true);

        // Damages au monstre
    }
}
