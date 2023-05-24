using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MotionController;

public class PlayerController : MonoBehaviour
{
   

    // Start is called before the first frame update
    private Animator animator;
    public bool isAttacking = false;

    void Start() {
        animator = GetComponent<Animator>();
        StartCoroutine(CheckAttackEnded());
    }

    void Update() {
        this.Attack();
    }

    // private void checkAttackEnded() {
    //     if(animator.GetInteger("state") != 3) {
    //         isAttacking = false;
    //     }
    // }

    IEnumerator CheckAttackEnded (){
        yield return new WaitForSeconds(0.3f);
        if(animator.GetInteger("state") != 3) {
            isAttacking = false;
        }

        yield return null;
    }

    IEnumerator CausarDano (GameObject inimigoAtingido){
        yield return new WaitForSeconds(1f);
        Destroy(inimigoAtingido);

        yield return null;
    }

    private void Attack() {
        if(animator.GetInteger("state") == 3) {
            isAttacking = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D objetoColidiu) {
        if((objetoColidiu.gameObject.tag == "Enemy" || objetoColidiu.gameObject.tag == "EnemyProjectile") && isAttacking) {
            GameObject inimigoAtingido = objetoColidiu.gameObject;
            StartCoroutine(CausarDano(inimigoAtingido));
        }
    }

    private void OnCollisionStay2D(Collision2D objetoColidiu) {
         if((objetoColidiu.gameObject.tag == "Enemy" || objetoColidiu.gameObject.tag == "EnemyProjectile") && isAttacking) {
            GameObject inimigoAtingido = objetoColidiu.gameObject;
            StartCoroutine(CausarDano(inimigoAtingido));
        }
    }

  
    
}
