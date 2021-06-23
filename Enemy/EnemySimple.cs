using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemySimple : MonoBehaviour
{
    public float lookRadius = 10f;
    public float attackRadius = 3f;

    public Transform enemyAttackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 40;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    Transform target;
    EnemyStats enemyStats;
    public AudioSource enemyAttkSound;


    //public event Action<Transform> OnAggro = delegate { };

    private void Start()
    {
        enemyStats = FindObjectOfType<EnemyStats>();
        target = PlayerStats.instance.player.transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        //Hurt = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        PlayerStats health = target.GetComponent<PlayerStats>();
        float distance = Vector3.Distance(target.position, transform.position);
        float attackDistance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            navMeshAgent.SetDestination(target.position);

            animator.SetFloat("Speed", 1);

            if (attackDistance <= attackRadius)
            {
                if (health.currentHealth > 0)
                {
                    animator.SetTrigger("EnemyAttack");
                }

                animator.SetFloat("Speed", 0);

                FaceTarget();
            }

        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }

    void Attack()
    {
        PlayerStats health = target.GetComponent<PlayerStats>();
        //health.TakeDamage(20);
        Collider[] hitEnemies = Physics.OverlapSphere(enemyAttackPoint.position, attackRange, enemyLayers);

        //Damage them 
        foreach (Collider enemy in hitEnemies)
        {

            //enemy.GetComponent<PlayerCombat>().TakeDamage(attackDamage);
            health.TakeDamage(20);
        }
    }

    void FaceTarget() //faces target!!!
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void EnemyCombo()
    {
        animator.Play("EnemyComboAttack");
    }

    public void EnemyAttkSound()
    {
        enemyAttkSound.Play();
    }
}
