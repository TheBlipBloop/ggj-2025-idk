using UnityEngine;
using UnityEngine.Events;

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

	[SerializeField]
	protected UnityEvent onPop;

	private void Update()
	{
		UpdateBubbleAir(GetBubbleAir() - shrinkPerSecond * Time.deltaTime);
	}

	public void AddAir(float amount)
	{
		UpdateBubbleAir(GetBubbleAir() + amount);
	}

	public void UpdateBubbleAir(float newAir)
	{
		if (air > minAir && newAir <= minAir)
		{
			onPop?.Invoke();
		}
		if (air < maxAir && newAir >= maxAir)
		{
			onPop?.Invoke();
		}

		air = Mathf.Clamp(newAir, minAir, maxAir);

		float newGraphicSize = GetBubbleRadius() * 2f;
		graphics.localScale = new Vector3(newGraphicSize, newGraphicSize, 0.5f);
		collision.localScale = new Vector3(newGraphicSize, newGraphicSize, 1f);
	}

	public float GetBubbleAir()
	{
		return air;
	}

	public float GetBubbleRadius()
	{
		return bubbleSizeToGraphicSizeCurve.Evaluate(GetBubbleAir()) / 2f;
	}
}
