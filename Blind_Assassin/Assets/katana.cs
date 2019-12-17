/* 2016039029 이종영
 * 메인화면 카타나 에 대한 정보 스크립트 하나에 모든 게임오브젝트 설정 적용대신
 * 하나의 오브젝트당 하나의 스크립트를 두어 객체화 시키는데 의의를 둠
 * 기본적인 알고리즘은 같은 이름 공유시 동일함
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class katana : MonoBehaviour
{
    public GameObject righthands;     // 카타나를 쥐고 있는 오른손을 기준으로 적용한다. 

    void Update()
    {



        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))  // 기본동작 외의 동작이 실행될시
        {

            righthands.GetComponent<Renderer>().enabled = false;                  // 랜더링 하이드 


        }
        else 
        {
            righthands.GetComponent<Renderer>().enabled = true;                   // 랜더링 팝
        }



    }
}
