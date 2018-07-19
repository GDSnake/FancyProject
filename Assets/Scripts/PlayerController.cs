using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerController class takes care of the player's ship movement, shooting and lockOn actions
/// </summary>
public class PlayerController : MonoBehaviour
{

    public float MovSpeed = 12f;
    public float TurningSpeed = 180f;
    public AudioSource MovementAudio;
    public AudioSource ShootAudio;
    public AudioClip IdleSound;
    public AudioClip DrivingSound;
    public AudioClip ShootClip;
    public float PitchRange = 0.2f;
    public GameObject Shot;
    public Transform ShotSpawn;
    public float FireRate = 0.5f;

    private float nextFire = 0.0f;
    private Rigidbody rb;
    private float movementInputValue;
    private float turnInputValue;
    private float originaPitch;

    void Start ()
    {
        originaPitch = MovementAudio.pitch;
        ShootAudio.clip = ShootClip;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.isKinematic = false;
        movementInputValue = 0f;
        turnInputValue = 0f;
    }

    private void OnDisable()
    {
       rb.isKinematic = true;
    }

    void FixedUpdate()
    {
        
        Move();
        Turn();

         
    }

    

    private void Turn()
    {
        float turn = turnInputValue * TurningSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        rb.MoveRotation(rb.rotation * turnRotation);
    }

    private void Move()
    {
        Vector3 movement = transform.forward * movementInputValue * MovSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + movement);
    }

    // Update is called once per frame
	void Update () {
		movementInputValue = Input.GetAxis("Vertical");
        turnInputValue = Input.GetAxis("Horizontal");

	    EngineAudio();
	    if (Input.GetButton("Fire1") && Time.time > nextFire)
	    {
	        nextFire = Time.time + FireRate;
            ShootAudio.Play();
	        if (TargetEnemy.LockedOn)
	        {
	            Quaternion direction = TargetEnemy.VisibleEnemies[TargetEnemy.LockedEnemy].transform.rotation; // Gets the current visible enemy on the array if any
	            Vector3 rot = direction.eulerAngles;
	            rot = new Vector3(rot.x, rot.y + 180, rot.z); // Needs to rotate 180º degress on the Y axis to prevent shooting on the opposite direction
	            direction = Quaternion.Euler(rot);
	           
	            Instantiate(Shot, ShotSpawn.position, direction);
	        }
	        else
	        {
                Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
            }
          
        }
	    
	}
    /// <summary>
    /// EngineAudio method takes care of switching Idle and Driving sounds as well giving a different pitch to the sound each time.
    /// </summary>
    private void EngineAudio()
    {
        if (Mathf.Abs(movementInputValue) < 0.1f && Mathf.Abs(turnInputValue) < 0.1f)
        {
            if (MovementAudio.clip == DrivingSound)
            {
                MovementAudio.clip = IdleSound;
                MovementAudio.pitch = Random.Range(originaPitch - PitchRange, originaPitch + PitchRange);
                MovementAudio.Play();
            }
        }
        else
        {
            if (MovementAudio.clip == IdleSound) {
                MovementAudio.clip = DrivingSound;
                MovementAudio.pitch = Random.Range(originaPitch - PitchRange, originaPitch + PitchRange);
                MovementAudio.Play();
            }
        }
    }
}
