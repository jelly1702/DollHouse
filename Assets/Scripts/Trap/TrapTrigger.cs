using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    // �ߵ��� ���� ������Ʈ�� �ν����Ϳ��� ������ ����
    public GameObject trapObject;

    void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� ���̾ �÷��̾� ���̾��� ���
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // ���� ������Ʈ�� ��Ȱ��ȭ ���¶�� Ȱ��ȭ
            if (trapObject != null && !trapObject.activeSelf)
            {
                trapObject.SetActive(true);
            }
        }
    }
}
