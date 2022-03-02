using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameendPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject waiting;
    public GameObject restart;

    public Text nickname;

    PhotonView view;
    void Start()
    {
        view = GetComponent<PhotonView>();
        if(PhotonNetwork.IsMasterClient == false)
        {
            restart.SetActive(false);
            waiting.SetActive(true);
        }
       
        /*
        if(view.IsMine)
        {
            nickname.text = PhotonNetwork.NickName;
        }
        else
        {
            nickname.text = view.Owner.NickName;
        }*/
    }

    public void Mul_Restart()
    {
        view.RPC("Restart", RpcTarget.All);
    }
    

    [PunRPC]
    void Restart()
    {
        PhotonNetwork.LoadLevel("MulGame");
    }
}
