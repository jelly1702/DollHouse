using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAudio : MonoBehaviour
{
    public GameObject trapAudio;
    private bool hasActivated = false;

    void OnTriggerExit(Collider other)
    {
        if (!hasActivated && other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (trapAudio != null && !trapAudio.activeSelf)
            {
                trapAudio.SetActive(true);
                hasActivated = true;
            }
        }
    }
}
