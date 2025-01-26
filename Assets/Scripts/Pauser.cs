using UnityEngine;

public class Pauser : MonoBehaviour
{
	protected GameObject pauseMenu;

	void Awake()
	{
		Unpause();
	}

	public void Pause()
	{
		Time.timeScale = 0f;
	}

	public void Unpause()
	{
		Time.timeScale = 1f;
	}
}
