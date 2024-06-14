using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    // 발동할 함정 오브젝트를 인스펙터에서 설정할 변수
    public GameObject trapObject;

    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트의 레이어가 플레이어 레이어일 경우
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // 함정 오브젝트가 비활성화 상태라면 활성화
            if (trapObject != null && !trapObject.activeSelf)
            {
                trapObject.SetActive(true);
            }
        }
    }
}
