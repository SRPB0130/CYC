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
                isOpen = true; // 상자 상태를 열림으로 변경
                Debug.Log("상자가 열렸습니다!");

                // 아이템 생성
                Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}
