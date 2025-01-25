using UnityEditor.ShaderGraph.Internal;
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

	[SerializeField]
	protected SpawnObject deathObject;

	[Header("Input")]

	private InputAction moveAction;

	private InputAction jumpAction;

	private InputAction respawnAction;

	[Header("Movement")]

	[SerializeField]
	protected LayerMask groundMask = 0;

	[SerializeField]
	protected float groundCheckDistance = 0.05f;

	[SerializeField]
	protected float jumpForceMin = 5f;

	[SerializeField]
	protected float jumpForceMax = 10f;

	[SerializeField]
	protected float moveSpeed = 20f;

	[SerializeField]
	protected float maxMoveSpeed = 10f;

	[SerializeField]
	protected float changeDirectionSpeedScalar = 2.0f;

	[SerializeField]
	protected float airSpeedScalar = 0.75f;

	[SerializeField]
	protected float frictionSpeed = 8.0f;

	[SerializeField]
	protected float coyoteTime = 0.1f;

	[SerializeField]
	protected float jumpBufferTime = 0.1f;

	private Vector2 moveInput = new Vector2(0, 0);

	private float lastJumpTime = float.NegativeInfinity;

	private float lastGroundedTime = float.NegativeInfinity;

	[Header("Bubble Scale")]

	[SerializeField]
	protected AnimationCurve moveSpeedScalarByBubbleSize = AnimationCurve.Linear(0.1f, 2f, 4f, 0.4f);

	[SerializeField]
	protected AnimationCurve gravityScaleByBubbleSize = AnimationCurve.Linear(0.5f, 2f, 4f, 0.3f);

	[SerializeField]
	protected AnimationCurve airSpeedScalarByBubbleSize = AnimationCurve.Linear(2f, 1f, 4f, 0.2f);

	[SerializeField]
	protected AnimationCurve directionChangeSpeedScalarByBubbleSize = AnimationCurve.Linear(1f, 1f, 4f, 0.2f);

	[SerializeField]
	protected AnimationCurve moveSpeedMaxScalarByBubbleSize = AnimationCurve.Linear(2f, 1f, 3f, 1f);

	[Header("Misc")]

	[SerializeField]
	protected Transform characterTransform;

	[SerializeField]
	protected Spring characterRotation;

	[SerializeField]
	protected Vector3 checkpointPosition;

	protected virtual void Start()
	{
		BindInputActions();

		body.freezeRotation = true;
	}

	private void BindInputActions()
	{
		moveAction = InputSystem.actions.FindAction("Move");
		jumpAction = InputSystem.actions.FindAction("Jump");
		respawnAction = InputSystem.actions.FindAction("Reload");
	}

	// Update is called once per frame
	protected virtual void Update()
	{
		UpdateInputFromActions();

		characterRotation.SetTarget(moveInput.x * -20f);
		characterTransform.eulerAngles = new Vector3(0, 0, characterRotation.GetValue());
		characterRotation.Update(Time.deltaTime);

		if (respawnAction.ReadValue<float>() > 0.5f)
		{
			Die();
		}
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

		float moveSpeedScale = 1.0f;

		if (!OnGround())
		{
			moveSpeedScale *= GetBaseAirMoveSpeedScalar();
		}

		if (moveInput.x > 0 != body.linearVelocityX > 0)
		{
			moveSpeedScale *= GetBaseDirectionChangeSpeedScalar();
		}

		body.linearVelocityX += Time.fixedDeltaTime * moveInput.x * GetBaseMoveSpeed() * moveSpeedScale;
		body.linearVelocityX = Mathf.Clamp(body.linearVelocityX, -GetMaxMoveSpeed(), GetMaxMoveSpeed());

		if (Mathf.Abs(moveInput.x) < 0.1f)
		{
			body.linearVelocityX = Mathf.MoveTowards(body.linearVelocityX, 0f, frictionSpeed * Time.fixedDeltaTime);
		}

		if (RequestingJump() && OnGround())
		{
			body.linearVelocityY = jumpForceMax;
			lastJumpTime = float.NegativeInfinity;
		}

		if (CanceledJump() && body.linearVelocityY > jumpForceMin)
		{
			body.linearVelocityY = jumpForceMin;
		}

		body.linearVelocityY = Mathf.Min(body.linearVelocityY, jumpForceMax);

		body.gravityScale = GetGravityScale();
	}

	protected void UpdateGrounded()
	{
		RaycastHit2D groundHit = Physics2D.CircleCast(body.position, GetBubbleRadius(), Vector2.down, groundCheckDistance, groundMask.value);

		if (groundHit.collider)
		{
			lastGroundedTime = Time.time;
		}
	}

	protected bool CanceledJump()
	{
		return jumpAction.ReadValue<float>() < 0.5f;
	}

	public bool OnGround()
	{
		return Time.time - lastGroundedTime < coyoteTime;
	}

	protected bool RequestingJump()
	{
		return Time.time - lastJumpTime < jumpBufferTime;
	}

	protected float GetBubbleSize()
	{
		return bubble.GetBubbleAir();
	}

	protected float GetBubbleRadius()
	{
		return bubble.GetBubbleRadius();
	}

	// Scaling by bubble size:

	private float GetBaseMoveSpeed()
	{
		return moveSpeed * moveSpeedScalarByBubbleSize.Evaluate(GetBubbleSize());
	}

	private float GetBaseAirMoveSpeedScalar()
	{
		return airSpeedScalar * airSpeedScalarByBubbleSize.Evaluate(GetBubbleSize());
	}

	private float GetBaseDirectionChangeSpeedScalar()
	{
		return changeDirectionSpeedScalar * directionChangeSpeedScalarByBubbleSize.Evaluate(GetBubbleSize());
	}

	private float GetMaxMoveSpeed()
	{
		return maxMoveSpeed * moveSpeedMaxScalarByBubbleSize.Evaluate(GetBubbleSize());
	}

	private float GetGravityScale()
	{
		return gravityScaleByBubbleSize.Evaluate(GetBubbleSize());
	}

	public Bubble GetBubble()
	{
		return bubble;
	}

	public Rigidbody2D GetBody()
	{
		return body;
	}


	// BAD CODE
	public void Die()
	{
		deathObject.Spawn();
		gameObject.SetActive(false);
		Game.HandlePlayerDeath();
	}

	public void SetCheckpointPosition(Vector3 newPosition)
	{
		checkpointPosition = newPosition;
	}

	public void RestoreFromCheckpoint()
	{
		gameObject.SetActive(true);
		transform.position = checkpointPosition;
		bubble.UpdateBubbleAir(1f);
	}
}
