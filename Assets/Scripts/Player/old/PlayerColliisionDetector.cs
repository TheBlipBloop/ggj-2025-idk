using UnityEngine;
using UnityEngine.Events;

public class PlayerColliisionDetector : MonoBehaviour
{

	[SerializeField]
	protected UnityEvent<Player, Bubble> playerEnter;

	[SerializeField]
	protected UnityEvent<Player, Bubble> playerExit;

	[SerializeField]
	protected UnityEvent<Player, Bubble> playerStay;

	private void OnCollisionEnter2D(Collision2D collision2D)
	{
		print(collision2D.gameObject.name);
		if (!IsPlayer(collision2D))
		{
			return;
		}

		Player player = collision2D.gameObject.GetComponent<Player>();
		Bubble bubble = player.GetBubble();

		playerEnter?.Invoke(player, bubble);
	}

	private void OnCollisionExit2D(Collision2D collision2D)
	{
		if (!IsPlayer(collision2D))
		{
			return;
		}

		Player player = collision2D.gameObject.GetComponent<Player>();
		Bubble bubble = player.GetBubble();

		playerExit?.Invoke(player, bubble);
	}

	private void OnCollisionStay2D(Collision2D collision2D)
	{
		if (!IsPlayer(collision2D))
		{
			return;
		}

		Player player = collision2D.gameObject.GetComponent<Player>();
		Bubble bubble = player.GetBubble();

		playerStay?.Invoke(player, bubble);
	}

	private bool IsPlayer(Collision2D collision2D)
	{
		return collision2D != null && collision2D.gameObject && collision2D.gameObject.layer == 3;
	}
}
