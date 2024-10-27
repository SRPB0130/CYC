using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class EnemyAttack : MonoBehaviour
    {

        private PlayerHp playerHp; // PlayerHp 참조

        private bool isDamageable = true; // 데미지를 받을 수 있는지 여부

        private void Awake()
        {
            playerHp = GetComponent<PlayerHp>(); // PlayerHealth 컴포넌트를 가져옴
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && isDamageable)
            {
                playerHp.TakeDamage(10); // 적과 충돌 시 10의 데미지를 입음
                isDamageable = false; // 데미지를 입은 후 false로 설정
                StartCoroutine(ResetDamageable()); // 일정 시간 후 다시 데미지를 받을 수 있도록 설정
            }
        }

        private IEnumerator ResetDamageable()
        {
            yield return new WaitForSeconds(0.6f); // 0.6초 후에 다시 데미지를 받을 수 있도록 설정
            isDamageable = true;
        }
    }

}

