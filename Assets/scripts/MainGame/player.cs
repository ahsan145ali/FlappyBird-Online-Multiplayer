using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    int score = 0, final = 0,coins = 0;
    public Rigidbody2D players;
    private Animator anim;

    //UI
    public Text score_text;
    public Text final_score;
    public Text coint_text;
    public Text best_text;
    public GameObject end_pannel;
    
    //particle
    GameObject death_particles;
    
    bool alive;

    //Sounds
    public GameObject Tap_sound;
    public GameObject Hit_sound;
    public GameObject Coin_Sound;

    //Instance
    public static player Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        alive = true;
        anim = GetComponent<Animator>();
        score_text.text = score.ToString();
        death_particles = transform.GetChild(0).gameObject;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CameraEffect.Instance.execute == true)
        {
            Tap_sound.GetComponent<AudioSource>().Play();
            players.velocity = Vector2.up * 4f;
        }

        if (!alive)
        {
            Hit_sound.GetComponent<AudioSource>().Play();
            Destroy(gameObject,0.1f);    
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            int pre = PlayerPrefs.GetInt("best");

            if (pre < final)
            {
                PlayerPrefs.SetInt("best", final);
                best_text.text = "Best: " + final.ToString();
            }
            else
            {
                best_text.text = "Best: " + pre.ToString();
            }


            end_pannel.SetActive(true);
            final_score.text = "SCORE: " + final;

           
            death_particles.GetComponent<ParticleSystem>().Play();
            death_particles.transform.parent = null;

            alive = false;
        }
        if (collision.tag == "obstacle")
        {
            score++;
            final = score;
            score_text.text = score.ToString();
        }
        if(collision.gameObject.tag == "coin")
        {
            Coin_Sound.GetComponent<AudioSource>().Play();
            coins++;
            coint_text.text = coins.ToString();

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            int pre = PlayerPrefs.GetInt("best");

            if (pre < final)
            {
                PlayerPrefs.SetInt("best", final);
                best_text.text = "Best: " + final.ToString();
            }
            else
            {
                best_text.text = "Best: " + pre.ToString();
            }


            end_pannel.SetActive(true);
            final_score.text = "SCORE: " + final;


            
            death_particles.GetComponent<ParticleSystem>().Play();
            death_particles.transform.parent = null;

            alive = false;
        }
    }

    public void Set_Gravity()
    {
        players.gravityScale = 1;
    }
    public bool Alive_status()
    {
        return alive;
    }
    }