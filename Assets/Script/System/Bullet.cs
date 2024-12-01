using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class Bullet : MonoBehaviour
    {
        public float lifetime = 3f;  // źȯ�� ����ִ� �ð�
        public int damage = 10;   // źȯ�� ����

        void Start()
        {
            // ���� �ð��� ������ źȯ�� ����
            Destroy(gameObject, lifetime);
        }

        // �浹 �� ó��
        void OnCollisionEnter2D(Collision2D collision)
        {
            // ���� �浹�ϸ� ���ظ� �ְ� źȯ ����
            if (collision.gameObject.CompareTag("Enemy"))
            {
                // ������ ���� �ֱ� (Enemy ��ũ��Ʈ�� ������ �� ����)
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }

                // źȯ ����
                Destroy(gameObject);
            }
            else
            {
                // �� ���� ��ü�� �浹�ϸ� �׳� ����
                Destroy(gameObject);
            }
        }
    }

}

