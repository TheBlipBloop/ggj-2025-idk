using UnityEngine;
using UnityEngine.UI;

public class UIImageFade : MonoBehaviour
{
	[SerializeField]
	protected Image image;

	[SerializeField]
	protected Color initialColor = Color.black;

	[SerializeField]
	protected Color targetColor = Color.clear;

	[SerializeField]
	protected float duration = 0.2f;

	[SerializeField]
	private float time = 0;

	private void Update()
	{
		image.color = Color.Lerp(initialColor, targetColor, time / duration);
		time += Time.deltaTime;
	}
}
