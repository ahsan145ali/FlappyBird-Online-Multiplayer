using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering;
public class Lighting : MonoBehaviour
{
    
    public List<Color> colors = new List<Color>();
    public GameObject Spawned_Obs;
    public Volume pp; // post processing
    float lerp = 0.0f;
    float intensity = 0;
    bool nightTime;
    bool DayTime;
    bool ChangeTime;

    public List<GameObject> lamplights = new List<GameObject>();
    public GameObject stars;

    int timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        nightTime = false;
        DayTime = true;
        ChangeTime = false;
        //Global_Light.color = Noon;
        StartCoroutine(Change_TO_Night());
        StartCoroutine(Change_To_Day());
        StartCoroutine(Change_Time());

       // Global_Light.color = Color.Lerp(Day, Noon, 0.6f);
    }

    private void Update()
    {

    }
    IEnumerator Change_TO_Night()
    { 
        while (true)
        {
            if (ChangeTime && intensity <=1f)//nightTime && intensity <=1f && !DayTime)
            {
                intensity  = intensity + 0.01f; 
                pp.weight = intensity;
                if(intensity >=0.7f)
                {
                    stars.SetActive(true);

                    foreach (GameObject temp in lamplights)
                    {
                        temp.SetActive(true);
                    }

                    // Set Spotloghts on
                    if(Spawned_Obs.transform.childCount > 0)
                    {
                        var lights = Spawned_Obs.GetComponentsInChildren<Light2D>();

                        foreach (Light2D temp in lights)
                        {
                            temp.enabled = true;
                            temp.color = colors[Random.Range(0, colors.Count - 1)];
                        }
                    }


                    //End
                }
                yield return new WaitForSeconds(0.03f);
            }

            
         

            yield return null;
        }
    }

    IEnumerator Change_To_Day()
    {
        while (true)
        {
            if (!ChangeTime && intensity >=0f)//!nightTime && intensity > 0f && DayTime)
            {
                intensity = intensity - 0.01f; 
                pp.weight = intensity;
                if (intensity <= 0.4)
                {
                    stars.SetActive(false);

                    foreach (GameObject temp in lamplights)
                    {
                        temp.SetActive(false);
                    }

                    // Set Spotloghts off
                    if (Spawned_Obs.transform.childCount > 0)
                    {
                        var lights = Spawned_Obs.GetComponentsInChildren<Light2D>();

                        foreach (Light2D temp in lights)
                        {
                            temp.enabled = false;
                          
                        }
                    }


                    //End
                }
                yield return new WaitForSeconds(0.03f);
            }
          
          

            yield return null;
        }
    }

    IEnumerator Change_Time()
    {
        while(true)
        {
            timer++;
            if(timer >= 10 && ChangeTime == false)
            {
                ChangeTime = true;
                timer = -10;
            }
            else if(timer >=10 && ChangeTime == true)
            {
                ChangeTime = false;
                timer = -10;
            }


            /*
            if(ChangeTime == true && timer >=10)
            {
                nightTime = true;
                DayTime = false;
                timer = -10;
            }
            else if(ChangeTime == false && timer >=10)
            {

                nightTime = false;
                DayTime = true;
                timer = -10;
            }*/



            yield return new WaitForSeconds(1f);
        }
    }
}
