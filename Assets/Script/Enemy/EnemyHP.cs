using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CYC
{
    public class EnemyHP : MonoBehaviour
    {
        public float MaxHp = 100f; // 최대 HP
        public float currentHp; // 현재 HP
        private Animator animator;


        private void Awake()
        {
            currentHp = MaxHp;
            animator = GetComponent<Animator>();
        }

        public void TakeDamage(int damage)
        {
            currentHp -= damage; // 현재 체력에서 데미지 만큼 차감
            Debug.Log("Health: " + currentHp);


            if (damage > 0) // 데미지를 입었다면
            {
                animator.SetBool("isDamage", true);
            }

            if (currentHp <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("Enemy has died.");
            animator.SetBool("isdead", true);
        }
        
    }
}
