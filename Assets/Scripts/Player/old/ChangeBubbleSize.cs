using UnityEngine;

public class ChangeBubbleSize : MonoBehaviour
{
	private Bubble targetBubble;

	private float amountToAddPerSecond;

	public void SetBubble(Bubble bubble)
	{
		targetBubble = bubble;
	}

	public void SetBubble(GameObject bubble, Collision2D collision2D)
	{
		SetBubble(bubble.GetComponent<Bubble>());
	}

	public void ClearBubble()
	{
		targetBubble = null;
	}

	public void AddBubbleSize(float amount)
	{
		if (amount == 0)
		{
			return;
		}

		targetBubble.UpdateBubbleAir(targetBubble.GetBubbleAir() + amount);
	}

	public void StartAddingBubbleSize(float amountPerSecond)
	{
		amountToAddPerSecond = amountPerSecond;
	}

	public void StopAddingBubbleSize()
	{
		amountToAddPerSecond = 0;
	}

	private void Update()
	{
		if (targetBubble)
		{
			AddBubbleSize(amountToAddPerSecond);
		}
	}
}
