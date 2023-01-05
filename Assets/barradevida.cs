using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class barradevida : MonoBehaviour
{
    public float timeBtwAttack;

    public Animator animator;
  

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    public Image BarradeVida;

    public float vidaactual;

    public float vidaMax;

    // Update is called once per frame

    private void Start()
    {
        timeBtwAttack = 2;
    }

    void Update()
    {
        BarradeVida.fillAmount = vidaactual / vidaMax;
        timeBtwAttack += Time.deltaTime;

        if (timeBtwAttack > 2)

        {
            if (Input.GetButtonDown("Fire1"))

            {
                animator.SetTrigger("Pegando");


                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                   if (enemiesToDamage[i].gameObject.name == "Enemigo")
                    {
                        enemiesToDamage[i].GetComponent<Enemigo>().TakeDamage(damage);
                    }

                  
                }

                timeBtwAttack = 0;

            }
            if (vidaactual <= 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
    public void TakeDamage(int damage)
    {
        vidaactual--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "caida")
        {
            vidaactual = 0;
        }
        if (collision.gameObject.tag == "Botiquin")
        {
            vidaactual = 5;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Pinchos")
        {
            vidaactual--;
        } 

    }
}
