using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class PlayerAttack : MonoBehaviour
    {
        public float attackRange = 10f;  // ���� ����
        public float attackCooldown = 1f;  // ���� ��Ÿ��
        private float attackTimer = 0f;  // ���� ��Ÿ�� Ÿ�̸�

        public GameObject projectilePrefab;  // �߻��� źȯ ������
        public Transform attackPoint;  // ���� ��ġ (���� ĳ���� �տ� ��ġ�� �� ������Ʈ)
        public KeyCode attackKey = KeyCode.Space;  // ���� Ű (�⺻: Space)

        void Update()
        {
            // ���� ��Ÿ�� ������Ʈ
            attackTimer -= Time.deltaTime;

            // Ư�� Ű�� ������ �� ����
            if (attackTimer <= 0f && Input.GetKeyDown(attackKey))  // ������ Ű�� ����
            {
                Attack();
                attackTimer = attackCooldown;  // ���� �� ��Ÿ�� ����
            }
        }

        // ���� �Լ�
        void Attack()
        {
            // ���콺 ��ġ ���
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;  // 2D �����̹Ƿ� z ���� 0���� ����

            // ���� ���� ���
            Vector3 attackDirection = (mousePosition - attackPoint.position).normalized;

            // źȯ �߻�
            ShootProjectile(attackDirection);
        }

        // źȯ �߻� �Լ�
        void ShootProjectile(Vector3 direction)
        {
            // źȯ ����
            GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity);

            // źȯ�� ���� ����
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * 10f;  // �ӵ� ���� (10f�� źȯ �ӵ�)
        }

    }
}
