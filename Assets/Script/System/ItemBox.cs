using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class ItemBox : MonoBehaviour, IInteractable
    {
        public GameObject itemPrefab;
        public Transform spawnPoint;
        private bool isOpened = false;
        private Animator animator;
        public float delayTime = 0.5f;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Interact()
        {
            if (!isOpened)
            {
                isOpened = true; // 상자 상태를 열림으로 변경
                animator.SetBool("IsOpened", isOpened);

                Debug.Log("상자가 열렸습니다!");

                StartCoroutine(SpawnItemWithDelay());
            }
        }
        private IEnumerator SpawnItemWithDelay()
        {
            // 지정된 시간만큼 대기
            yield return new WaitForSeconds(delayTime);

            // 아이템 생성
            Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);

            Debug.Log("아이템이 생성되었습니다!");
        }
    }
}
