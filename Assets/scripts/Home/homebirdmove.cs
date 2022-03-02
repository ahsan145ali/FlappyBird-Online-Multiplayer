using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homebirdmove : MonoBehaviour
{

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Go_Right();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Go_Right()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
        rb.velocity = Vector2.right * 2f;
       
    }

    void Go_Left()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = true;
        rb.velocity = Vector2.left * 2f;
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "r")
        {
            Go_Left();
        }
        if(collision.gameObject.tag == "l")
        {
            Go_Right();
        }

    }
}
