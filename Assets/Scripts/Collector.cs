using UnityEngine;

public class Collector : MonoBehaviour
{
	// evil
	private static Collector instance;

	private static int maxCollectables;

	[SerializeField]
	protected int collectables = 0;

	void Awake()
	{
		instance = this;
		maxCollectables = FindObjectsByType<Collectable>(FindObjectsSortMode.None).Length;
	}

	public void Collect(Collectable collectable)
	{
		Destroy(collectable.gameObject);
		collectables++;
	}

	public static int GetCurrentCollectables()
	{
		return instance.collectables;
	}

	public static int GetMaxCollectables()
	{
		return maxCollectables;
	}
}
