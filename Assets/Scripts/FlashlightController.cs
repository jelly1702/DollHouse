using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Light flashlight;
    private bool isOn = true;
    public Camera flashlightCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashlight();
        }

        if (isOn)
        {
            FollowMouse();
        }
    }

    void ToggleFlashlight()
    {
        isOn = !isOn;
        flashlight.enabled = isOn;
    }

    void FollowMouse()
    {
        Ray ray = flashlightCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetDirection = hit.point - flashlight.transform.position;

            flashlight.transform.rotation = Quaternion.LookRotation(targetDirection);
        }
    }
}