using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 12f;
    CharacterController characterController;
    public Transform groundCheck;
    public LayerMask groundMask;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        // -1, gdy idziemy w lewo; 1, gdy idziemy w prawo
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Vector3 move = Vector3.right * x + Vector3.forward * z;
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        RaycastHit hit;
        if(Physics.Raycast(groundCheck.position,
            transform.TransformDirection(Vector3.down),
            out hit,
            0.4f,
            groundMask)
            )
        {
            string terrainType = hit.collider.gameObject.tag;

            switch (terrainType)
            {
                case "Slow":
                    speed = 3f;
                    break;
                case "Fast":
                    speed = 20f;
                    break;
                default:
                    speed = 12f;
                    break;
            }
        }
    }
    //OnCollisonEnter
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag=="PickUps")
        {
            hit.gameObject.GetComponent<PickUps>().Picked();
        }
    }
}
