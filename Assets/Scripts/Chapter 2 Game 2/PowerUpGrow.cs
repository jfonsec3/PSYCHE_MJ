﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpGrow : MonoBehaviour {
    public float growth = 1.3f;
    public float timer = 10f;
    public string name;
    public string description;

    private Text text;
    private CircleCollider2D cc;
    private SpriteRenderer sr;

    private PowerUp powerUp;

    void Start()
    {
        text = GameObject.Find("powerUpText").GetComponent<Text>();
        powerUp = FindObjectOfType<PowerUp>();
        cc = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();

        text.text = "";   
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            powerUp.Activation(false, false, false, false, 1, growth, timer);
            sr.sprite = null;
            text.text = "Obtained " + name + "! \n" + description;

            StartCoroutine("delay");


        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(3);
        text.text = "";


    }
}