using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    bool iCanOpen = false;
    public DoorScript door;
    public KeyColor myKeyColor;
    bool locked = false;
    Animator key;
    private void Start()
    {
        key = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&&iCanOpen==true&&locked==false)
        {
            key.SetBool("UseKey", CheckTheKey());
        }
    }
    public void UseKey()
    {
        door.CloseOpen();
    }
    public bool CheckTheKey()
    {
        if(GameManager.gameManager.redKey>0 && myKeyColor==KeyColor.Red)
        {
            locked = true;
            GameManager.gameManager.redKey--;
            return true;
        }
        else if (GameManager.gameManager.greenKey > 0 && myKeyColor == KeyColor.Green)
        {
            locked = true;
            GameManager.gameManager.greenKey--;
            return true;
        }
        else if (GameManager.gameManager.goldKey > 0 && myKeyColor == KeyColor.Gold)
        {
            locked = true;
            GameManager.gameManager.goldKey--;
            return true;
        }
        else
        {
            Debug.Log("No Key!!!");
            return false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = true;
            Debug.Log("Can use lock!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = false;
            Debug.Log("Can't use lock!");
        }
    }
}
