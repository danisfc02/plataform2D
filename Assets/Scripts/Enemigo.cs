using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{
    public float speed;
    public float timeBtwAttack;

    public int maxHealth;
    int currentHealth;
    

    public Animator Animator;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;


    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()

    {


        timeBtwAttack += Time.deltaTime;

        if (timeBtwAttack > 3)

        {
            Animator.SetTrigger("estaHit");

            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<barradevida>().TakeDamage(damage);
            }
            timeBtwAttack = 0;
        }
        if (currentHealth <= 0)
            Destroy(gameObject);

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;    
    }

    
}
