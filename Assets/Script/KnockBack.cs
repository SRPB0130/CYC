using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class KnockBack : MonoBehaviour
    {
        public float knockbackForce = 5f;  // 밀려나는 힘의 크기
        public float invincibilityDuration = 1f;  // 무적 시간
        private bool isInvincible = false;  // 무적 상태 여부
        private Rigidbody2D rb;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // 데미지를 입는 함수
        public void TakeDamage(Vector2 attackDirection)
        {
            if (!isInvincible)
            {
                // 피격 반대 방향으로 밀려남
                Vector2 knockbackDirection = -attackDirection.normalized;
                rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

                // 무적 상태로 전환 및 일정 시간 후 해제
                StartCoroutine(InvincibilityCoroutine());
            }
        }

        private IEnumerator InvincibilityCoroutine()
        {
            isInvincible = true;
            yield return new WaitForSeconds(invincibilityDuration);
            isInvincible = false;
        }

        // 충돌 체크 (적과의 충돌 시 데미지 입음)
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                // 적이 있는 방향을 계산
                Vector2 attackDirection = collision.transform.position - transform.position;
                TakeDamage(attackDirection);
            }
        }
    }
}
