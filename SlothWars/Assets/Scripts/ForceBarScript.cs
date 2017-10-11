﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceBarScript : MonoBehaviour {
    public Image currentForce;
    private double ratio= 0f;
    private float stps = 0.4f;
    RectTransform rt;
    private bool up= true;
	// Initialization
	void Start () {
        rt = (RectTransform)GetComponent<RectTransform>();
        rt.rotation = new Quaternion(0, 0, 0, 0);
        rt = (RectTransform) rt.Find("currentForce");
    }
	
	// Increase/decrease bars size stps per second
	void Update () { 
        if (up)
        {
            ratio += stps * Time.deltaTime;
            if (ratio > 1)
            {
                ratio -= 2*stps * Time.deltaTime;
                up = false;
            }
        }
        else
        {
            ratio -= stps * Time.deltaTime;
            if (ratio < 0)
            {
                ratio += 2*stps * Time.deltaTime;
                up = true;
            }
        }
        rt.localScale = new Vector3((float)ratio, 1, 1);
    }
    // Returns the force associated to the bar
    public float getForce()
    {
        return (float) ratio;
    }
    // Destroys the game object associated to the script
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
