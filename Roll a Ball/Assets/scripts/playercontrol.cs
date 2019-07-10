using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class playercontrol : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;
    public Text livesText;
    public GameObject exitramp;

    private Rigidbody rb;
    private int count;
    private int lives;

    public Text ScoreText { get => scoreText; set => scoreText = value; }

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        
        count = 0;
        lives = 3;
        SetCountText ();
        
        winText.text = "";
    }

    private void SetCountText()
    {
        throw new NotImplementedException();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
        if (Input.GetKey("escape"))
     Application.Quit();

    }
 void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        } 
        
         if (other.gameObject.CompareTag ("Enemy"))
         {
             other.gameObject.SetActive(false);
             count = count - 1;
             lives = lives - 1;
             SetCountText ();
            

         }
        void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 6)
        {
           exitramp.SetActive(true);
        }
        if (count>=14)
        {  winText.text = "You Win!";}

    }
    }
}