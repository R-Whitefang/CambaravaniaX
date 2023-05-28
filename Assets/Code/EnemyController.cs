using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool isCausandoDano = false;
    //CADA INIMIGO TERÁ SEU DANO SETTADO AQUI
    public int danoDoInimigo = 2;

    public bool isBoss = false;


    void Start() {

    }
    
    public void droparItem() {
        
        GameObject listItens = GameObject.FindWithTag("ListaItens");
        listItens.transform.TryGetComponent(out ListaItens lista);
        GameObject itemSelecionado = lista.itensNormais[Random.Range(0, lista.itensNormais.Length)];

        Instantiate(itemSelecionado, 
            new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
        
    }

    //Corotina que chama a função CausarDanoAoPlayer a cada 1 segundo para evitar dano exponencial em segundos
    IEnumerator CausarDanoAoPlayer(GameObject player){
        yield return new WaitForSeconds(0.5f);
            player.transform.TryGetComponent(out VidaController vida);
            vida.debitoDano += danoDoInimigo;
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

    //Ao Destruir o inimigo ele dropa um item
    private void OnDestroy() {
        droparItem();
    }
}
