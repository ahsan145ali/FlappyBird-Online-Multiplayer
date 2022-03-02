using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinAppearence : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0f, 1f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bird")
        {
            gameObject.SetActive(false);
            Invoke("reappear", 2f);
        }
    }
    void reappear()
    {
        gameObject.SetActive(true);
    }
}
