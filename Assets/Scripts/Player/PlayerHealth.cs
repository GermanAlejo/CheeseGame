using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Text finalText;
    public Transform bossCheck;
    public GameObject boss;

    Animator anim;

    PlayerController playerController;
    public static bool isDead;
    bool damaged;


    void Awake()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        currentHealth = startingHealth;
        isDead = false;
        finalText.enabled = false;
    }
    

    public void TakeDamage(int amount)
    {

        currentHealth -= amount;

        healthSlider.value = currentHealth;
        print(healthSlider.value);

      

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


     void Death()
    {
        
        isDead = true;
        
        anim.Play("CHeesedie");
        
    }
    

    private void Update()
    {
        anim.SetBool("isDead", isDead);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == boss)
        {
            finalText.enabled = true;

            TakeDamage(currentHealth);
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       
    }
}
