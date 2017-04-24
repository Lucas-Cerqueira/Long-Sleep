using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(AudioSource))]

public class FPSMovement : MonoBehaviour
{
	public bool hideCursor = true;
    public float characterMass = 5;
    public float walkSpeed = 5;
    public float runSpeed = 10;
	public float maxVelocityChange = 1;
	public bool canJump = true;
	public float jumpHeight = 2f;
	public bool airControl = true;
	public AudioClip footstepSound;

    private Vector3 targetVelocity;
	private Vector3 velocityChange;
    private Transform cameraTransform;
	private Rigidbody body;
	private CapsuleCollider collider;
	private float speed = 5;
    private int layerMask = 1 << 8;
	private AudioSource audioSource;


	void OnCollisionStay (Collision collisionInfo)
	{
		
	}

    // Use this for initialization
    void Awake()
    {
		Cursor.visible = !hideCursor;
		cameraTransform = Camera.main.transform;
		body = GetComponent<Rigidbody> ();
		body.freezeRotation = true;

		collider = GetComponent<CapsuleCollider>();
		audioSource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey (KeyCode.LeftShift))
			speed = runSpeed;
		else
			speed = walkSpeed;

		RaycastHit hitinfo;
		//bool grounded = Physics.Raycast (transform.position, Vector3.down, collider.height/2f + 0.2f);
		bool grounded = Physics.SphereCast (transform.position - Vector3.up*collider.height/4f, collider.radius/2f, Vector3.down, out hitinfo, collider.height/2f, Physics.AllLayers);

		if ((grounded)|| (!grounded && airControl))
		{
			targetVelocity = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			targetVelocity = cameraTransform.TransformDirection (targetVelocity).normalized;
			targetVelocity *= speed;

			velocityChange = targetVelocity - body.velocity;

			velocityChange.x = Mathf.Clamp (velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp (velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;

			body.AddForce (velocityChange, ForceMode.VelocityChange);
			body.AddForce (-transform.up * 2);
		}

		if (grounded && canJump) 
		{
			if (Input.GetButtonDown ("Jump"))
			{
				body.AddForce (transform.up * jumpHeight);
				grounded = false;
			}
		}
		else 
		{
			body.AddForce (Physics.gravity * body.mass);
		}

		// is Walking
		if (grounded && body.velocity.magnitude > 0.1f) 
		{
			if (!audioSource.isPlaying && footstepSound) 
			{
				audioSource.clip = footstepSound;
				audioSource.pitch = speed / walkSpeed;
				audioSource.Play ();
			}
		} 
		else if (audioSource.clip.Equals (footstepSound))
			audioSource.Stop ();
    }
}
