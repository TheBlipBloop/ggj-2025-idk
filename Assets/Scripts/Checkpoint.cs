using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	[SerializeField]
	protected Transform spawnPoint;

	[SerializeField]
	protected GameObject inactiveCheckpointGraphics;

	[SerializeField]
	protected GameObject activeCheckpointGraphics;

	void AWake()
	{
		SetGraphicsEnable(false);
	}

	public virtual void EnableCheckpoint(Player player)
	{
		player.SetCheckpointPosition(spawnPoint.position);
		SetGraphicsEnable(true);
	}

	protected void SetGraphicsEnable(bool active)
	{
		inactiveCheckpointGraphics.SetActive(!active);
		activeCheckpointGraphics.SetActive(active);
	}

	// protected bool GetActive
}
