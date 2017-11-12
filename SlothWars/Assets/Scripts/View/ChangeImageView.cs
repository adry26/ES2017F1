﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageView : MonoBehaviour {

    private ChangeImageModel changeImageModel;
    public Sprite newSprite;
    
    private void Awake () {
        changeImageModel = new ChangeImageModel();
        
        //There are some bugs with the Unity Version. It should detect the GameObject.Find as 
        //it inherits from MonoBehaviour. Therefore, it shows us an error as it could not 
        //find the gameobject (it is null). (It puts something like Should not be capturing
        // as it is a hotControl).
        newSprite = GameObject.Find("AbilitiesPanel").GetComponentsInChildren<Image>()[1].sprite;
    }
	
	private void Update () {
    }

    // Method to show the image in the scene. Called by end turn Button in order to show the image corresponding to the sloth's turn.
    public void ShowImage()
    {
       newSprite = changeImageModel.GetSprite();
    }
}
