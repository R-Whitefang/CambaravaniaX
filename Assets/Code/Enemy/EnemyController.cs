using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool isCausandoDano = false;
    //CADA INIMIGO TERÁ SEU DANO SETTADO AQUI
    public int danoDoInimigo = 2;

    public bool isBoss = false;

    public bool isMelee = false;

    private Animator animator;

    public float rangeDeteccao = 10f;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        estaVendoJogador();
    }

    public void estaVendoJogador() {
        GameObject player = GameObject.FindWithTag("Player");
        if (Vector2.Distance(transform.position, player.transform.position) <= rangeDeteccao)
        {
           atacar();
        } else
        {
           pararAtaque();
        }

    }

    public void atacar() {
        animator.SetBool("atacando", true);
    }

    public void pararAtaque() {
        if(isBoss == false) {
            animator.SetBool("atacando", false);
        }
    }
    
    public void droparItem(float posicaoX, float posicaoY) {
        GameObject listItens = GameObject.FindWithTag("ListaItens");
        listItens.transform.TryGetComponent(out ListaItens lista);
        GameObject itemSelecionado = lista.itensNormais[Random.Range(0, lista.itensNormais.Length)];

        Instantiate(itemSelecionado, 
            new Vector2(posicaoX, posicaoY), Quaternion.identity);
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
        float posicaoX = gameObject.transform.position.x;
        float posicaoY = gameObject.transform.position.y;
        droparItem(posicaoX, posicaoY);
    }
}
