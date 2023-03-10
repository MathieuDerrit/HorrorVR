using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float health = 1;
    [SerializeField] bool IsBoss;
    [SerializeField] bool CanMove;
    float lastAttackTime = 0;
    float attackCooldown = 2;
    float distance;
    [SerializeField] float stoppingDistance;
    [SerializeField] GameObject NavMesh;

    public NavMeshAgent Agent;
    public Transform Player;


    Vector3 randomDirection;
    [SerializeField] Animator Anim;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        /*
            if (Player != null && NavMesh !=null)
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
            else
            {
                GoToTarget();
            }

        
        */
    }

    private void GoToTarget()
    {
        if(Agent != null)
        {
            if(IsBoss == false) {
                Debug.Log(distance + " "+ randomDirection+ " "+ NavMesh.transform.position);
                if (CanMove == true)
                {
                    randomDirection = NavMesh.transform.position + Random.insideUnitSphere ;
                    randomDirection = new Vector3(randomDirection.x, 0, randomDirection.z);
                    Agent.SetDestination(randomDirection);
                    CanMove = false;
                }
                else
                {
                    if(distance <= stoppingDistance)
                    {
                        CanMove = true;
                        Debug.Log("yo");
                    }
                }
                distance = Vector3.Distance(transform.position, randomDirection);

            }
            else
            {
                Agent.SetDestination(Player.position);
            }
            Agent.isStopped = false;
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
        health = health - value;
        if(health <= 0)
        {
           // Agent.isStopped = true;
            Anim.SetBool("isDead", true);
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic =  false;
            ChruchQuest._Instance.AddMonsterKilled();
            Death();
            Debug.Log("death");
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
