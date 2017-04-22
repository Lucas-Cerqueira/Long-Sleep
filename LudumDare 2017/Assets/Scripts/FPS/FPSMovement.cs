using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

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

    private Vector3 targetVelocity;
	private Vector3 velocityChange;
    private Transform cameraTransform;
	private Rigidbody body;
	private CapsuleCollider collider;
	private float speed = 5;
    private int layerMask = 1 << 8;

    // Use this for initialization
    void Awake()
    {
		Cursor.visible = !hideCursor;
		cameraTransform = Camera.main.transform;
		body = GetComponent<Rigidbody> ();
		body.freezeRotation = true;

		collider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (Input.GetKey (KeyCode.LeftShift))
			speed = runSpeed;
		else
			speed = walkSpeed;

		RaycastHit hitinfo;
		bool grounded = Physics.Raycast (transform.position, Vector3.down, collider.height/2f + 0.1f);

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
    }
}
