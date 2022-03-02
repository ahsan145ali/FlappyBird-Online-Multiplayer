using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;
public class createJoinRoom : MonoBehaviourPunCallbacks
{
    public InputField create_room;
    public InputField join_room;
    public InputField nick_name;
    // Start is called before the first frame update


    public void NameSet()
    {
        PhotonNetwork.NickName = nick_name.text;
    }
    public void Room_Creation()
    {
        RoomOptions r_o = new RoomOptions();
        r_o.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(create_room.text , r_o);
    }

   

    public void Join_room()
    {
        PhotonNetwork.JoinRoom(join_room.text);
    }

    public override void OnJoinedRoom()
    {
       
            PhotonNetwork.LoadLevel("lobby");

        //base.OnJoinedRoom();
    }
}
