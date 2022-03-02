using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMul : MonoBehaviour
{
    private Rigidbody2D back_ground;
    bool move;

    public static ScrollMul Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        move = false;
        back_ground = GetComponent<Rigidbody2D>();
        back_ground.velocity = new Vector2(-1.5f, 0);

    }
    private void Update()
    {
        
    }
    public void MoveBG()
    {
        move = true;
    }
}
