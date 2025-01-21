using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerColliisionDetector : MonoBehaviour
{

	[SerializeField]
	protected UnityEvent<GameObject, Collision2D> playerEnter;

	[SerializeField]
	protected UnityEvent<GameObject, Collision2D> playerExit;

	[SerializeField]
	protected UnityEvent<GameObject, Collision2D> playerStay;

	[SerializeField]
	protected LayerMask playerLayerMask;

	private void OnCollisionEnter2D(Collision2D collision2D)
	{
		print("collision enter!!");
		if (!IsPlayer(collision2D))
		{
			return;
		}
		print("collision player enter!!");

		// get player object using its child collider
		GameObject playerGameObject = collision2D.transform.parent.gameObject;
		playerEnter?.Invoke(playerGameObject, collision2D);
	}

	private void OnCollisionExit2D(Collision2D collision2D)
	{
		if (!IsPlayer(collision2D))
		{
			return;
		}

		// get player object using its child collider
		GameObject playerGameObject = collision2D.transform.parent.gameObject;
		playerEnter?.Invoke(playerGameObject, collision2D);
	}

	private void OnCollisionStay2D(Collision2D collision2D)
	{
		if (!IsPlayer(collision2D))
		{
			return;
		}

		// get player object using its child collider
		GameObject playerGameObject = collision2D.transform.parent.gameObject;
		playerEnter?.Invoke(playerGameObject, collision2D);
	}

	private bool IsPlayer(Collision2D collision2D)
	{
		return collision2D != null && collision2D.gameObject && collision2D.gameObject.layer == playerLayerMask;
	}
}
