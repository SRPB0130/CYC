using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CYC
{
    public class PlayerHp : MonoBehaviour
    {
        
        public float MaxHp = 100f; // 최대 HP
        public float currentHp; // 현재 HP
        public Image hpBar;
        public Text hpText;

        private Animator animator;


        private void Awake()
        {
            currentHp = MaxHp;
            UpdateHealthUI();
            animator = GetComponent<Animator>();
        }

        public void TakeDamage(int damage)
        {
            currentHp -= damage; // 현재 체력에서 데미지 만큼 차감
            Debug.Log("Health: " + currentHp);
            UpdateHealthUI();

            if (damage > 0) // 데미지를 입었다면
            {
                animator.SetBool("isDamage", true);
                StartCoroutine(ResetDamageAnimation());
            }
            
            if (currentHp <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("Player has died.");

        }
        public void UpdateHealthUI()
        {
            hpBar.fillAmount = currentHp / MaxHp; // 체력바 비율 업데이트
            hpText.text = $"{currentHp}/{MaxHp}"; // 텍스트 업데이트
        }
        private IEnumerator ResetDamageAnimation()
        {
            yield return new WaitForSeconds(0.5f); // 애니메이션 지속 시간에 맞춰 조정
            animator.SetBool("isDamage", false); // 애니메이션 리셋
        }

    }
}
