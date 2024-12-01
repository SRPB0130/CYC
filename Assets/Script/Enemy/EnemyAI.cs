using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYC
{
    public class EnemyAI : MonoBehaviour
    {
        Rigidbody2D rigid;
        SpriteRenderer spriteRenderer; 
        public int nextMove;
        public float GroundCheck = 1f;
        public LayerMask groundLayer;


        void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>(); 
            Invoke("Think", 1);
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
    }
}
