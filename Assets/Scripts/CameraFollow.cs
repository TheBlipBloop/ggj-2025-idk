using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField]
	protected Transform target;

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
		transform.position = target.position + offset;
	}
}
