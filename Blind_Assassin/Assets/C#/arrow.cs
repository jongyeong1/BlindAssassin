using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{

    public int damage = 1;                             //데미지

    public float speed = 100.0f;                           //속도
    public bool call = true;                   //움직이려면 true로
    float fOldTime = 0f;
    public int dir = 0;                        //방향 1이면 플레이어 기준 왼쪽 2이면 오른쪽으로 판단
    Transform Target;      //플레이어의 위치 저장
    float angle;

    public AudioSource Sound_effect1, Sound_effect2;        //효과음 저장

    // Start is called before the first frame update
    void Start()
    {   if(dir == 1)        //왼쪽일 경우
        {
            Sound_effect1 = GameObject.Find("Bow_left").GetComponent<AudioSource>();
        }
        else if(dir == 2)   //오른쪽일 경우
        {
            Sound_effect1 = GameObject.Find("Bow_right").GetComponent<AudioSource>();
        }
        
        }
  
  

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z != -3000)              //z가 -3000이 아니면 발사함
        {
            Sound_effect1.Play();

            Target = GameObject.Find("Player").transform;
            
            Vector3 direction = (transform.position - Target.position).normalized;   //내적

          

            transform.position -= direction * speed * Time.deltaTime;               //해당 방향으로 힘을줌
            
            if ((transform.position - Target.position).magnitude < 5||GameObject.Find("Character").GetComponent<Movecontroler>().hp <=0)                //화살과 플레이어 간의 거리가 5이면
            {   
                //////////////////////////// 히트 판정
                if ((GameObject.Find("Character").GetComponent<Movecontroler>().Action) != dir)   //액션이 일치 하지 않는다면
                    GameObject.Find("Character").GetComponent<Movecontroler>().hp--;                  //체력 감소
                
                Destroy(gameObject);                                                //제거
            }
        
}
    }
}
