using UnityEngine;

public class Bubble : MonoBehaviour
{
	[SerializeField]
	protected float size = 1.0f;

	public float GetBubbleSize()
	{
		return size;
	}
}
