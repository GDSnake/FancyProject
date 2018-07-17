using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float startingHealth = 100f;          
    public Slider slider;                        
    public Image fillImage;                      
    public Color fullHealthColor = Color.green;  
    public Color zeroHealthColor = Color.red;    
    public GameObject explosionPrefab;
    
    
    private AudioSource explosionAudio;          
    private ParticleSystem explosionParticles;   
    private float currentHealth;  
    private bool isDead;            


    private void Awake()
    {
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = explosionParticles.GetComponent<AudioSource>();

        explosionParticles.gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        currentHealth = startingHealth;
        isDead = false;

        SetHealthUI();
    }
    

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        SetHealthUI();

        if (currentHealth <= 0f && !isDead) {
            OnDeath();
        }

    }


    private void SetHealthUI()
    {
        slider.value = currentHealth;

        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currentHealth / startingHealth);


    }


    private void OnDeath()
    {
        isDead = true;
        explosionParticles.transform.position = transform.position;
        explosionParticles.gameObject.SetActive(true);

        explosionParticles.Play();

        explosionAudio.Play();

        gameObject.SetActive(false);
    }
}