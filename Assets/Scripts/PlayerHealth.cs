using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isInvincible = false;
    private Animator animator;
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator = GetComponent<Animator>();
    }

    void Update(){
    }

    public void TakeDamage(int damage){
        if(!isInvincible){
        currentHealth = currentHealth - damage;
        healthBar.SetHealth(currentHealth);
        isInvincible = true;
        animator.SetBool("TakeDamage", true);
        StartCoroutine(HandleInvincibilityDelay());
        }
        
    }

    public IEnumerator HandleInvincibilityDelay(){
            yield return new WaitForSeconds(1f);
            animator.SetBool("TakeDamage", false);
            isInvincible = false;
    }

}
