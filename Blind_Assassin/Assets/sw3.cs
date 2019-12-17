/* 2016039029 이종영
 * 우측 막기 에 대한 정보 스크립트 하나에 모든 게임오브젝트 설정 적용대신
 * 하나의 오브젝트당 하나의 스크립트를 두어 객체화 시키는데 의의를 둠
 * 기본적인 알고리즘은 같은 이름 공유시 동일함
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class sw3 : MonoBehaviour
{
    public GameObject rightshiled;                    // 우측 막기 애니메이션 적용 게임오브젝트
    public GameObject kata;                           // 자식오브젝트 중 검
    public GameObject hand;                           // 자식오브젝트 중 팔뚝
    public RuntimeAnimatorController ss;              // 에니메이터 연속수행 좌측막기 

    bool bb = false;                                  // 동작수행 여부

    public Animator ani;                              // 애니메이터 우측막기

    void Update()
    {
        if (Movecontroler.action==3)                  // 우측손 동작시 
        {
         
            kata.GetComponent<Renderer>().enabled = false;      // 동작수행전 랜더링 돌려주기 작업
            hand.GetComponent<Renderer>().enabled = true;

            bb = true;                                         // 애니메이터 동작 수행 
        }
        else
        {

            if (Movecontroler.action == 2)
            {
                bb = false;
            }
            else
            {
                kata.GetComponent<Renderer>().enabled = false;     // 랜더링 하이드
                hand.GetComponent<Renderer>().enabled = false;
                bb = false;                                        // 애니메이터 동작 대기
            }
        }

        ani.SetBool("right", bb);                              // bb를 애니메이터 동작 조건 right로 지정



    }
}
