using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MotionController;

public class DanoController : MonoBehaviour
{

    public enum ArmaList { chicote, faca };
    public int[] DanoArmaList = { 2, 5, 10 };
    public ArmaList arma = ArmaList.chicote;
    public int danoArma = 2;
    private Animator animator;
    public bool isAttacking = false;
    public bool isCausandoDano = false;

    public GameObject faca;

    void Start()
    {
        inicializarDano();
        animator = GetComponent<Animator>();
        InvokeRepeating("CheckAttackEnded", 1.0f, 1.0f);
    }

    void Update()
    {
        this.trocarArma();
        this.Attack();
    }
    private void inicializarDano()
    {
        arma = ArmaList.chicote;
        danoArma = DanoArmaList[(int)arma];
    }


    private void trocarArma()
    {
        if (Input.GetButtonDown("SwitchWeapon"))
        {

            switch (arma)
            {
                case ArmaList.chicote:
                    arma = ArmaList.faca;
                    danoArma = DanoArmaList[(int)arma];
                    break;
                case ArmaList.faca:
                    arma = ArmaList.chicote;
                    danoArma = DanoArmaList[(int)arma];
                    break;
            }
        }
    }

    private void Attack()
    {
        switch (arma)
        {
            case ArmaList.chicote:
                AttackChicote();
                break;
            case ArmaList.faca:
                AttackFaca();
                break;
        }
    }

    private void AttackFaca()
    {
        if (animator.GetInteger("state") == 3)
        {
            isAttacking = true;
            //cria uma faca
            Instantiate(this.faca, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
        }
    }

    private void AttackChicote()
    {
        if (animator.GetInteger("state") == 3)
        {
            isAttacking = true;
        }
    }


    //Verifica se o player colidiu com um inimigo ou projetil de inimigo, entao causa dano se for o caso
    private void OnCollisionEnter2D(Collision2D objetoColidiu)
    {

        if ((objetoColidiu.gameObject.tag == "Enemy" || objetoColidiu.gameObject.tag == "EnemyProjectile")
            && isAttacking && !isCausandoDano
            )
        {
            isCausandoDano = true;
            StartCoroutine(CausarDano(objetoColidiu.gameObject));
        }
    }

    //Verifica se o player colidiu com um inimigo ou projetil de inimigo, entao causa dano se for o caso
    private void OnCollisionStay2D(Collision2D objetoColidiu)
    {

        if ((objetoColidiu.gameObject.tag == "Enemy" || objetoColidiu.gameObject.tag == "EnemyProjectile")
            && isAttacking && !isCausandoDano
            )
        {
            isCausandoDano = true;
            StartCoroutine(CausarDano(objetoColidiu.gameObject));

        }
    }

    //Corotina que chama a função CausarDano a cada 1 segundo para evitar dano exponencial em segundos
    public IEnumerator CausarDano(GameObject inimigoAtingido)
    {
        yield return new WaitForSeconds(1f);
        try {
            inimigoAtingido.transform.TryGetComponent(out VidaController vida);
            vida.debitoDano += danoArma;
        } catch  {
        } finally {
            isCausandoDano = false;

        }
        yield return null;

    }

    public void CheckAttackEnded()
    {
        if (animator.GetInteger("state") != 3)
        {
            isAttacking = false;
        }
    }


}
