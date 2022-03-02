using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //This Script is for BackGround Music

    AudioSource BG_music;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        BG_music = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
