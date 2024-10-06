using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public float cameraSpeed = 10f;  // 카메라 이동 속도
    public Transform character;  // 캐릭터의 Transform을 연결
    private Vector3 targetPosition;  // 카메라 목표 위치

    private void Start()
    {
        // 카메라의 초기 위치를 캐릭터 위치에 맞추고 Z축을 고정
        targetPosition = new Vector3(character.position.x, character.position.y, -10);
    }

    private void Update()
    {
        // LeftControl 키를 누르면 카메라가 방향에 따라 이동
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                targetPosition += new Vector3(-cameraSpeed * Time.deltaTime, 0, 0); // 왼쪽
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                targetPosition += new Vector3(cameraSpeed * Time.deltaTime, 0, 0); // 오른쪽
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                targetPosition += new Vector3(0, cameraSpeed * Time.deltaTime, 0); // 위쪽
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                targetPosition += new Vector3(0, -cameraSpeed * Time.deltaTime, 0); // 아래쪽
            }
        }

        // 카메라를 목표 위치로 부드럽게 이동
        MoveCamera();
    }

    void MoveCamera()
    {
        // 카메라를 목표 위치로 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    }
}
