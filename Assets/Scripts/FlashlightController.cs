using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    // 손전등을 나타내는 Light 컴포넌트를 저장할 변수
    public Light flashlight;

    // 손전등의 초기 상태 (켜짐/꺼짐)를 설정할 변수
    private bool isOn = false;

    // 사용할 카메라를 저장할 변수
    public Camera flashlightCamera;

    // 매 프레임마다 호출되는 함수
    void Update()
    {
        // F 키를 눌렀을 때 손전등의 상태를 토글
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashlight();
        }

        // 손전등이 켜져 있는 상태일 때만 마우스를 따라가게 함
        if (isOn)
        {
            FollowMouse();
        }
    }

    // 손전등의 상태를 토글하는 함수
    void ToggleFlashlight()
    {
        // 현재 상태를 반대로 변경
        isOn = !isOn;

        // 손전등의 활성화 상태를 변경된 상태에 맞게 설정
        flashlight.enabled = isOn;
    }

    // 마우스를 따라 손전등을 회전시키는 함수
    void FollowMouse()
    {
        if (flashlightCamera == null)
        {
            Debug.LogWarning("Flashlight camera is not assigned.");
            return;
        }

        // 마우스 위치를 기준으로 레이를 생성
        Ray ray = flashlightCamera.ScreenPointToRay(Input.mousePosition);

        // 레이캐스트 히트를 저장할 변수
        RaycastHit hit;

        // 레이캐스트가 히트했을 경우
        if (Physics.Raycast(ray, out hit))
        {
            // 손전등의 방향을 레이캐스트 히트 포인트로 설정
            Vector3 targetDirection = hit.point - flashlight.transform.position;

            // 손전등의 방향을 타겟 방향으로 회전
            flashlight.transform.rotation = Quaternion.LookRotation(targetDirection);
        }
    }
}