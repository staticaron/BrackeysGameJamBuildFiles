using UnityEngine;

public class Player : MonoBehaviour
{
	//delegates
	public delegate void GroundData(bool isGrounded);
	public static event GroundData groundData;

	public delegate void PlayerLanded();
	public static event PlayerLanded playerLanded;

	public Arrow arrowScript;
	public Transform arrow;
	public Transform foot;

	public float force;
	public float radius;
	public LayerMask groundLayer;
	public bool isGrounded;

	private Rigidbody2D rb;
	private Collider2D thisCollider;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		thisCollider = GetComponent<Collider2D>();

	}

	void Update()
	{
		CheckGround();

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			Jump();
		}
	}

	void Jump()
	{
		Vector2 direction;
		direction = arrow.up;

		rb.AddForce(direction * force);

		ItemsManager.reduceJumps(1);
	}

	void CheckGround()
	{
		if (thisCollider.IsTouchingLayers(groundLayer))
		{
			isGrounded = true;
			SetArrow(true);

			if (groundData != null) groundData(true);
		}
		else {
			isGrounded = false;
			SetArrow(false);

			if (groundData != null) groundData(false);
		}
	}

	void SetArrow(bool choice)
	{
		arrowScript.shouldRotate = choice;
	}

	void OnCollisionEnter2D(Collision2D Col)
	{
		if (Col.collider.CompareTag("Ground"))
		{
			if (playerLanded != null)
			{
				playerLanded();
			}
		}
	}
}
