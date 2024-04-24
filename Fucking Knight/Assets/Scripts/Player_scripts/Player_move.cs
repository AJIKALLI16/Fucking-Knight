using System;
using System.Collections;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    public Vector2 moveVector;
    public Animator anim;
    public SpriteRenderer sr;
    public float jumpforce = 14f;
    public bool onGround;
    public Transform GroundCheck;
    public float chekRadius = 0.5f;
    public LayerMask Ground;
    public bool roll = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        move();
        flip();
        jump();
        ChekingGround();
        Roll();
    }

    void move()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }
    void flip()
    {
        sr.flipX = moveVector.x < 0;
    }
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround) rb.velocity = new Vector2(rb.velocity.x, jumpforce);
    }
    void ChekingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, chekRadius, Ground);
        anim.SetBool("onGround", onGround);
    }
    void Roll()
    {
        if(Input.GetKeyUp(KeyCode.LeftControl) && !roll)
        {
            roll = true;
            anim.SetBool("Roll", roll);
            StartCoroutine(DoRoll());
        }
    }
    IEnumerator DoRoll()
    {
        yield return new WaitForSeconds(0.5f);
        roll = false;
        anim.SetBool("Roll", roll);
    }
}
