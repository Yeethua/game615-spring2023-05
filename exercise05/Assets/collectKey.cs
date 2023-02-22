using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class collectKey : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI TimerText;
    
    public int score;
    public int IntTimeLeft;
    public bool GameOn = false;

    public GameObject doorObj;
    public ParticleSystem particles;
    public Transform doorpivot;

    public GameObject jumpScare;
   
    

    public bool rotating = true;
    
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        score = 1;
        TimerOn = true;
        GameOn = true;
        TimeLeft = 120;
        doorObj = GameObject.Find("door");
        particles.Stop();
        jumpScare.SetActive(false);
        
        
        

    }

    // Update is called once per frame
    void Update()
    {

        if (TimerOn)
        {
            if (TimeLeft > 0 && score < 6)
            {
                TimeLeft -= Time.deltaTime;
                IntTimeLeft = (int)Mathf.Round(TimeLeft);
                TimerText.text = IntTimeLeft.ToString();
                //doorObj.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);

                //doorObj.transform.RotateAround(doorpivot.position, Vector3.back, 10 * Time.deltaTime);
                

            }
            else if (TimeLeft > 0 && score == 6)
            {
                
                GameOn = false;
                //rotate door
                rotateDoor();
                if (doorObj.transform.eulerAngles.z < 270)
                {
                    rotating = false;
                }


            }
            else
            {
                TimeLeft = 0;
                TimerText.text = TimeLeft.ToString();
                //IntTimeLeft = (int)Mathf.Round(TimeLeft);
                //TimerOn = false;
                
                GameOn = false;

                //Destroy(doorObj);


                

                //if (rotating)
                //{
                //    Vector3 to = new Vector3(0, -90, 0);
                //    if (Vector3.Distance(doorObj.transform.eulerAngles, to) > 0.01f)
                //    {
                //        doorObj.transform.eulerAngles = Vector3.Lerp(doorObj.transform.rotation.eulerAngles, to, Time.deltaTime);
                //    }
                //    else
                //    {
                //        doorObj.transform.eulerAngles = to;
                //        rotating = false;
                //    }
                //}
                

                
                //doorObj.transform.Translate(Time.deltaTime * moveX, moveY * Time.deltaTime, 0);

                







            }
        }
    }
    public void rotateDoor()
    {
        if(rotating == true)
        {
            doorObj.transform.RotateAround(doorpivot.position, Vector3.back, 10 * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("key"))
        {
            Destroy(other.gameObject);
            particles.Play();
            ScoreText.text = score.ToString();
            score++;


        } else if (other.CompareTag("monster"))
        {
            jumpScare.SetActive(true);
        }
    }

    
}
