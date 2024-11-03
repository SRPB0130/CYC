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
                isOpened = true; // 상자 상태를 열림으로 변경
                Debug.Log("상자가 열렸습니다!");

                // 아이템 생성
                Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}
