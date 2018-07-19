using System.Collections;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ShootingDirection class that points the fireTransform into the player, and it enters it's range, shoots a bullet every 2 secons
/// </summary>
public class ShootingDirection : MonoBehaviour
{

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
        
        transform.LookAt(player);
    }
    /// <summary>
    /// Shooting coroutine, makes a instance of the EnemyShell prefab and shoots in the direction of the player every 2 seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator Shooting()
    {
        while (true)
        {
            ShootingAudio.clip = FireClip;
            ShootingAudio.Play();
            Instantiate(Shell, FireTransform.position, FireTransform.rotation);
            yield return new WaitForSeconds(1);
            ShootingAudio.clip = ChargingClip;
            ShootingAudio.Play();
            yield return new WaitForSeconds(1);

        }
    }

   
}