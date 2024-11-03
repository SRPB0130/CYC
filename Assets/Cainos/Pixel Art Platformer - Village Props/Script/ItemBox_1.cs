using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtPlatformer_VillageProps
{
    public class ItemBox_1 : MonoBehaviour, IInteractable
    {
        public GameObject itemPrefab;
        public Transform spawnPoint;
        private bool isOpened = false;

        public void Interact()
        {
            if (!isOpened)
            {
                isOpened = true; // ���� ���¸� �������� ����
                Debug.Log("���ڰ� ���Ƚ��ϴ�!");

                // ������ ����
                Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}
