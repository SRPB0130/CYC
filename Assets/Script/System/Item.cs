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
            // �÷��̾� ������Ʈ�� ã�´�.
            player = GameObject.FindWithTag("Player").transform;
        }

        void Update()
        {
            // �÷��̾���� �Ÿ� ���
            float distance = Vector2.Distance(transform.position, player.position);

            // �÷��̾ ���� �Ÿ� ���� ������ �������� �÷��̾ ���󰣴�.
            if (distance <= pickupDistance)
            {
                // �÷��̾���� �Ÿ��� ������ �������� �ڵ����� �÷��̾ ���󰣴�.
                FollowPlayer();
            }
        }

        // �������� �÷��̾ ���󰡵��� �ϴ� �Լ�
        private void FollowPlayer()
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            // �÷��̾�� �浹�ϸ� �������� �Ծ��ٰ� ó���ϰ� ������ ����
            if (Vector2.Distance(transform.position, player.position) <= 0.1f)
            {
                PickupItem();
            }
        }

        // �������� ������ ó���� �Լ� (��: ������ ����, ȿ�� ���� ��)
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
