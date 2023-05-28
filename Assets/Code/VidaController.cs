using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaController : MonoBehaviour
{
    // Start is called before the first frame update
    public int vidaBase = 100;
    public int vidaTotal = 100;
    public int debitoDano = 0;

    void Start()
    {
        inicializarVida();
        StartCoroutine(DebitarDano());
    }

    // Update is called once per frame
    void Update()
    {
        deveMorrer();
    }

    void inicializarVida()
    {
        vidaTotal = vidaBase;
    }

    IEnumerator DebitarDano(){
        while(vidaTotal >= 0) {
            yield return new WaitForSeconds(1);
            deveTomarDano();
        }
        yield return null;
    }

    

    private void deveTomarDano() {
        //O dano maximo em um tick é 40, quando for menor toma o dano full
        if(debitoDano >= 40) {
            vidaTotal -= 40;
            debitoDano -= 40;
        } else {
            vidaTotal -= debitoDano;
            debitoDano = 0;
        }
    }

    private void deveMorrer() {
        if(vidaTotal <= 0) {
            Destroy(gameObject);
        }
    }
}
