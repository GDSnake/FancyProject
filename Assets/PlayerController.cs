using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movSpeed = 12f;
    public float turningSpeed = 180f;
    public AudioSource movementAudio;
    public AudioClip idleSound;
    public AudioClip drivingSound;
    public float pitchRange = 0.2f;

 
    private Rigidbody rb;
    private float movementInputValue;
    private float turnInputValue;
    private float originaPitch;

    // Use this for initialization
    void Start ()
    {
        originaPitch = movementAudio.pitch;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.isKinematic = true;
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
        float turn = turnInputValue * turningSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        rb.MoveRotation(rb.rotation * turnRotation);
    }

    private void Move()
    {
        Vector3 movement = transform.forward * movementInputValue * movSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + movement);
    }

    // Update is called once per frame
	void Update () {
		movementInputValue = Input.GetAxis("Vertical");
        turnInputValue = Input.GetAxis("Horizontal");

	    EngineAudio();
	}

    private void EngineAudio()
    {
        if (Mathf.Abs(movementInputValue) < 0.1f && Mathf.Abs(turnInputValue) < 0.1f)
        {
            if (movementAudio.clip == drivingSound)
            {
                movementAudio.clip = idleSound;
                movementAudio.pitch = Random.Range(originaPitch - pitchRange, originaPitch + pitchRange);
                movementAudio.Play();
            }
        }
        else
        {
            if (movementAudio.clip == idleSound) {
                movementAudio.clip = drivingSound;
                movementAudio.pitch = Random.Range(originaPitch - pitchRange, originaPitch + pitchRange);
                movementAudio.Play();
            }
        }
    }
}
