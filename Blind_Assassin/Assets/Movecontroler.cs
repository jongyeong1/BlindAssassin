/* 2016039029 이종영
 * 캐릭터 이동에 대한 정보 스크립트 하나에 모든 게임오브젝트 설정 적용대신
 * 하나의 오브젝트당 하나의 스크립트를 두어 객체화 시키는데 의의를 둠
 * 기본적인 알고리즘은 같은 이름 공유시 동일함
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecontroler : MonoBehaviour
{
    static public int life = 3;            // 캐릭터 생명력  
    public GameObject player;              // 캐릭터 게임오브젝트 지정
    static public int action = 0;          // 캐릭터 액션 설정
    [SerializeField] 
    CharacterController cc;                // 캐릭터 컨트롤러 설정 y축 값
    
    public float speed = 3.0F;             // z축 이동속도 디폴트 3
    public float jumpSpeed = 4.0F;         // y축 이동속도 디폴트4
    public float gravity = 9.81F;          // 중력 부여 


  
    private Vector3 moveDirection = Vector3.zero;       // 캐릭터 움직임값 변수 설정
    void Update()
    {
        if (cc.isGrounded) // 길위에 존재할 경우
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 30f);  // 기본 이동속도 z 30 y 중력에 비례
            moveDirection = transform.TransformDirection(moveDirection);       // 백터에 따른 방향 제공 ( 일직선 이동이니 사용x)
            
            if (Input.GetButton("Jump"))                                       // 함정 피하기 동작 부여                  
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;                           // y축에 대해 항상 중력값 부여

        if(Input.GetKey(KeyCode.UpArrow))                                      // 숙일시
        {
            moveDirection = new Vector3(0, 0, 0);                              // 멈춤
            action = 1;                                                        // 통나무 회피 값으로 action 설정
        }
        cc.Move(moveDirection * Time.deltaTime);                              // 캐릭터 움직임
    }
}

