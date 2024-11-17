using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CYC
{
    public class EnemyHP : MonoBehaviour
    {
        public float MaxHp = 100f; // �ִ� HP
        public float currentHp; // ���� HP
        private Animator animator;


        private void Awake()
        {
            currentHp = MaxHp;
            animator = GetComponent<Animator>();
        }

        public void TakeDamage(int damage)
        {
            currentHp -= damage; // ���� ü�¿��� ������ ��ŭ ����
            Debug.Log("Health: " + currentHp);


            if (damage > 0) // �������� �Ծ��ٸ�
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
