using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;
    private SpriteRenderer sprite;

    private enum ListaAnimacoes { idle, running, jumping, attacking }
    private ListaAnimacoes state = ListaAnimacoes.idle;
    private float movimentoX = 0f;

    private int currentArma = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        this.getCurrentArma();
        this.changeAnimationByAction();
        this.flipSpriteToDirection();
        
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

        if (Input.GetButtonDown("Fire1")) {
            state = ListaAnimacoes.attacking;
            Debug.Log("Caiu");
        }

        //seta a animação correta
        animator.SetInteger("tipoArma",currentArma);
        animator.SetInteger("state", (int)state);
    }

    private void getCurrentArma() {
        gameObject.TryGetComponent(out DanoController DanoController);
        currentArma = (int)DanoController.arma;
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
