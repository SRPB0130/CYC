using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class PlayerHp : MonoBehaviour
    {
        private SpriteRenderer spriterenderer;

        public float MaxHp = 100f;
        public float currentHp;

        private void Awake()
        {
            currentHp = MaxHp;
        }



        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                TakeDamage(10); // 적과 충돌 시 10의 데미지를 입음
                
            }
        }
        void TakeDamage(int damage)
        {
            currentHp -= damage;
            Debug.Log("Health: " + currentHp);

            if (currentHp <= 0)
            {
                Die();
            }
        }
        void OnDamage(Vector2 targePosition)
        {
            gameObject.layer = 9;
            spriterenderer.color = new Color(1, 1, 1, 0.4f);
        }

        void Die()
        {
            Debug.Log("Player has died.");

        }
    }
}
