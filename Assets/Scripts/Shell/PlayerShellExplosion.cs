using UnityEngine;
///<summary>
/// PlayerShellExplosion sends the damage to the Enemy GameObject that collides with, and takes care of destroying the shell and playing the audio and particles(Last two apparently
/// not working well)
/// </summary>
public class PlayerShellExplosion : MonoBehaviour
{
   
    
    public ParticleSystem ExplosionParticles;  //? not working  
    public AudioSource ExplosionAudio;   //? not working                      
    public float MaxLifeTime = 5f;                  
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