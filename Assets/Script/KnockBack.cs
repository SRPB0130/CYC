using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class KnockBack : MonoBehaviour
    {
        public float knockbackForce = 5f;  // �з����� ���� ũ��
        public float invincibilityDuration = 1f;  // ���� �ð�
        private bool isInvincible = false;  // ���� ���� ����
        private Rigidbody2D rb;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // �������� �Դ� �Լ�
        public void TakeDamage(Vector2 attackDirection)
        {
            if (!isInvincible)
            {
                // �ǰ� �ݴ� �������� �з���
                Vector2 knockbackDirection = -attackDirection.normalized;
                rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

                // ���� ���·� ��ȯ �� ���� �ð� �� ����
                StartCoroutine(InvincibilityCoroutine());
            }
        }

        private IEnumerator InvincibilityCoroutine()
        {
            isInvincible = true;
            yield return new WaitForSeconds(invincibilityDuration);
            isInvincible = false;
        }

        // �浹 üũ (������ �浹 �� ������ ����)
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                // ���� �ִ� ������ ���
                Vector2 attackDirection = collision.transform.position - transform.position;
                TakeDamage(attackDirection);
            }
        }
    }
}
