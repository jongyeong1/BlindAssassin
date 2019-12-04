using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecontroler : MonoBehaviour
{
    static public int life = 3;
    public GameObject player;
    static public int action = 0;
    [SerializeField]
    CharacterController cc;

    public float speed = 3.0F;
    public float jumpSpeed = 4.0F;
    public float gravity = 9.81F;

    public int Action = 0;      //행동    0은 가만히 1은 왼막 2는 오른막 3은 웅크림
    public int hp = 3;          //체력

    private Vector3 moveDirection = Vector3.zero;
    void Update()
    {
        if (cc.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        cc.Move(moveDirection * Time.deltaTime);
    }
}

