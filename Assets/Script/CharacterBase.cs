using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SpriteRenderer spriterenderer;
    private Animator animator;

    public float moveSpeed = 10f;
    public float jumpPower = 10f;
    

    int jumpCount;

	public bool isJump = false;

    private Vector3 lastPosition;
    
    

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigid.freezeRotation = true;
        
    }

    private void Update()
    {
        move();
        jump();
        Animation();


        lastPosition = transform.position;
    }

    void move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 moveVelocity = new Vector3(x, 0, 0) * moveSpeed * Time.deltaTime;
        this.transform.position += moveVelocity;

        // 방향전환
        if (Input.GetButtonDown("Horizontal"))
        {
            spriterenderer.flipX = (Input.GetAxisRaw("Horizontal") == -1);
        }

    }
    void jump()
        // 2단 점프
    {
        if (Input.GetButtonDown("Jump") && jumpCount < 2)
        {
            isJump = true;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    void Animation()
    {
        float differentX = Mathf.Abs(lastPosition.x - transform.position.x);
        if (differentX <= 0)
        {
            animator.SetBool("isWalk", false);
        }
        else
        {
            animator.SetBool("isWalk", true);
        }

        //if (rigid.velocity.normalized.x == 0)
        //{            
        //}
        //else
        //{            
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
        // 바닥에 닿아야 점프카운트가 초기화 됨
    {
        switch(collision.gameObject.tag)
        {
            case "Ground":
                jumpCount = 0;
                break;
        }
            
    }

    
}
