using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class PlayerColliisionDetector : MonoBehaviour
{

	[SerializeField]
	protected UnityEvent<Player> playerEnter;

	[SerializeField]
	protected UnityEvent<Player> playerExit;

	[SerializeField]
	protected UnityEvent<Player> playerStay;

	private void OnCollisionEnter2D(Collision2D collision2D)
	{
		if (!IsPlayer(collision2D))
		{
			return;
		}

		Player player = collision2D.gameObject.GetComponent<Player>();
		playerEnter?.Invoke(player);
	}

	private void OnCollisionExit2D(Collision2D collision2D)
	{
		if (!IsPlayer(collision2D))
		{
			return;
		}

		Player player = collision2D.gameObject.GetComponent<Player>();
		playerExit?.Invoke(player);
	}

	private void OnCollisionStay2D(Collision2D collision2D)
	{
		if (!IsPlayer(collision2D))
		{
			return;
		}

		Player player = collision2D.gameObject.GetComponent<Player>();
		playerStay?.Invoke(player);
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.layer != 3)
		{
			return;
		}

		Player player = collider.attachedRigidbody.gameObject.GetComponent<Player>();

		playerEnter?.Invoke(player);
	}

	private bool IsPlayer(Collision2D collision2D)
	{
		return collision2D != null && collision2D.gameObject && collision2D.gameObject.layer == 3;
	}
}
