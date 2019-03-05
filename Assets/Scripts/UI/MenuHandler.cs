using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void Exit()
    {  
       Application.Quit();
        Debug.Log("working");
    }

    public void Play()
    {
        SceneManager.LoadScene("Level01", LoadSceneMode.Single);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
