using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;
    private SpriteRenderer sprite;

    private enum ListaAnimacoes { idle, running, jumping }
    private ListaAnimacoes state = ListaAnimacoes.idle;
    private float movimentoX = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        this.changeAnimationByAction();
    }

    private void changeAnimationByAction() {
 
        ListaAnimacoes state;
        movimentoX = Input.GetAxisRaw("Horizontal");

        //Checa se o player está andando
        if(movimentoX != 0f) {
            state = ListaAnimacoes.running;
        } else {
            state = ListaAnimacoes.idle;
        }

        //Checa se o player está pulando
        if (rigidBody.velocity.y > .1f)
        {
            state = ListaAnimacoes.jumping;
        }

        //seta a animação correta
        animator.SetInteger("state", (int)state);
    }

    //Flipa o sprite do player baseado na direção que ele está indo,
    //O valor do GetAxisRaw muda conforme o input do jogador, começa no 0 e depois muda para 1 ou -1 dependendo
    //da direção
    private void flipSpriteToDirection() {
        if (Input.GetAxisRaw("Horizontal") > 0) {
            sprite.flipX = false;
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            sprite.flipX = true;
        }
    }
}
