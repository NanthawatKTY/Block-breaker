﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour { 

    //config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;

    //Array
    [SerializeField] AudioClip[] ballSounds;


    //State
    Vector2 paddleToBallVector;
    bool hasStarted = false;


    //Cahced component reference Arraya
    AudioSource myAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
 
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted) //if doesn't click mouse
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick() // if click mouse = 0
    {
        
        if (Input.GetMouseButtonDown(0)) 
        {
            hasStarted = true;    //change hasStarted to true
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x , paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }


    //Audio when the ball bounce everything//

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted) //When the game has started play audio
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
           myAudioSource.PlayOneShot(clip);
        }
    }
}
