using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float killTime;
    public int bulletDamage;
	// Use this for initialization
	void Start () {

        Destroy(gameObject, killTime);
	
	}
	

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
        }

        if (other.gameObject.tag == "Ground")
        {
            Instantiate(null, gameObject.transform.position, gameObject.transform.rotation);
        }

        Destroy(gameObject);
    }
}
