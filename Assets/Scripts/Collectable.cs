using UnityEngine;

public class Collectable : MonoBehaviour
{
	[Header("Bob Animation")]

	[SerializeField]
	protected float bobHeight = 0.5f;

	[SerializeField]
	protected float bobSpeed = 4f;

	protected Vector3 initialPosition;

	void Awake()
	{
		initialPosition = transform.position;
	}

	private void Update()
	{
		float offset = Mathf.Sin(Time.time * bobSpeed) * bobHeight;
		transform.position = initialPosition + Vector3.up * offset;
	}

	public void Collect(Player player)
	{
		player.GetComponent<Collector>().Collect(this);
	}
}
