/*2016039005 최윤성
 *unity 예제 과제
 *3d 평면 상에서 캐릭터가 전후좌우로 움직이며,
 *나아갈 방향을 애니메이션으로 보여주게 설정해봄*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float MoveSpeed; //속도 선언
    Vector3 lookDirection;  //보는 방향 선언

    void FixedUpdate() {
        this.transform.Translate(0, 1, 0);
        this.transform.Translate(0, -1, 0);

    }
    void Update()
    {
        if (
            
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow))    //각 방향의 키코드를 받는다면,
        {
            float xx = Input.GetAxisRaw("Vertical");    
            float zz = Input.GetAxisRaw("Horizontal");
            lookDirection = xx * Vector3.forward + zz * Vector3.right; //Forward와 Right값에 각각 키보드 값을 곱하여 방향 설정

            this.transform.rotation = Quaternion.LookRotation(lookDirection);   //주어진 방향을 통해 쳐다본 캐릭터를 돌리고, 
            this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);//그 방향으로 나아가게 하는 구문
        }
        this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);

    }
}
