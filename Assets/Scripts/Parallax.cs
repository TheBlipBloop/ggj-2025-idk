using UnityEngine;

public class Parallax : MonoBehaviour
{
	[SerializeField]
	protected float distance;

	protected Vector2 initialPosition;

	protected Camera mainCamera;

	private void Awake()
	{
		initialPosition = transform.position;
		mainCamera = Camera.main;
	}

	private void Update()
	{
		// mainCamera.transform.
	}

}
