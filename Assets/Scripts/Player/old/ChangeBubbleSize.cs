using UnityEngine;

public class ChangeBubbleSize : MonoBehaviour
{
	private Bubble targetBubble;

	private float amountToAddPerSecond;

	public void SetBubble(Bubble bubble)
	{
		targetBubble = bubble;
	}

	public void SetBubble(Player player, Bubble bubble)
	{
		SetBubble(bubble);
	}

	public void ClearBubble()
	{
		targetBubble = null;
	}

	public void AddBubbleAir(float amount)
	{
		if (amount == 0)
		{
			return;
		}

		targetBubble.UpdateBubbleAir(targetBubble.GetBubbleAir() + amount);
	}

	public void StartAddingBubbleAir(float amountPerSecond)
	{
		amountToAddPerSecond = amountPerSecond;
	}

	public void StopAddingBubbleAir()
	{
		amountToAddPerSecond = 0;
	}

	private void Update()
	{
		if (targetBubble)
		{
			AddBubbleAir(amountToAddPerSecond);
		}
	}
}
