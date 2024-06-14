using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    // �������� ��Ÿ���� Light ������Ʈ�� ������ ����
    public Light flashlight;

    // �������� �ʱ� ���� (����/����)�� ������ ����
    private bool isOn = false;

    // ����� ī�޶� ������ ����
    public Camera flashlightCamera;

    // �� �����Ӹ��� ȣ��Ǵ� �Լ�
    void Update()
    {
        // F Ű�� ������ �� �������� ���¸� ���
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashlight();
        }

        // �������� ���� �ִ� ������ ���� ���콺�� ���󰡰� ��
        if (isOn)
        {
            FollowMouse();
        }
    }

    // �������� ���¸� ����ϴ� �Լ�
    void ToggleFlashlight()
    {
        // ���� ���¸� �ݴ�� ����
        isOn = !isOn;

        // �������� Ȱ��ȭ ���¸� ����� ���¿� �°� ����
        flashlight.enabled = isOn;
    }

    // ���콺�� ���� �������� ȸ����Ű�� �Լ�
    void FollowMouse()
    {
        if (flashlightCamera == null)
        {
            Debug.LogWarning("Flashlight camera is not assigned.");
            return;
        }

        // ���콺 ��ġ�� �������� ���̸� ����
        Ray ray = flashlightCamera.ScreenPointToRay(Input.mousePosition);

        // ����ĳ��Ʈ ��Ʈ�� ������ ����
        RaycastHit hit;

        // ����ĳ��Ʈ�� ��Ʈ���� ���
        if (Physics.Raycast(ray, out hit))
        {
            // �������� ������ ����ĳ��Ʈ ��Ʈ ����Ʈ�� ����
            Vector3 targetDirection = hit.point - flashlight.transform.position;

            // �������� ������ Ÿ�� �������� ȸ��
            flashlight.transform.rotation = Quaternion.LookRotation(targetDirection);
        }
    }
}