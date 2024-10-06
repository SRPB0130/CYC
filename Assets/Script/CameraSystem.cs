using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSystem : MonoBehaviour
{
    public float cameraSpeed = 10f;
    public Transform character;

    private Vector3 targetposition;


    //private void Start()
    //{
    //    // ī�޶��� �ʱ� ��ġ�� ĳ���� ��ġ�� ���߰� Z���� ����
    //    targetposition = new Vector3(character.position.x, character.position.y, -10);
    //}

    private void Update()
    {
        // �⺻������ ī�޶��� ��ǥ ��ġ�� ĳ������ ��ġ�� ����
        targetposition = new Vector3(character.position.x, character.position.y, -10);

        // LeftControl Ű�� ������ ī�޶� �������� �̵�
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                targetposition += new Vector3(-9, 0, -10);  // �������� �̵�
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                targetposition += new Vector3(9, 0, -10);  // ���������� �̵�
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                targetposition += new Vector3(0, 6, -10);  // �������� �̵�
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                targetposition += new Vector3(0, -6, -10);  // �Ʒ������� �̵�
            }
        }

        
        MoveCamera();
    }

    void MoveCamera()
    {
        //ī�޶� ���� �������� ������
        transform.position = Vector3.Lerp(transform.position, targetposition, cameraSpeed * Time.deltaTime);
    }
}
