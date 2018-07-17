﻿using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask PlayerMask;
    public ParticleSystem ExplosionParticles;       
    public AudioSource ExplosionAudio;              
    public float MaxDamage = 100f;                  
    public float ExplosionForce = 1000f;            
    public float MaxLifeTime = 3f;                  
    public float ExplosionRadius = 5f;
    public float BulletSpeed = 20f;
    public float damage = 25f;
    private Rigidbody rb;

    private void Start()
    {
        Destroy(gameObject, MaxLifeTime);
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, 0, BulletSpeed, ForceMode.Impulse);
    }


    private void OnTriggerEnter(Collider other)
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius, PlayerMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            if (!targetRigidbody)
            {
                continue;
            }
            targetRigidbody.AddExplosionForce(ExplosionForce,transform.position,ExplosionRadius);
            PlayerHealth targetHealth = targetRigidbody.GetComponent<PlayerHealth>();

            if(!targetHealth)
                continue;

            

            targetHealth.TakeDamage(damage);
        }

        ExplosionParticles.transform.parent = null;
        ExplosionParticles.Play();
        ExplosionAudio.Play();
        Destroy(ExplosionParticles.gameObject, ExplosionParticles.main.duration);
        //Destroy(gameObject);
    }


    
}