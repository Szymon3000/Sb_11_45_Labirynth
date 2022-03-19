using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform player;
    public Transform receiver;
    private bool playerIsOverlapping = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            playerIsOverlapping = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
    private void FixedUpdate()
    {
        Teleport_f();
    }
    private void Teleport_f()
    {
        if(playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            if(dotProduct>0f)
            {
                /*float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);*/
                Vector3 positionOffset = Quaternion.Euler(0f, 0f, 0f) * portalToPlayer;
                player.position = receiver.position + positionOffset;
                playerIsOverlapping = false;
            }
        }
    }
}
