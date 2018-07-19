using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ObjectHealth : MonoBehaviour
{
    public float startingHealth = 100f;          
    public Slider slider;                        
    public Image fillImage;                      
    public Color fullHealthColor = Color.green;  
    public Color zeroHealthColor = Color.red;    
    public GameObject explosionPrefab;

    
    private GameManager _gameManager;
    private AudioSource _explosionAudio;          
    private ParticleSystem _explosionParticles;   
    private float _currentHealth;  
    private bool _isDead;

    private void Start()
    {
        
    }
    private void Awake()
    {
        _explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        _explosionAudio = _explosionParticles.GetComponent<AudioSource>();

        _explosionParticles.gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        _currentHealth = startingHealth;
        _isDead = false;

        SetHealthUI();
    }
    

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        SetHealthUI();

        if (_currentHealth <= 0f && !_isDead) {
            OnDeath();
        }

    }


    private void SetHealthUI()
    {
        slider.value = _currentHealth;

        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, _currentHealth / startingHealth);


    }


    private void OnDeath()
    {
        _isDead = true;
        _explosionParticles.transform.position = transform.position;
        _explosionParticles.gameObject.SetActive(true);

        _explosionParticles.Play();

        _explosionAudio.Play();

        this.gameObject.SetActive(false);
        if(gameObject.tag=="Player")
            _gameManager.GameOver();
        
    }
}