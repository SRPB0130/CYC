using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class Enemy : MonoBehaviour
    {
        Rigidbody2D rigid;
        SpriteRenderer spriteRenderer;
        public int nextMove;
        public float GroundCheck = 1f;
        public LayerMask groundLayer;

        public float MaxHp = 100f; // �ִ� HP
        public float currentHp; // ���� HP
        private Animator animator;

        void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            Invoke("Think", 1);
            currentHp = MaxHp;
            animator = GetComponent<Animator>();
        }
        void FixedUpdate()
        {
            bool isGrounded = IsGrounded();
            if (!isGrounded)
            {
                nextMove = -nextMove;  // �ٴ��� ������ �̵��� ���߰� ��
            }

            if (nextMove < 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (nextMove > 0)
            {
                spriteRenderer.flipX = true;
            }

            // ���� �̵�
            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        }

        void Think()
        {
            nextMove = Random.Range(-1, 2);

            Invoke("Think", 1);
        }
        private bool IsGrounded()
        {

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, GroundCheck, groundLayer);

            if (hit.collider != null)
            {
                return true;
            }

            return false;
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
