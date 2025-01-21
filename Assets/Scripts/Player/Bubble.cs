using UnityEngine;

public class Bubble : MonoBehaviour
{
	[SerializeField]
	protected float air = 1.0f;

	[SerializeField]
	protected float minAir = 0.2f;

	[SerializeField]
	protected float maxAir = 4.5f;

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
		UpdateBubbleAir(GetBubbleAir() - shrinkPerSecond * Time.deltaTime);
	}

	public void UpdateBubbleAir(float newAir)
	{
		air = Mathf.Clamp(newAir, minAir, maxAir);

		float newGraphicSize = GetBubbleRadius() * 2f;
		graphics.localScale = new Vector3(newGraphicSize, newGraphicSize, 1f);

		collision.localScale = new Vector3(newGraphicSize, newGraphicSize, 1f);
	}

	// bad names fixme
	public float GetBubbleAir()
	{
		return air;
	}

	public float GetBubbleRadius()
	{
		return bubbleSizeToGraphicSizeCurve.Evaluate(GetBubbleAir()) / 2f;
	}
}
