using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShootingDirection : MonoBehaviour
{
    //public LayerMask PlayerMask;    
    Transform player;
    public GameObject Shell;            
    public Transform FireTransform;              
    public AudioSource ShootingAudio;  
    public AudioClip ChargingClip;     
    public AudioClip FireClip;         
    

    
  
    private Quaternion targetPos;


    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        
    }

   

    void OnTriggerEnter(Collider other)
    {

        
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("Shooting");
        }

             



    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine("Shooting");
        }
        
            
            
        
        
    }

  

    void Update()
    {
        // Track the current state of the fire button and make decisions based on the current launch force.
        //transform.LookAt(2* transform.position - player.position);
        transform.LookAt(player);
    }

    IEnumerator Shooting()
    {
        while (true)
        {
          Instantiate(Shell, FireTransform.position, FireTransform.rotation);
           
            yield return new WaitForSeconds(2);
        }
    }

   
}