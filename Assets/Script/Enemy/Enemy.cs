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

        public float MaxHp = 100f; // 최대 HP
        public float currentHp; // 현재 HP
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
                nextMove = -nextMove;  // 바닥이 없으면 이동을 멈추게 함
            }

            if (nextMove < 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (nextMove > 0)
            {
                spriteRenderer.flipX = true;
            }

            // 적의 이동
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
