using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float gravity;
    public CharacterController controller;
    private Vector3 dir;
    Transform player;
    
    void Start()
    {
        player = GetComponent<Transform>();
    }

    void Update()
    {

        float inputX = Input.GetAxis("Horizontal");
        float inputy = Input.GetAxis("Vertical");
        GameObject test = GameObject.FindWithTag("spawnPoint");
        dir.y -= gravity * Time.deltaTime;
        dir.x = inputX * speed;
        controller.Move(dir * Time.deltaTime);
        if (controller.isGrounded)
        {
            if (Input.GetKey("w"))
                dir.y = jumpSpeed;
        }

        if (player.transform.localPosition.y < -10)
        {
            test.SendMessage("Die",1);
        }
            




    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        GameObject test = GameObject.FindWithTag("spawnPoint");
        if (hit.gameObject.tag == "dangerous")
        {
            test.SendMessage("Die", 1);
        }
    }
}
