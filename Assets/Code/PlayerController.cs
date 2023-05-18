using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;

    private float movimentoX = 0f;
    public float moveSpeed = 7f;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        movimentoX = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(movimentoX * moveSpeed, rigidBody.velocity.y);  
    }


    
}
