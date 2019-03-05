using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public float health;
    public void Start()
    {
        health = 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trap" || other.gameObject.tag == "Fox")
        {
            
            health = 0;
        }
    }



}
