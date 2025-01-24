using UnityEngine;

// MESSY!

public class BubbleGraphics : MonoBehaviour
{
	[SerializeField]
	protected Player player;

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

	[SerializeField]
	protected Spring morphSpringX;

	[SerializeField]
	protected Spring morphSpringY;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		morphTarget.SetParent(null);
	}

	// Update is called once per frame
	void Update()
	{
		float radius = transform.lossyScale.x * radiusScale;

		morphSpringX.SetTarget(transform.position.x);
		if (player.OnGround())
		{
			morphSpringY.SetTarget(transform.position.y + radius / 3f);
		}
		else
		{
			morphSpringY.SetTarget(transform.position.y);
		}
		Vector3 morphTargetPosition = new Vector3(morphSpringX.GetValue(), morphSpringY.GetValue(), 0f);

		Vector3 offset = morphTargetPosition - transform.position;
		offset = Vector3.ClampMagnitude(offset, radius * morphScale);

		morphTarget.position = transform.position + offset;

		Vector3 morphPosition = transform.InverseTransformPoint(morphTarget.position);
		bubbleRenderer.material.SetVector("_MorphTarget_0", morphPosition);

		morphSpringX.Update(Time.deltaTime);
		morphSpringY.Update(Time.deltaTime);
	}
}
