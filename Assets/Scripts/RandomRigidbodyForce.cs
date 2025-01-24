using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RandomRigidbodyForce : MonoBehaviour
{
	[SerializeField]
	protected Rigidbody2D body;

	[SerializeField]
	protected float linearForceScale = 10f;

	[SerializeField]
	protected float torqueScale = 100f;

	void Awake()
	{
		body.AddForce(Random.insideUnitCircle * linearForceScale, ForceMode2D.Impulse);
		body.AddTorque(Random.value * torqueScale);
	}
}
