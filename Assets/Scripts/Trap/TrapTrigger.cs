using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
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
