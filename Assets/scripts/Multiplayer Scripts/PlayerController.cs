using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    
    int score = 0, final = 0, coins = 0;

    Rigidbody2D rb;
    private Animator anim;
    PhotonView view;
    MulgameManager mulgameManager_Scripts;


    public Text Nickname;


    GameObject death_particles;
    bool alive;
    bool p_count;
    bool f_called;

    string OtherP_name="default";

    void Start()
    {
        p_count = true;
        view = GetComponent<PhotonView>();
        alive = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        mulgameManager_Scripts = FindObjectOfType<MulgameManager>();
        //score_text.text = score.ToString();
        death_particles = transform.GetChild(0).gameObject;

        if(view.IsMine)
        {
            Nickname.text = PhotonNetwork.NickName;
            gameObject.name = Nickname.text;
        }
        else
        {
            Nickname.text = view.Owner.NickName;
            OtherP_name = view.Owner.NickName;
        }
        if (!view.IsMine)
        {
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        
        
    }

    void Update()
    {
        if (view.IsMine )
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.up * 4f;
            }

            if (!alive)
            {
                if (p_count)
                {
                    Spawnplayer.Instance.Dec_count();
                    p_count = false;
                }
                // Destroy(gameObject, 0.1f);

                if (!f_called)
                {
                    Invoke("player_des", 0.1f);
                    f_called = true;
                }
          
            }
        }
    }

    void player_des()
    {

         mulgameManager_Scripts.Display_EndPanel(Nickname.text);
         PhotonNetwork.Destroy(gameObject);
       
    }     

    void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.tag == "ground")
            {
                int pre = PlayerPrefs.GetInt("best");

                if (pre < final)
                {
                    PlayerPrefs.SetInt("best", final);
                    // best_text.text = "Best: " + final.ToString();
                }
                else
                {
                    // best_text.text = "Best: " + pre.ToString();
                }


                //end_pannel.SetActive(true);
                // final_score.text = "SCORE: " + final;


                death_particles.GetComponent<ParticleSystem>().Play();
                death_particles.transform.parent = null;

                alive = false;
            }
            if (collision.tag == "obstacle")
            {
                score++;
                final = score;
                //score_text.text = score.ToString();
            }
            if (collision.gameObject.tag == "coin")
            {
                coins++;
                // coint_text.text = coins.ToString();

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
                    //best_text.text = "Best: " + final.ToString();
                }
                else
                {
                    // best_text.text = "Best: " + pre.ToString();
                }


                //  end_pannel.SetActive(true);
                // final_score.text = "SCORE: " + final;



                death_particles.GetComponent<ParticleSystem>().Play();
                death_particles.transform.parent = null;

                alive = false;
           }
        
    }
}