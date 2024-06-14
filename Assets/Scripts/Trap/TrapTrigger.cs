using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    // 발동할 함정 오브젝트를 인스펙터에서 설정할 변수
    public GameObject trapObject;
    private bool hasActivated = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasActivated && other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (trapObject != null && !trapObject.activeSelf)
            {
                trapObject.SetActive(true);
                hasActivated = true;
            }
        }
    }
}
