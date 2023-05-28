using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isCausandoDano = false;

    //Corotina que chama a função CausarDanoAoPlayer a cada 1 segundo para evitar dano exponencial em segundos
    IEnumerator CausarDanoAoPlayer(GameObject player){
        yield return new WaitForSeconds(0.5f);
            player.transform.TryGetComponent(out VidaController vida);
            vida.debitoDano += 10;
            isCausandoDano = false;
        yield return null;
    }

    
    //Verifica se o inimigo colidiu com o player, entao causa dano se for o caso
    private void OnCollisionEnter2D(Collision2D objetoColidiu) {
        if(objetoColidiu.gameObject.tag == "Player" && !isCausandoDano) {
            isCausandoDano = true;
            StartCoroutine(CausarDanoAoPlayer(objetoColidiu.gameObject));
        } 
    }

    //Verifica se o inimigo continua colidindo com o player, entao causa dano se for o caso
    private void OnCollisionStay2D(Collision2D objetoColidiu) {
        if(objetoColidiu.gameObject.tag == "Player" && !isCausandoDano) {
            isCausandoDano = true;
            StartCoroutine(CausarDanoAoPlayer(objetoColidiu.gameObject));
        }
    }
}
