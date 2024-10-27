using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CYC
{
    public class PlayerHp : MonoBehaviour
    {
        
        public float MaxHp = 100f; // �ִ� HP
        public float currentHp; // ���� HP
        public Image hpBar;
        public TextMeshProUGUI hpText;

        private Animator animator;


        private void Awake()
        {
            currentHp = MaxHp;
            UpdateHealthUI();
            animator = GetComponent<Animator>();
        }

        public void TakeDamage(int damage)
        {
            currentHp -= damage; // ���� ü�¿��� ������ ��ŭ ����
            Debug.Log("Health: " + currentHp);
            UpdateHealthUI();

            if (damage > 0) // �������� �Ծ��ٸ�
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
            hpBar.fillAmount = currentHp / MaxHp; // ü�¹� ���� ������Ʈ
            hpText.text = $"{currentHp}/{MaxHp}"; // �ؽ�Ʈ ������Ʈ
        }
        private IEnumerator ResetDamageAnimation()
        {
            yield return new WaitForSeconds(0.5f); // �ִϸ��̼� ���� �ð��� ���� ����
            animator.SetBool("isDamage", false); // �ִϸ��̼� ����
        }

    }
}
