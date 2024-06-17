using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Light flashlight;
    public Camera flashlightCamera;
    public bool followMouse = true;
    public LayerMask raycastLayerMask;

    private bool isOn = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashlight();
        }

        if (isOn && followMouse)
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

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, raycastLayerMask))
        {
            Vector3 targetDirection = hit.point - flashlight.transform.position;
            flashlight.transform.rotation = Quaternion.LookRotation(targetDirection);
        }
    }
}