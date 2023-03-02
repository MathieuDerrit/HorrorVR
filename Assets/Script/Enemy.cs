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

    [SerializeField] Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        if(Agent != null)
        {
            stoppingDistance = Agent.stoppingDistance;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            float dist = Vector3.Distance(transform.position, Player.transform.position);

            if (dist < stoppingDistance)
            {
                StopEnemy();
                Attack();
            }
            else
            {
                GoToTarget();
            }
        }     
    }

    private void GoToTarget()
    {
        if(Player != null)
        {
            Agent.isStopped = false;
            Agent.SetDestination(Player.position);
            Anim.SetBool("isWalking", true);
            Anim.SetBool("isAttacking", false);
        }
      
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

    public void TakeDamage(int value)
    {
        health = -value;
        if(health>= 0)
        {
            Agent.isStopped = true;
            Anim.SetBool("isDead", true);
            this.GetComponent<Rigidbody>().useGravity = true;
            ChruchQuest._Instance.AddMonsterKilled();
        }
        Anim.SetBool("isTakingDamage", true);

        Debug.Log("TookDamage " + health);
        //Anim.SetBool("isTakingDamage", false);
        // Damages au monstre
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collision.gameObject.tag " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(1);
            
        }

    }
    IEnumerator Death()
    {
        yield return (2);
        this.GetComponent<MeshCollider>().enabled = false;

    }
}
