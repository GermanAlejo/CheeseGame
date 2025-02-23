using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform player;
    public float moveSpeed;
    public float minimunDetectingDistance;

    private float difference;

    private Vector2 playerPos;
    private Vector2 enemyPos;
    private bool faceRight = false;
    Rigidbody2D rb;
    
   
    // Use this for initialization
    void Start()
    {

        faceRight = true;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        enemyPos = rb.position;
        playerPos = player.position;

        difference  = Mathf.Abs(enemyPos.x - playerPos.x);

        if (!PlayerHealth.isDead && difference <= minimunDetectingDistance)
         {
            if (enemyPos.x > playerPos.x)
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
            else if (enemyPos.x < playerPos.x)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
         }

        

    }


}