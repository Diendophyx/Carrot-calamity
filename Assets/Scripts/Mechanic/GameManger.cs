using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public PlayerStates playerStates;
    public Collecting collecting;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerStates.health == 0)
        {
            SceneManager.LoadScene(0);
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        else if(collecting.Score == 26)
        {
            SceneManager.LoadScene(2);
        }
    }
}
