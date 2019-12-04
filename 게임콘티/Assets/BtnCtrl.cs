using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnCtrl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool isBtnDown = false;
    Vector3 lookDirection;
    private void Update()
    {
        if (isBtnDown)////누르고 있을 동안의 변수값 변경
        {

            float xx = Input.GetAxisRaw("Vertical");
            float zz = Input.GetAxisRaw("Horizontal");
            lookDirection = xx * Vector3.forward + zz * Vector3.right;
            this.transform.rotation = Quaternion.LookRotation(lookDirection);
            Debug.Log("BTN DOWN");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnDown = false;
    }

}

