using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float BulletSpeed;
    public float MaxLifeTime = 2f;
	void Start ()
	{
	    rb.GetComponent<Rigidbody>();
        rb.AddRelativeForce(0,0,BulletSpeed,ForceMode.Impulse);
        Destroy(gameObject, MaxLifeTime);
        
    }
    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player")
        {
            CalculateDamage();
            Destroy(gameObject);
        }
        
    }


    private float CalculateDamage()
    {


        float damage = 25;

        return damage;
    }

}
