using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class MulgameManager : MonoBehaviour
{
    public GameObject EndPanel;
    public Text Win_or_lose;
    int counter = 3;
    PhotonView view;

    string str = " ";
    string sync_str = "Default";
    int check = 0;
    // Start is called before the first frame update
    void Start()
    { 
        view = GetComponent<PhotonView>();
       
    }


    public void Display_EndPanel(string name)
    {
      
        view.RPC("EndPanel_Activate", RpcTarget.All,name);
    }

    [PunRPC]
    void EndPanel_Activate(string name)
    {

        if (check == 0)
        {
            Win_or_lose.text =name + " LOST";

            EndPanel.SetActive(true);
        }
        check = 1;
            
    }
    
    public void GO_Home()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel("Home");
    }


}
