using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += (transform.right * (-1)) * moveSpeed * Time.deltaTime;
    }
    
    private void OnCollisionEnter2D(Collision2D objetoColidiu) {

        if ((objetoColidiu.gameObject.tag == "Enemy" || objetoColidiu.gameObject.tag == "EnemyProjectile"))
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.transform.TryGetComponent(out DanoController danoController);
            GameObject inimigoAtingido = objetoColidiu.gameObject;
            StartCoroutine(danoController.CausarDano(inimigoAtingido));
        }
        
    }

    void OnBecameInvisible () {
        Destroy(gameObject);
    }
}
