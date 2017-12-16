﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AbilityModel {
    //SINGLETON
    private static AbilityModel instance;

    public static AbilityModel Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AbilityModel();
            }
            return instance;
        }
    }
    ///////*****///////
    private Button firstAbility, secondAbility, thirdAbility;
    private List<Button> listAbilities;
    private bool beginStopped;
    private int turnPlayer1, turnPlayer2;
    private Ability lastAbility;

    protected AbilityModel() { }


    public void SetFirstAbility(Button firstAbilityCont) { firstAbility = firstAbilityCont; }
    public Button GetFirstAbility() { return firstAbility; }

    public void SetSecondAbility(Button secondAbilityCont) { secondAbility = secondAbilityCont; }
    public Button GetSecondAbility() { return firstAbility; }

    public void SetThirdAbility(Button thirdAbilityCont) { thirdAbility = thirdAbilityCont; }
    public Button GetThirdAbility() { return thirdAbility; }

    public void SetListAbilities(List <Button> listAbilitiesCont) { listAbilities = listAbilitiesCont; }
    public List<Button> GetListAbilities() { return listAbilities; }

    public void SetBeginStopped(bool beginStoppedFromTurns) { beginStopped = beginStoppedFromTurns; }
    public bool GetBeginStopped() { return beginStopped; }

    public void SetTurnPlayer1(int turnPlayer1FromTurns) { turnPlayer1 = turnPlayer1FromTurns; }
    public int GetTurnPlayer1() { return turnPlayer1; }

    public void SetTurnPlayer2(int turnPlayer2FromTurns) { turnPlayer2 = turnPlayer2FromTurns; }
    public int GetTurnPlayer2() { return turnPlayer2; }

    public void SetLastAbility(Ability onLastAbility) { lastAbility = onLastAbility; }
    public Ability GetLastAbility() { Debug.Log(lastAbility); return lastAbility; }

    public void DeactivateButtonsIfNecessary(int ab1ap, int ab2ap, int ab3ap, int currentAp){
        //AbilityController.Instance.DeactivateButtonsIfNecessary(ab1ap, ab2ap, ab3ap, currentAp);
    }

}
