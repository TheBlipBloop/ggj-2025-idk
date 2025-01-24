using UnityEngine;
using UnityEngine.Events;

public class BlockableWind : MonoBehaviour
{
	[SerializeField]
	protected LayerMask layers;

	[SerializeField]
	protected float windForce = 10f;

	[SerializeField]
	protected float windLength = 5.0f;

	[SerializeField]
	protected float windWidth = 1.0f;

	const int WIND_ITERATIONS = 3;

	RaycastHit2D[] windHits;

	void Awake()
	{
		windHits = new RaycastHit2D[WIND_ITERATIONS];
	}

	// Update is called once per frame
	void Update()
	{
		WindCast(ref windHits);
		for (int i = 0; i < windHits.Length; i++)
		{
			if (windHits[i].rigidbody)
			{
				windHits[i].rigidbody.AddForceAtPosition(transform.up * windForce / WIND_ITERATIONS, windHits[i].point);
			}
		}
	}

	public void OnDrawGizmos()
	{
		for (float windOffset = -windWidth / 2f; windOffset < windWidth / 2f; windOffset += windWidth / WIND_ITERATIONS)
		{
			Vector3 origin = transform.position + transform.right * windOffset;
			Gizmos.color = Color.green;
			Gizmos.DrawLine(origin, origin + transform.up * windLength);
		}
	}

	protected void WindCast(ref RaycastHit2D[] hits)
	{
		int i = 0;
		for (float windOffset = -windWidth / 2f; windOffset < windWidth / 2f; windOffset += windWidth / WIND_ITERATIONS)
		{
			Vector3 origin = transform.position + transform.right * windOffset;
			hits[i] = Physics2D.Raycast(origin, transform.up, windLength, layers.value);
			i++;
		}
	}

	private bool IsPlayer(Collision2D collision2D)
	{
		return collision2D != null && collision2D.gameObject;//&& collision2D.gameObject.layer == playerLayerMask;
	}
}
