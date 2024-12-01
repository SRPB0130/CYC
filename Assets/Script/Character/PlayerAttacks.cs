using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class PlayerAttack : MonoBehaviour
    {
        public float attackRange = 10f;  // 공격 범위
        public float attackCooldown = 1f;  // 공격 쿨타임
        private float attackTimer = 0f;  // 공격 쿨타임 타이머

        public GameObject projectilePrefab;  // 발사할 탄환 프리팹
        public Transform attackPoint;  // 공격 위치 (보통 캐릭터 앞에 위치한 빈 오브젝트)
        public KeyCode attackKey = KeyCode.Space;  // 공격 키 (기본: Space)

        void Update()
        {
            // 공격 쿨타임 업데이트
            attackTimer -= Time.deltaTime;

            // 특정 키를 눌렀을 때 공격
            if (attackTimer <= 0f && Input.GetKeyDown(attackKey))  // 지정한 키로 공격
            {
                Attack();
                attackTimer = attackCooldown;  // 공격 후 쿨타임 설정
            }
        }

        // 공격 함수
        void Attack()
        {
            // 마우스 위치 계산
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;  // 2D 게임이므로 z 값을 0으로 고정

            // 공격 방향 계산
            Vector3 attackDirection = (mousePosition - attackPoint.position).normalized;

            // 탄환 발사
            ShootProjectile(attackDirection);
        }

        // 탄환 발사 함수
        void ShootProjectile(Vector3 direction)
        {
            // 탄환 생성
            GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity);

            // 탄환의 방향 설정
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * 10f;  // 속도 설정 (10f는 탄환 속도)
        }

    }
}
