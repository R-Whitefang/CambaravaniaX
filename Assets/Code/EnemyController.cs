using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isCausandoDano = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CausarDanoAoPlayer(GameObject player){
        yield return new WaitForSeconds(0.5f);
            player.transform.TryGetComponent(out VidaController vida);
            vida.debitoDano += 10;
            isCausandoDano = false;
        yield return null;
    }

    
    private void OnCollisionEnter2D(Collision2D objetoColidiu) {
        if(objetoColidiu.gameObject.tag == "Player" && !isCausandoDano) {
            isCausandoDano = true;
            StartCoroutine(CausarDanoAoPlayer(objetoColidiu.gameObject));
        } 
    }

    private void OnCollisionStay2D(Collision2D objetoColidiu) {
        if(objetoColidiu.gameObject.tag == "Player" && !isCausandoDano) {
            isCausandoDano = true;
            StartCoroutine(CausarDanoAoPlayer(objetoColidiu.gameObject));
        }
    }
}
