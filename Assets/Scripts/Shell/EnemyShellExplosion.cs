using UnityEngine;
/// <summary>
/// EnemyShellExplosion sends the damage to the Player GameObject if they collide, and takes care of destroying the shell and playing the audio and particles(Last two apparently
/// not working well)
/// </summary>
public class EnemyShellExplosion : MonoBehaviour
{
    
    
    public ParticleSystem ExplosionParticles; // ? not working       
    public AudioSource ExplosionAudio; // ? not working                     
    public float MaxLifeTime = 3f;                  
    public float BulletSpeed = 20f;
    public float Damage = 20f;
    private Rigidbody rb;

    private void Start()
    {
        Destroy(gameObject, MaxLifeTime);
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, 0, BulletSpeed, ForceMode.Impulse);
        
    }


    private void OnTriggerEnter(Collider other)
    {

        

        if (other.gameObject.tag == "Player")
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