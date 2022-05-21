using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : GameManager
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("You are dead!");
        PauseGame();
    }
}
