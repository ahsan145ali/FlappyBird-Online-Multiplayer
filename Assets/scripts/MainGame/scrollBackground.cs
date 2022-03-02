using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollBackground : MonoBehaviour
{
    private Rigidbody2D back_ground;
    public static scrollBackground Instace;

    void Start()
    {
        Instace = this;
        back_ground = GetComponent<Rigidbody2D>();
        back_ground.velocity = new Vector2(-1.5f, 0);

    }

    void Update()
    {
        if (player.Instance != null)
        {
            if (player.Instance.Alive_status() == false)
            {
                back_ground.velocity = new Vector2(0f, 0);
            }
        }
    }

   
}
