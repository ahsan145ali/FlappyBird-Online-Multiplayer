using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraEffect : MonoBehaviour
{
    public GameObject Tap_to;
   
    public GameObject b1;
    public GameObject b2;

  
    public bool startnow;
    public GameObject obsticles;

    bool can_start;
    public bool execute;
    bool stop;
    public static CameraEffect Instance;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        can_start = false;
        startnow = false;
        stop = false;
        execute = false;
        // StartCoroutine(ZoomOut());
        b1.GetComponent<Rigidbody2D>().velocity = Vector2.up * 2f;
        b2.GetComponent<Rigidbody2D>().velocity = Vector2.down * 2f;
        
    }

    private void Update()
    {
        if(b1.transform.position.y >=8.7 && b2.transform.position.y <=-8.7 && !stop)
        {
            b1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            b2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Tap_to.SetActive(true);
            can_start = true;
            stop = true;

        }

        if(Input.GetMouseButtonDown(0) && can_start)
        {
            Tap_to.SetActive(false);
            obsticles.SetActive(true);
            player.Instance.Set_Gravity();
            can_start = false;
            execute = true;
        }
    }
    
}
