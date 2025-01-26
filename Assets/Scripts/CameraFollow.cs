using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField]
	protected Transform target;

	[SerializeField]
	protected float followSpeed = 5f;

	[SerializeField]
	protected float mouseLookWeight = 0.1f;///jankykykykyyk

	[SerializeField]
	protected Vector3 offset = new Vector3(0, 0, -10f);
	protected Vector3 mouseOffset;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		target = FindFirstObjectByType<Player>().transform;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		Vector3 targetPosition = target.position + offset;
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		// mouseOffset = mousePosition - targetPosition;
		// mouseOffset = new Vector3(mouseOffset.x, mouseOffset.y, 0f);
		// mouseOffset = Vector3.ClampMagnitude(mouseOffset, mouseLookDistance);



		transform.position = Vector3.MoveTowards(transform.position, Vector3.Lerp(targetPosition, mousePosition, mouseLookWeight), Time.deltaTime * followSpeed);
	}
}
