using UnityEngine;

public class Game : MonoBehaviour
{
	private static Player player;

	private static Game instance;

	protected int deaths = 0;

	[SerializeField]
	protected float respawnTime = 3f;

	void Awake()
	{
		instance = this;
		deaths = 0;
		player = FindFirstObjectByType<Player>();
	}


	public static void HandlePlayerDeath()
	{
		// Repsawn after a delay
		instance.Invoke("RespawnPlayer", instance.respawnTime);
		instance.deaths++;
	}

	protected void RespawnPlayer()
	{
		CancelInvoke();
		player.RestoreFromCheckpoint();
	}

	public static int GetDeathCount()
	{
		return instance.deaths;
	}

}
