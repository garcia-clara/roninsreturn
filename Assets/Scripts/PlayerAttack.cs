using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;

    void Update(){
        if(Input.GetKeyDown(KeyCode.X)){
            Attack();
        }
    }

    private void Attack(){
        // Joue l'animation d'attaque
        animator.SetTrigger("Attack");

        //Détecte les ennemis dans la range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Fait des dégats
        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected(){
    if(attackPoint == null)
        return;
    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
}
}
