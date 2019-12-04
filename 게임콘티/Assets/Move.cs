
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    static public int life = 3;
    public GameObject player;
    static public int action = 0;
    /*  public float MoveSpeed; //속도 선언
      Vector3 lookDirection;  //보는 방향 선언

      void FixedUpdate() {
          this.transform.Translate(0, 1, 0);
          this.transform.Translate(0, -1, 0);

      }
      void Update()
      {
          if (Input.GetKey(KeyCode.UpArrow))   //각 방향의 키코드를 받는다면,
          {
              float xx = Input.GetAxisRaw("Vertical");    
              float zz = Input.GetAxisRaw("Horizontal");
              lookDirection = xx * Vector3.forward + zz * Vector3.right; //Forward와 Right값에 각각 키보드 값을 곱하여 방향 설정

            //  this.transform.rotation = Quaternion.LookRotation(lookDirection);   //주어진 방향을 통해 쳐다본 캐릭터를 돌리고, 
              this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);//그 방향으로 나아가게 하는 구문
          }

              this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);

      }*/

    [SerializeField]
    CharacterController cc;

    public float speed = 3.0F;
    public float jumpSpeed = 4.0F;
    public float gravity = 9.81F;
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
