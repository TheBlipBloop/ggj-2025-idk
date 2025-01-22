using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField]
	protected Transform target;

	[SerializeField]
	protected float followSpeed = 5f;

	[SerializeField]
	protected Vector3 offset = new Vector3(0, 0, -10f);

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		target = FindFirstObjectByType<Player>().transform;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		Vector3 targetPosition = target.position + offset;
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * followSpeed);
	}
}
