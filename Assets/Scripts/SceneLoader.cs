using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	[SerializeField]
	protected string sceneName;

	public void LoadScene()
	{
		LoadScene(sceneName);
	}

	public void LoadScene(string name)
	{
		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}
}
