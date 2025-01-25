using UnityEngine;

public class Game : MonoBehaviour
{
	private static Player player;

	private static Game instance;

	[SerializeField]
	protected float respawnTime = 3f;

	void Awake()
	{
		instance = this;
		player = FindFirstObjectByType<Player>();
	}


	public static void HandlePlayerDeath()
	{
		// Repsawn after a delay
		instance.Invoke("RespawnPlayer", instance.respawnTime);
	}

	protected void RespawnPlayer()
	{
		CancelInvoke();
		player.RestoreFromCheckpoint();
	}

}
