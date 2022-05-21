using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHelpScript : MonoBehaviour
{
    [SerializeField] public float speed = 1f;
    public Transform trap;
    public Transform goingUpPosition;
    public GameObject floor;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You entered trap help collider!");
        GetComponent<Collider>().enabled = false;
        //floor.GetComponent<Collider>().enabled = false;
        Destroy(floor.gameObject); 
        trap.position = Vector3.MoveTowards(trap.position, goingUpPosition.position, Time.deltaTime * speed);
    }
}
