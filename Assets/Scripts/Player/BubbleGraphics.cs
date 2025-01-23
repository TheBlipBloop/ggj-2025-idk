using UnityEngine;

// MESSY!

public class BubbleGraphics : MonoBehaviour
{
	[SerializeField]
	protected Renderer bubbleRenderer;

	[SerializeField]
	protected Transform morphTarget;

	[SerializeField]
	protected float radiusScale = 0.45f;

	[SerializeField]
	protected float morphScale = 0.7f;

	[SerializeField]
	protected float morphTrackSpeed = 4.0f;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		morphTarget.SetParent(null);
	}

	// Update is called once per frame
	void Update()
	{
		float radius = transform.lossyScale.x * radiusScale;

		morphTarget.transform.position = Vector3.Lerp(morphTarget.transform.position, transform.position + Vector3.up * radius, Time.deltaTime * morphTrackSpeed);

		Vector3 offset = morphTarget.position - transform.position;
		offset = Vector3.ClampMagnitude(offset, radius * morphScale);

		morphTarget.position = transform.position + offset;

		Vector3 morphPosition = transform.InverseTransformPoint(morphTarget.position);
		bubbleRenderer.material.SetVector("_MorphTarget_0", morphPosition);
	}
}
