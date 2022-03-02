using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBackground : MonoBehaviour
{
    private BoxCollider2D ground_collider;        
    private float ground_Next_Length;

    void Start()
    {
        ground_collider = GetComponent<BoxCollider2D>();
        ground_Next_Length = ground_collider.size.x;
    }

    void Update()
    {
        if (transform.position.x < -ground_Next_Length)
        {
            Background_Positioning();
        }
    }
    private void Background_Positioning()
    {
        Vector2 groundOffSet = new Vector2(ground_Next_Length * 2f, 0);

        transform.position = (Vector2)transform.position + groundOffSet;
    }
}
