using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Extende do EnemyController assim nao precisa refazer codigo de dano e tomar dano por exemplo
public class BossController : EnemyController
{
    public enum BossList { VeioProva, Gritador, Bruxa};
    public BossList nomeBoss;

    void LiberarPorta()
    {
        GameObject portaLevel = GameObject.FindWithTag("Porta");
        portaLevel.transform.TryGetComponent(out PortaController porta);
        porta.isAcessivel = true;
    }

    void DroparBossItem() 
    {

    }

    private void OnDestroy() {
        base.droparItem();
        DroparBossItem();
        LiberarPorta();
    }
}
