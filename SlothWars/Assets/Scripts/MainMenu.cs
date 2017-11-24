﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    //If this is necessary in the future
    protected MainMenu() { }

    private Image panelMain;
    private Image panelVS;
    private Image panelOpts;


    // Use this for initialization
    void Awake()
    {
        //panelinit
        InitializeMainMenuVariables();
    }

    private void InitializeMainMenuVariables()
    {
        panelMain = GameObject.Find("mainMenuPanel").GetComponent<Image>();
        panelVS = GameObject.Find("playVSPanel").GetComponent<Image>();
        panelOpts = GameObject.Find("OptionsPanel").GetComponent<Image>();
    }

    private void Start()
    {
        panelVS.gameObject.SetActive(false);
        panelOpts.gameObject.SetActive(false);
    }

    public void PlaySelected()
    {
        panelMain.gameObject.SetActive(false);
        panelVS.gameObject.SetActive(true);
    }
    //this should go to new screen
    public void PlaySoloSelected()
    {
        SceneManager.LoadScene("TeamSelection");
    }
    //this should go 
    public void PlayFriendSelected()
    {
        SceneManager.LoadScene("TeamSelection");
    }
    public void GoBackPlay()
    {
        panelMain.gameObject.SetActive(true);
        panelVS.gameObject.SetActive(false);
    }
    public void ShowOptions()
    {
        panelMain.gameObject.SetActive(false);
        panelOpts.gameObject.SetActive(true);
    }

    public void GoBackOptions()
    {
        panelMain.gameObject.SetActive(true);
        panelOpts.gameObject.SetActive(false);
    }

    //Use this method to load any scene.
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);

    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowSlothapedia(){
        SceneManager.LoadScene("Slothapedia");
    }
}