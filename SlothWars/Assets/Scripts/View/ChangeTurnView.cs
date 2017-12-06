﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTurnView: MonoBehaviour {

    private ChangeTurnModel changeTurnModel;
    private AbilityModel abilityModel;
    private bool endTurnOfPlayer;
    private static bool beginStopped;
    private static int playerTurn1, playerTurn2;
    private static List<GameObject> playersTeam1, playersTeam2;
    private List<Sloth> slothTeam1, slothTeam2;
    private Button endTurnButton;

    private void Start()
    {
        changeTurnModel = ChangeTurnModel.Instance;
        abilityModel = AbilityModel.Instance;

        endTurnButton = changeTurnModel.GetEndTurnButton();

        playersTeam1 = new List<GameObject>();
        playersTeam2 = new List<GameObject>();
        
        slothTeam1 = StorePersistentVariables.Instance.slothTeam1;
        slothTeam2 =StorePersistentVariables.Instance.slothTeam2;
        
    }
    private void Update()
    {
        
        if (playersTeam1.Count == 0) {
            //ChangeUIStats();
            UpdateSlothTeams();
            FinishTurn();
            
        }
        FixedBugs();
        
    }
     
    //Method to update the teams.
    private void UpdateSlothTeams()
    {
        foreach(GameObject player in changeTurnModel.GetTeam1())
        {
            playersTeam1.Add(player);
        }
        foreach(GameObject player in changeTurnModel.GetTeam2())
        {
            playersTeam2.Add(player);
        }
    }

    // Function in order to change turns.
    // TODO Probar cuando mueren perezosos y se actualiza la lista. Si no hay perezosos en el mapa
    // Asegurarse de que se acabe la partida antes de llamar a esta funcion.
    public void FinishTurn()
    {
        playerTurn1 = changeTurnModel.GetTurnPlayer1();
        playerTurn2 = changeTurnModel.GetTurnPlayer2();
        beginStopped = changeTurnModel.GetBeginStopped();

        abilityModel.SetBeginStopped(beginStopped);
        abilityModel.SetTurnPlayer1(playerTurn1);
        abilityModel.SetTurnPlayer2(playerTurn2);

        endTurnOfPlayer = changeTurnModel.GetEndTurnOfPlayer();

        // If he has ended, he will press the button, changing the variable to true.
        if (beginStopped)
        {

            changeTurnModel.GetText().text = "Blue Turn";
            changeTurnModel.DeactivateAllExceptOne(playersTeam1, playersTeam2);
            changeTurnModel.SetCurrentSloth(slothTeam1[playerTurn1]);
            changeTurnModel.SetApCurrentSloth(slothTeam1[playerTurn1].GetAp());
            changeTurnModel.SetCurrentTurn(1, playerTurn1);
            ChangeUIStats();
            return;
        }

        if (endTurnOfPlayer)
        {
            changeTurnModel.GetText().text = "Blue Turn";
            if (playerTurn2 != 0)
            {
                changeTurnModel.DeactivateSloth(playersTeam2[playerTurn2 - 1]);

            }
            else if (playerTurn1 == playerTurn2)
            {
                changeTurnModel.DeactivateSloth(playersTeam2[playersTeam2.Count - 1]);

            }
            else 
            {
                changeTurnModel.DeactivateSloth(playersTeam2[playerTurn2]);
            }

            changeTurnModel.SetTeams(playersTeam1,playersTeam2);
            changeTurnModel.ActivateSloth(playersTeam1[playerTurn1]);
            changeTurnModel.SetCurrentTurn(1, playerTurn1);
            changeTurnModel.SetCurrentSloth(slothTeam1[playerTurn1]);
            changeTurnModel.SetApCurrentSloth(slothTeam1[playerTurn1].GetAp());
            ChangeUIStats();

        }
        else
        {
            
            changeTurnModel.GetText().text = "Red Turn";
            if (playerTurn1 != 0)
            {
                changeTurnModel.DeactivateSloth(playersTeam1[playerTurn1 - 1]);
                playersTeam1[playerTurn1 - 1].GetComponent<AnimPlayer>().GetComponent<SlothSelected>().enabled = false;

            } else if (playerTurn2 > playerTurn1)
            {
                changeTurnModel.DeactivateSloth(playersTeam1[playerTurn2]);
                playersTeam1[playerTurn2].GetComponent<AnimPlayer>().GetComponent<SlothSelected>().enabled = false;
            }
            else
            {
                changeTurnModel.DeactivateSloth(playersTeam1[playerTurn1]);
            }
            changeTurnModel.ActivateSloth(playersTeam2[playerTurn2]);
            changeTurnModel.SetCurrentTurn(2, playerTurn2);
            changeTurnModel.SetCurrentSloth(slothTeam2[playerTurn2]);
            changeTurnModel.SetApCurrentSloth(slothTeam2[playerTurn2].GetAp());
            ChangeUIStats();
        }
           
    }

    private void ChangeUIStats(){
        GameObject.Find("AbilitiesPanel").GetComponentsInChildren<Text>()[0].text = changeTurnModel.GetCurrentSloth().GetHp().ToString();
        GameObject.Find("AbilitiesPanel").GetComponentsInChildren<Text>()[1].text = changeTurnModel.GetCurrentSloth().GetAttack().ToString();
        GameObject.Find("AbilitiesPanel").GetComponentsInChildren<Text>()[2].text = changeTurnModel.GetCurrentSloth().GetDefense().ToString();
        GameObject.Find("AbilitiesPanel").GetComponentsInChildren<Text>()[3].text = changeTurnModel.GetCurrentSloth().GetAp().ToString();
    }
    private void FixedBugs()
    {
        // if a sloth is walking, the user cannot end the turn (Disable the end turn button)

        if (playersTeam1[playerTurn1].GetComponent<AnimPlayer>().IsMoving() || playersTeam2[playerTurn2].GetComponent<AnimPlayer>().IsMoving())
        {
            endTurnButton.interactable = false;
        }
        else
        {
            endTurnButton.interactable = true;
        }

        // if a sloth is shooting, the user cannot end the turn (Disable the end turn button)
        if (playersTeam1[playerTurn1].GetComponent<ShotScript>().GetShotLoad() || playersTeam2[playerTurn2].GetComponent<ShotScript>().GetShotLoad())
        {
            endTurnButton.interactable = false;
        }
        else
        {
            endTurnButton.interactable = true;
        }
    }
    

}
