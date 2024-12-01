using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    using UnityEngine;

    public class Item : MonoBehaviour
    {
        public float moveSpeed = 2f;   
        public float pickupDistance = 1.5f;  
        private Transform player;
        public int scoreValue = 1;



        void Start()
        {
            // 플레이어 오브젝트를 찾는다.
            player = GameObject.FindWithTag("Player").transform;
        }

        void Update()
        {
            // 플레이어와의 거리 계산
            float distance = Vector2.Distance(transform.position, player.position);

            // 플레이어가 일정 거리 내에 들어오면 아이템이 플레이어를 따라간다.
            if (distance <= pickupDistance)
            {
                // 플레이어와의 거리가 가까우면 아이템이 자동으로 플레이어를 따라간다.
                FollowPlayer();
            }
        }

        // 아이템이 플레이어를 따라가도록 하는 함수
        private void FollowPlayer()
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            // 플레이어와 충돌하면 아이템을 먹었다고 처리하고 아이템 삭제
            if (Vector2.Distance(transform.position, player.position) <= 0.1f)
            {
                PickupItem();
            }
        }

        // 아이템을 먹으면 처리할 함수 (예: 아이템 삭제, 효과 적용 등)
        private void PickupItem()
        {
            CharacterBase playerScript = player.GetComponent<CharacterBase>();
            if (playerScript != null)
            {
                playerScript.IncreaseScore(scoreValue);
            }
            Destroy(gameObject);

        }
    }

}
