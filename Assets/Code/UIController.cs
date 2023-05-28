using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text vidaText;

    public Text armaText;

    void Start()
    {
        
    }

    void Update()
    {
        mostrarVidaNaTela();
        mostrarArmaNaTela();
    }

     private void mostrarVidaNaTela() {
        gameObject.transform.TryGetComponent(out VidaController vidaInfo);
        vidaText.text = (vidaInfo.vidaTotal.ToString() + "/" + vidaInfo.vidaBase.ToString());
    }

    private void mostrarArmaNaTela() {
        gameObject.transform.TryGetComponent(out DanoController danoInfo);
        string armaNome = "";
        switch((int)danoInfo.arma) {
            case 0:
                armaNome = "Chicote";
                break;
            case 1:
                armaNome = "Faca";
                break;    
        }

        armaText.text = armaNome;
    }

}
