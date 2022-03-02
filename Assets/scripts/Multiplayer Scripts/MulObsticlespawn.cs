using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulObsticlespawn : MonoBehaviour
{
    //public GameObject Parent;
    public GameObject Obstacle;
    public GameObject Obstacle2;
    public int ObstaclePoolSize = 5;
    public float spawn_Rate = 3f;
    public float Min_height = -1f;
    public float Max_height = 3.5f;
    public GameObject coin;
    int random_check = 0;
    public bool coinAppearCheck;

    private GameObject[] Obstacles;
    private int current_Obstacle = 0;

    private Vector2 obstacle_Position = new Vector2(-15, -25);
    private float spawnXPosition = 1f;

    private float timeSinceLastSpawned;


    void Start()
    {
        timeSinceLastSpawned = 0f;
        coinAppearCheck = false;
        random_check = Random.Range(ObstaclePoolSize, 1);
        Obstacles = new GameObject[ObstaclePoolSize];
        for (int i = 0; i < ObstaclePoolSize; i++)
        {
            if (i == random_check - 1)
            {
                Obstacle2.SetActive(true);
                Obstacles[i] = (GameObject)Instantiate(Obstacle2, obstacle_Position, Quaternion.identity);
            }
            else
            {
                Obstacles[i] = (GameObject)Instantiate(Obstacle, obstacle_Position, Quaternion.identity);
            }
        }
    }

        void Update()
        {
            timeSinceLastSpawned += Time.deltaTime;

            if (timeSinceLastSpawned >= spawn_Rate)
            {
                timeSinceLastSpawned = 0f;

                float spawnYPosition = Random.Range(Min_height, Max_height);

                Obstacles[current_Obstacle].transform.position = new Vector2(spawnXPosition, spawnYPosition);

                current_Obstacle++;

                if (current_Obstacle >= ObstaclePoolSize)
                {
                    current_Obstacle = 0;
                }
            }
        }
    
}

