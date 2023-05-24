using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator animator;

    private float movimentoX = 0f;
    public float moveSpeed = 7f;
    private bool canJump = false;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        this.movement();
    }

    private void movement()
    {
        movimentoX = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(movimentoX * moveSpeed, rigidBody.velocity.y);  

        if(Input.GetKeyDown("space") && canJump){
            this.jump(rigidBody);
        }

    }

    //Faz o jogador pular
    private void jump(Rigidbody2D rigidBody)
    {
       rigidBody.velocity = new Vector3(0, 18, 0);       
       canJump = false;
    }

    private void OnCollisionEnter2D(Collision2D objetoColidiu) {
        if(Equals(objetoColidiu.gameObject.tag,  "Ground")) {
            canJump = true;
        }
        
    }

   

   
}
