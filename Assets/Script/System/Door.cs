using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class Door : MonoBehaviour, IInteractable
    {
        public float openHeight = 1f; // 열렸을 때의 높이
        public float moveSpeed = 2f;   // 이동 속도
        private bool isOpened = false;    // 문 열림 상태 확인
        private Vector3 openPosition;    // 열렸을 때의 목표 위치

        private void Start()
        {
            // 닫힌 상태로 초기화
            openPosition = new Vector3(transform.position.x, transform.position.y + openHeight, transform.position.z);
        }

        public void Interact()
        {
            if (!isOpened)
            {
                isOpened = true; // 문을 연 상태로 설정
                Debug.Log("문이 열렸습니다!");
            }
        }

        private void Update()
        {
            // 문이 열릴 때만 이동
            if (isOpened)
            {
                // 현재 위치와 목표 위치를 비교하여 이동
                transform.position = Vector3.MoveTowards(transform.position, openPosition, moveSpeed * Time.deltaTime);

                if (transform.position.y >= openPosition.y)
                {
                    // 문이 완전히 열렸을 때의 처리
                    transform.position = openPosition; // 목표 위치에 정확히 위치

                }
            }
        }
    }
}
