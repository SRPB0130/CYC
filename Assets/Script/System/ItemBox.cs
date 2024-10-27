using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class ItemBox : MonoBehaviour, IInteractable
    {
        public GameObject itemPrefab;
        public Transform spawnPoint;
        private bool isOpen = false;

        public void Interact()
        {
            if (!isOpen)
            {
                isOpen = true; // ���� ���¸� �������� ����
                Debug.Log("���ڰ� ���Ƚ��ϴ�!");

                // ������ ����
                Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}
