using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortaController : MonoBehaviour
{
    public bool isAcessivel = false;

    private void OnTriggerEnter2D(Collider2D objetoColidiu) {
        if (objetoColidiu.gameObject.tag == "Player" && isAcessivel == true)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }
}
