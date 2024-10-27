using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class EnemyAttack : MonoBehaviour
    {

        private PlayerHp playerHp; // PlayerHp ����

        private bool isDamageable = true; // �������� ���� �� �ִ��� ����

        private void Awake()
        {
            playerHp = GetComponent<PlayerHp>(); // PlayerHealth ������Ʈ�� ������
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && isDamageable)
            {
                playerHp.TakeDamage(10); // ���� �浹 �� 10�� �������� ����
                isDamageable = false; // �������� ���� �� false�� ����
                StartCoroutine(ResetDamageable()); // ���� �ð� �� �ٽ� �������� ���� �� �ֵ��� ����
            }
        }

        private IEnumerator ResetDamageable()
        {
            yield return new WaitForSeconds(0.6f); // 0.6�� �Ŀ� �ٽ� �������� ���� �� �ֵ��� ����
            isDamageable = true;
        }
    }

}

