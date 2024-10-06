using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public float cameraSpeed = 10f;  // ī�޶� �̵� �ӵ�
    public Transform character;  // ĳ������ Transform�� ����
    private Vector3 targetPosition;  // ī�޶� ��ǥ ��ġ

    private void Start()
    {
        // ī�޶��� �ʱ� ��ġ�� ĳ���� ��ġ�� ���߰� Z���� ����
        targetPosition = new Vector3(character.position.x, character.position.y, -10);
    }

    private void Update()
    {
        // LeftControl Ű�� ������ ī�޶� ���⿡ ���� �̵�
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                targetPosition += new Vector3(-cameraSpeed * Time.deltaTime, 0, 0); // ����
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                targetPosition += new Vector3(cameraSpeed * Time.deltaTime, 0, 0); // ������
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                targetPosition += new Vector3(0, cameraSpeed * Time.deltaTime, 0); // ����
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                targetPosition += new Vector3(0, -cameraSpeed * Time.deltaTime, 0); // �Ʒ���
            }
        }

        // ī�޶� ��ǥ ��ġ�� �ε巴�� �̵�
        MoveCamera();
    }

    void MoveCamera()
    {
        // ī�޶� ��ǥ ��ġ�� �ε巴�� �̵�
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    }
}
