using UnityEditor;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
	public void Quit()
	{
#if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
#else
		Application.Quit();
#endif
	}
}
