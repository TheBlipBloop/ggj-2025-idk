using UnityEngine;

public class BubbleSource : MonoBehaviour
{
	[SerializeField]
	protected float bubblesPerSecond = 0.2f;

	protected Bubble currentBubble;


	private void Update()
	{
		if (currentBubble)
		{
			currentBubble.UpdateBubbleAir(currentBubble.GetBubbleAir() + bubblesPerSecond * Time.deltaTime);
		}
	}

	private void OnTriggerEnter2D(Collider2D collider2D)
	{
		if (!IsPlayer(collider2D))
		{
			return;
		}

		GameObject playerGameObject = collider2D.transform.parent.gameObject;
		Bubble bubble = playerGameObject.GetComponent<Bubble>();
		currentBubble = bubble;
	}

	private void OnTriggerExit2D(Collider2D collider2D)
	{
		if (!IsPlayer(collider2D))
		{
			return;
		}
		currentBubble = null;
	}

	private bool IsPlayer(Collider2D collider2D)
	{
		return collider2D != null && collider2D.gameObject.layer == 3;
	}
}
