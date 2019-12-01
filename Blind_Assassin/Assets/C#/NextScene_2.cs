using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//트랩을 밟는 순간 부터 랜덤으로 arrow 생성(통나무도 할 수 있으면 구현 하는게 좋을듯)
public class NextScene_2 : MonoBehaviour
{
    public Vector3 pos;
    public bool key = false;            // Trap 작동      게임 종료나 맵 끝에 도착하면 false로 다시 바꾸어주면 된다.

    Transform Target;
    GameObject NextCube;


    // Start is called before the first frame update
    void Start()
    {

    }

    

    // Update is called once per frame
    void Update()

    {
        Target = GameObject.Find("Character").transform;          //플레이어의 좌표 받기

        if ((transform.position - Target.transform.position).magnitude <= 40)      //trap과 간격이 2 이하(거의 밟음) 즉 밟으면
        {
            key = true;
        }

        

        if (key)  //player 통나무 소환시 쉬어야함
        {
            SceneManager.LoadScene("FinalStep");

        }
       

    }
}