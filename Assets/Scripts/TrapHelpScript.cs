using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHelpScript : MonoBehaviour
{
    [SerializeField] public float speed = 1f;
    public Transform trap;
    public Transform goingUpPosition;
    public GameObject floor;
    public bool activated=false;
    void Start()
    {
        
    }
    void Update()
    {
        if(activated)
        {
            trap.position = Vector3.MoveTowards(trap.position, goingUpPosition.position, Time.deltaTime * speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You entered trap help collider!");
        GetComponent<Collider>().enabled = false;
        //floor.GetComponent<Collider>().enabled = false;
        Destroy(floor.gameObject);
        activated = true;
    }
}
