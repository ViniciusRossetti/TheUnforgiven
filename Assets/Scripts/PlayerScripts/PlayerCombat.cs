using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 20;
    public float attackRate = 1f;
    float nextAttackTime = 1f;

    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
           if (Input.GetKeyDown(KeyCode.Space))
           {
              Attack();
              nextAttackTime = Time.time + 1f / attackRate;
           }
        }
        
    }

    void Attack()
    {
        animator.SetTrigger("PAttack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D Enemy in hitEnemies)
        {
            Enemy.GetComponent<Enemy>().TakeDamage(attackDamage);

        }

    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
           return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
