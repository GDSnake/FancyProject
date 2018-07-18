using UnityEngine;

public class PlayerShellExplosion : MonoBehaviour
{
   
    
    public ParticleSystem ExplosionParticles;       
    public AudioSource ExplosionAudio;              
    public float MaxDamage = 100f;                  
    public float ExplosionForce = 1000f;            
    public float MaxLifeTime = 5f;                  
    public float ExplosionRadius = 5f;
    public float BulletSpeed = 20f;
    public float Damage = 25f;
    private Rigidbody rb;

    private void Start()
    {
        Destroy(gameObject, MaxLifeTime);
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, 0, BulletSpeed, ForceMode.Impulse);
        
    }


    private void OnTriggerEnter(Collider other)
    {

       

        if (other.gameObject.tag == "Enemy")
        {
            
                other.gameObject.GetComponent<ObjectHealth>().TakeDamage(Damage);
                ExplosionParticles.transform.parent = null;
                ExplosionParticles.Play();
                ExplosionAudio.Play();
                Destroy(ExplosionParticles.gameObject, ExplosionParticles.main.duration);
                Destroy(gameObject);
            
            
        }

        
    }


    
}