using UnityEngine;
using UnityEngine.Events;

public class BlockableWind : MonoBehaviour
{
	[SerializeField]
	protected LayerMask layers;

	[SerializeField]
	protected float airPerSecond = 1f;

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
			if (IsPlayer(windHits[i].collider) && windHits[i].collider.transform.parent != null)
			{
				Player player = windHits[i].collider.transform.parent.GetComponent<Player>();
				player.GetBubble().AddAir(airPerSecond * Time.deltaTime / WIND_ITERATIONS);
				print("asdasdasasd asd ");
			}
		}
	}

	public void OnDrawGizmos()
	{
		for (float windOffset = -windWidth / 2f; windOffset <= windWidth / 2f; windOffset += windWidth / (WIND_ITERATIONS - 1))
		{
			Vector3 origin = transform.position + transform.right * windOffset;
			Gizmos.color = Color.green;
			Gizmos.DrawLine(origin, origin + transform.up * windLength);
		}
	}

	protected void WindCast(ref RaycastHit2D[] hits)
	{
		int i = 0;
		for (float windOffset = -windWidth / 2f; windOffset < windWidth / 2f; windOffset += windWidth / (WIND_ITERATIONS - 1))
		{
			Vector3 origin = transform.position + transform.right * windOffset;
			hits[i] = Physics2D.Raycast(origin, transform.up, windLength, layers.value);
			i++;
		}
	}

	private bool IsPlayer(Collider2D collider2D)
	{
		return collider2D != null && collider2D.gameObject.layer == 3;
	}

	protected virtual void EffectPlayer(Player player)
	{

	}
}
