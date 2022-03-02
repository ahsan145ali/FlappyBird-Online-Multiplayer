using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Spawnplayer : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> spawn_points = new List<GameObject>();

    int counter = 2;

    public static Spawnplayer Instance;
    Vector2 rand_pos;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, spawn_points.Count);
        rand_pos = spawn_points[index].transform.position;
        GameObject a =  PhotonNetwork.Instantiate(player.name, rand_pos, Quaternion.identity) as GameObject;
       
        

    }
    private void Update()
    {
        Debug.Log("Players: " + PhotonNetwork.PlayerList.Length);
    }
    public void Dec_count()
    {
        counter--;
        Debug.Log("Counter: " + counter);
    }
}
