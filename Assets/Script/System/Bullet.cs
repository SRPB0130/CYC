using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class Bullet : MonoBehaviour
    {
        public float lifetime = 3f;  // 탄환이 살아있는 시간
        public int damage = 10;   // 탄환의 피해

        void Start()
        {
            // 일정 시간이 지나면 탄환을 삭제
            Destroy(gameObject, lifetime);
        }

        // 충돌 시 처리
        void OnCollisionEnter2D(Collision2D collision)
        {
            // 적과 충돌하면 피해를 주고 탄환 삭제
            if (collision.gameObject.CompareTag("Enemy"))
            {
                // 적에게 피해 주기 (Enemy 스크립트에 적용할 수 있음)
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }

                // 탄환 삭제
                Destroy(gameObject);
            }
            else
            {
                // 그 외의 물체와 충돌하면 그냥 삭제
                Destroy(gameObject);
            }
        }
    }

}

