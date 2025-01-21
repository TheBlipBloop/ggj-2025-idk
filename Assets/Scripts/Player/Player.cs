using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Bubble))]
public class Player : MonoBehaviour
{
	[Header("Player")]

	[SerializeField]
	protected Rigidbody2D body;

	[SerializeField]
	protected Bubble bubble;

	[Header("Input")]

	private InputAction moveAction;

	private InputAction jumpAction;

	[Header("Movement")]

	[SerializeField]
	protected LayerMask groundMask = 0;

	[SerializeField]
	protected float groundCheckDistance = 1.0f;

	[SerializeField]
	protected float jumpForceMin = 5f;

	[SerializeField]
	protected float jumpForceMax = 10f;

	[SerializeField]
	protected float moveSpeed = 10f;

	[SerializeField]
	protected float coyoteTime = 0.1f;

	[SerializeField]
	protected float jumpBufferTime = 0.1f;

	private Vector2 moveInput = new Vector2(0, 0);

	private float lastJumpTime = float.NegativeInfinity;

	private float lastGroundedTime = float.NegativeInfinity;


	protected virtual void Start()
	{
		BindInputActions();
	}

	private void BindInputActions()
	{
		moveAction = InputSystem.actions.FindAction("Move");
		jumpAction = InputSystem.actions.FindAction("Jump");
	}

	// Update is called once per frame
	protected virtual void Update()
	{
		UpdateInputFromActions();
	}

	private void UpdateInputFromActions()
	{
		moveInput = moveAction.ReadValue<Vector2>();
		if (jumpAction.WasPressedThisFrame())
		{
			lastJumpTime = Time.time;
		}
	}

	protected virtual void FixedUpdate()
	{
		UpdateGrounded();

		body.AddForceX(moveInput.x * moveSpeed);

		if (RequestingJump() && OnGround())
		{
			body.linearVelocityY = jumpForceMax;
			lastJumpTime = float.NegativeInfinity;
		}

		if (CanceledJump() && body.linearVelocityY > jumpForceMin)
		{
			body.linearVelocityY = jumpForceMin;
			print("Cutting jump!");
		}
	}

	protected void UpdateGrounded()
	{
		RaycastHit2D groundHit = Physics2D.Raycast(body.position, Vector2.down, groundCheckDistance, groundMask.value);

		if (groundHit.collider)
		{
			lastGroundedTime = Time.time;
		}
	}

	protected bool CanceledJump()
	{
		return jumpAction.ReadValue<float>() < 0.5f;
		// return jumpAction.WasReleasedThisFrame();
	}

	protected bool OnGround()
	{
		return Time.time - lastGroundedTime < coyoteTime;
	}

	protected bool RequestingJump()
	{
		return Time.time - lastJumpTime < jumpBufferTime;
	}

	protected float GetBubbleSize()
	{
		return bubble.GetBubbleSize();
	}
}
