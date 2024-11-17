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
                isOpened = true; // ���� ���¸� �������� ����
                animator.SetBool("IsOpened", isOpened);

                Debug.Log("���ڰ� ���Ƚ��ϴ�!");

                StartCoroutine(SpawnItemWithDelay());
            }
        }
        private IEnumerator SpawnItemWithDelay()
        {
            // ������ �ð���ŭ ���
            yield return new WaitForSeconds(delayTime);

            // ������ ����
            Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);

            Debug.Log("�������� �����Ǿ����ϴ�!");
        }
    }
}
