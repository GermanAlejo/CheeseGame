using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject == player)
        {
            playerInRange = true;
            print("Player detected");
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            playerInRange = false;
            print("Player lost");
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (!PlayerHealth.isDead)
        {
            //print("Player in range: " + playerInRange);

            if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
            {

                print("AttackCalling");
                Attack();
            }

            if (playerHealth.currentHealth <= 0)
            {
                //  anim.SetTrigger("PlayerDead");
            }
        }

        
    }


    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
