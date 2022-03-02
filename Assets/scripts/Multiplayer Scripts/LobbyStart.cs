using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class LobbyStart : MonoBehaviour
{
    public Text count;
    public Text wait;
    bool can_start;
    // Start is called before the first frame update
    void Start()
    {
        can_start = false;
    }

    // Update is called once per frame
    void Update()
    {
        count.text = "Players: " + PhotonNetwork.PlayerList.Length + " / 2";

        if (!can_start)
        {
            if (PhotonNetwork.PlayerList.Length > 1)
            {
                can_start = true;
                wait.text = "Starting Game";
                Invoke("start_level", 2f);
            }
        }
    }
    void start_level()
    {
        SceneManager.LoadScene("MulGame");
    }
}
