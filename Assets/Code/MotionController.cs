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
        this.flipSpriteToDirection(sprite);

        if(Input.GetKeyDown("space")){
            this.jump(rigidBody);
        }
    }

    //Faz o jogador pular
    private void jump(Rigidbody2D rigidBody)
    {
       rigidBody.velocity = new Vector3(0, 14, 0);       
    }

    //Flipa o sprite do player baseado na direção que ele está indo,
    //O valor do GetAxisRaw muda conforme o input do jogador, começa no 0 e depois muda para 1 ou -1 dependendo
    //da direção
    private void flipSpriteToDirection(SpriteRenderer sprite) {
        if (Input.GetAxisRaw("Horizontal") > 0) {
            sprite.flipX = false;
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            sprite.flipX = true;
        }
    }

   
}
