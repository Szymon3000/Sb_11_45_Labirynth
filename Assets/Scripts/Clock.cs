using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUps
{
    public bool addTime; //true - dodaje czas, false-odejmuje czas
    public int time = 5;
    public override void Picked()
    {
        if(addTime)
        {
            GameManager.gameManager.AddTime(time);
            GameManager.gameManager.PlayClip(pickedClip);
        }
        else
        {
            GameManager.gameManager.AddTime(time * (-1));
        }
        Destroy(this.gameObject);
    }
}
