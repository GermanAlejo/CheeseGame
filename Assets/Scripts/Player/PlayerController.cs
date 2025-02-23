using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
   
    public float jumpheight;
    public float movespeedair;
    public float speed;



    public float gravityModifier = 1f;
    public bool hasjumpedtwice;
    public bool onGround = true;
    public float forceBullet;

    public bool faceRight;

    public GameObject prefBullet;
    public Transform posBullet;
    public Transform bossCheck;
    public LayerMask whatisground;
    public Transform groundcheck;

    protected Vector2 velocity;

    private bool isJumping;

    Rigidbody2D rb;
    public Animator anim; //para modificar el componente animator

    void Saltar()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpheight);
    }

    void FixedUpdate() // igual quel update pero pa fosicas
    {
        onGround = Physics2D.OverlapCircle(groundcheck.position, 0.5f, whatisground);  //si el circulo se esta chocando con algo, se le pasa posicion donde queremos el circulo, el radio del círculo, y lo que es el suelo(variable tipo layermask, es a lo que mira si se esta chocando pa devolver true o false)
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(prefBullet, posBullet.position, posBullet.rotation) as GameObject; //para asociar la bala que se crea a una variable
        if (faceRight)
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(forceBullet, bullet.GetComponent<Rigidbody2D>().velocity.y);
        else
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-forceBullet, bullet.GetComponent<Rigidbody2D>().velocity.y);
    }


    // Use this for initialization
    void Start()
    {

        faceRight = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); //coger el propio componente animator de este objeto

    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerHealth.isDead)
        {

            float h = Input.GetAxis("Horizontal");

            if (onGround)
            {
                hasjumpedtwice = false;
                rb.velocity = new Vector2(speed * h, rb.velocity.y);
                anim.SetFloat("speed", Mathf.Abs(rb.velocity.x)); //valor absoluto de la velocidad
            }

            else
            {
                rb.velocity = new Vector2((movespeedair * h), rb.velocity.y);
                anim.SetFloat("speed", 0);
            }

            if (Input.GetButtonDown("Jump") && onGround)
            {
                Saltar();
            }

            if (Input.GetButtonDown("Jump") && hasjumpedtwice == false)
            {
                Saltar();
                hasjumpedtwice = true;
            }

            anim.SetBool("onGround", onGround);

            if (rb.velocity.x > 0)
            {
                faceRight = true;
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (rb.velocity.x < 0)
            {
                faceRight = false;
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }
  
       
     public bool BossCheck() 
    {
        float differenceX = Mathf.Abs(rb.position.x - bossCheck.transform.position.x);
        float differenceY = Mathf.Abs(rb.position.y - bossCheck.transform.position.y);
        if (differenceX <= 0 && differenceY <= 1)
        {
            return true;
            print("loko");
        }
        else
            return false;
    }

    
}
