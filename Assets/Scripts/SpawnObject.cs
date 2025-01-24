using UnityEngine;

public class SpawnObject : MonoBehaviour
{
	[SerializeField]
	protected GameObject prefab;

	[SerializeField]
	protected bool onStart = false;

	void Start()
	{
		if (onStart)
		{
			Spawn();
		}
	}

	public void Spawn()
	{
		Instantiate(prefab, transform.position, transform.rotation);
	}
}
