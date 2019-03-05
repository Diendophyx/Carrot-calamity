using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool pause;
    public GameObject pauseMenu;

    // Use this for initialization
    void Start()
    {
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pause = !pause;
        }
        if(pause)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
        }
    }
   
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
