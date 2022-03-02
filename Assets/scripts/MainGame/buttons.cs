using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void restart_game()
    {
        SceneManager.LoadScene("MainGame");
        Time.timeScale = 1;
    }

    public void Classic_button()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void Multiplayer_button()
    {
        SceneManager.LoadScene("Connect");
    }
    public void Home_classic()
    {
        SceneManager.LoadScene("Home");
    }
}
