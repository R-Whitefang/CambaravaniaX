using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MotionController;

public class DanoController : MonoBehaviour
{

    public enum ArmaList { chicote, faca };
    public int[] DanoArmaList = {2, 5, 10};
    public ArmaList arma = ArmaList.chicote;
    public int danoArma = 0;
    private Animator animator;
    public bool isAttacking = false;

    public GameObject faca;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(CheckAttackEnded());
    }

    void Update()
    {
        this.trocarArma();
        this.Attack();
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
            Instantiate(this.faca,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
        }
    }

    private void AttackChicote()
    {
        if (animator.GetInteger("state") == 3)
        {
            isAttacking = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D objetoColidiu)
    {
        if ((objetoColidiu.gameObject.tag == "Enemy" || objetoColidiu.gameObject.tag == "EnemyProjectile") && isAttacking)
        {
            GameObject inimigoAtingido = objetoColidiu.gameObject;
            StartCoroutine(CausarDano(inimigoAtingido));
        }
    }

    private void OnCollisionStay2D(Collision2D objetoColidiu)
    {
        if ((objetoColidiu.gameObject.tag == "Enemy" || objetoColidiu.gameObject.tag == "EnemyProjectile") && isAttacking)
        {
            GameObject inimigoAtingido = objetoColidiu.gameObject;
            StartCoroutine(CausarDano(inimigoAtingido));
        }
    }

    public IEnumerator CausarDano(GameObject inimigoAtingido)
    {
        Debug.Log(this.danoArma);
        yield return new WaitForSeconds(1f);
        Destroy(inimigoAtingido);
        yield return null;
    }

    public IEnumerator CheckAttackEnded()
    {
        yield return new WaitForSeconds(0.3f);
        if (animator.GetInteger("state") != 3)
        {
            isAttacking = false;
        }

        yield return null;
    }


    



}
