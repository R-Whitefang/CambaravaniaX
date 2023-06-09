using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetaItens : MonoBehaviour
{
    private void curar(GameObject item) {
        gameObject.TryGetComponent(out VidaController vida);
        Debug.Log(vida.vidaTotal);
        item.transform.TryGetComponent(out DadosItem dadosItem);
        Debug.Log(dadosItem.valorCura);
        vida.vidaTotal += dadosItem.valorCura;
    }

    private void causarDanoArea(GameObject item) {
    }

    private void guardarArma(GameObject item ) {
    }

    private void guardarUpgradeVida(GameObject item) {
    }

    private void OnTriggerEnter2D(Collider2D objetoTriggado) {
        switch(objetoTriggado.gameObject.tag) {
            case "HealingItem":
                this.curar(objetoTriggado.gameObject);
                Destroy(objetoTriggado.gameObject);
                break;
            case "AOEDamageItem":
                this.causarDanoArea(objetoTriggado.gameObject);
                Destroy(objetoTriggado.gameObject);
                break; 
            case "Weapon":
                this.guardarArma(objetoTriggado.gameObject);
                break;
        }
    }
}
