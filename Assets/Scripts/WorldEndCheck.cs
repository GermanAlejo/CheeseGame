using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEndCheck : MonoBehaviour {

    public Transform player;
    PlayerHealth playerHealth;

    // Use this for initialization
    void Start ()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }
	
    void Update()
    {
        if (player.position.y < this.transform.position.y)
        {
            playerHealth.TakeDamage(playerHealth.currentHealth);
        }
    }
	
}
