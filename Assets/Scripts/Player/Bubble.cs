using UnityEngine;

public class Bubble : MonoBehaviour
{
	[SerializeField]
	protected float size = 1.0f;

	[SerializeField]
	protected float shrinkPerSecond = 0.15f;

	[SerializeField]
	protected Transform graphics;

	[SerializeField]
	protected Transform collision;

	[SerializeField]
	protected AnimationCurve bubbleSizeToGraphicSizeCurve;

	private void Update()
	{
		UpdateBubbleSize(GetBubbleSize() - shrinkPerSecond * Time.deltaTime);
	}

	public void UpdateBubbleSize(float newSize)
	{
		size = newSize;

		float newGraphicSize = GetBubbleRadius() * 2f;
		graphics.localScale = new Vector3(newGraphicSize, newGraphicSize, 1f);

		collision.localScale = new Vector3(newGraphicSize, newGraphicSize, 1f);
	}

	// bad names fixme
	public float GetBubbleSize()
	{
		return size;
	}

	public float GetBubbleRadius()
	{
		return bubbleSizeToGraphicSizeCurve.Evaluate(GetBubbleSize()) / 2f;
	}
}
