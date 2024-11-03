using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class Door : MonoBehaviour, IInteractable
    {
        public float openHeight = 1f; // ������ ���� ����
        public float moveSpeed = 2f;   // �̵� �ӵ�
        private bool isOpened = false;    // �� ���� ���� Ȯ��
        private Vector3 openPosition;    // ������ ���� ��ǥ ��ġ

        private void Start()
        {
            // ���� ���·� �ʱ�ȭ
            openPosition = new Vector3(transform.position.x, transform.position.y + openHeight, transform.position.z);
        }

        public void Interact()
        {
            if (!isOpened)
            {
                isOpened = true; // ���� �� ���·� ����
                Debug.Log("���� ���Ƚ��ϴ�!");
            }
        }

        private void Update()
        {
            // ���� ���� ���� �̵�
            if (isOpened)
            {
                // ���� ��ġ�� ��ǥ ��ġ�� ���Ͽ� �̵�
                transform.position = Vector3.MoveTowards(transform.position, openPosition, moveSpeed * Time.deltaTime);

                if (transform.position.y >= openPosition.y)
                {
                    // ���� ������ ������ ���� ó��
                    transform.position = openPosition; // ��ǥ ��ġ�� ��Ȯ�� ��ġ

                }
            }
        }
    }
}
