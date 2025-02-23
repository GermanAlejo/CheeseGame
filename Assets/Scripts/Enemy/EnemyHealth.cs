using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    //public int scoreValue = 10;
    
    
    Animator anim;
    CapsuleCollider capsuleCollider;
    EnemyController enemyController;

    bool isDead;
    bool isSinking;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
        enemyController = GetComponent <EnemyController> ();

        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount)
    {
        if(isDead)
            return;
        

        currentHealth -= amount;
            

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        //capsuleCollider.isTrigger = true;

        enemyController.enabled = false;
        Destroy (gameObject, 0.7f);


        anim.SetBool("Dead", true);
        // ScoreManager.score += scoreValue;
    }


	
}
