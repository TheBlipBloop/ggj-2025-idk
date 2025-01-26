using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    protected GameObject pauseMenu;

    [SerializeField]
    protected Pauser pauser;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);

            if (pauseMenu.activeSelf)
            {
                pauser.Pause();
            }
            else
            {
                pauser.Unpause();
            }
        }

    }
}
