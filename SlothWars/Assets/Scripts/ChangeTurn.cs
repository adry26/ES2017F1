﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTurn : MonoBehaviour
{

    // Getting the sloths in the scene.
    List<GameObject> slothTeamA;
    List<GameObject> slothTeamB;

    
    //GameObject with the script where the sloths are created
    GameObject managerTeam;

    int slothTurnA, slothTurnB;

    // Initially, the friendly sloth has not ended his turn.
    public bool endTurnOfSloth = false;
    public bool beginStopped = true;

    private void Start()
    {

        slothTurnA = 0;
        slothTurnB = 0;

        slothTeamA = new List<GameObject>();

        slothTeamB = new List<GameObject>();

        managerTeam = GameObject.Find("managerTeam");
    }

    private void Update()
    {
        slothTeamA = managerTeam.GetComponent<CreateSloth>().teamA;

        slothTeamB = managerTeam.GetComponent<CreateSloth>().teamB;

    }


    public void DeactivateAllExceptOne(List<GameObject> slothTeamA, List<GameObject> slothTeamB)
    {
        foreach (GameObject sloth in slothTeamB)
        {
            sloth.GetComponent<Animator>().enabled = false;
            sloth.GetComponent<player>().enabled = false;
            sloth.GetComponent<ShotScript>().Active(false); //turn off de canvas UI
            sloth.GetComponent<ShotScript>().enabled = false;
        }

        for (int i = 1; i<slothTeamA.Count; i++)
        {
            slothTeamA[i].GetComponent<Animator>().enabled = false;
            slothTeamA[i].GetComponent<player>().enabled = false;
            slothTeamA[i].GetComponent<ShotScript>().Active(false);
            slothTeamA[i].GetComponent<ShotScript>().enabled = false;
        }
    
    }

    // Functions to activate and deactivate sloth's animations
    private void ActivateSloth(GameObject slothTeam)
    {
        slothTeam.GetComponent<Animator>().enabled = true;
        slothTeam.GetComponent<player>().enabled = true;
        slothTeam.GetComponent<ShotScript>().enabled = true;
        slothTeam.GetComponent<ShotScript>().Active(true);



    }

    private void DeactivateSloth(GameObject slothTeam)
    {
        
        slothTeam.GetComponent<Animator>().enabled = false;
        slothTeam.GetComponent<player>().enabled = false;
        slothTeam.GetComponent<ShotScript>().Active(false);
        slothTeam.GetComponent<ShotScript>().enabled = false;

    
    }

    public void FinishTurn()
    {
        if (beginStopped)
        {
            DeactivateAllExceptOne(slothTeamA,slothTeamB);
            beginStopped = false;
            return;
        }

        // If he has ended, he will press the button, changing the variable to true.
        if (endTurnOfSloth)
        {
            endTurnOfSloth = false;
            DeactivateSloth(slothTeamB[slothTurnB]); // DeactivateSloth(slothTeamB[slothTurnB], gunSlothTeamA[slothTurnB])
            ActivateSloth(slothTeamA[slothTurnA]);
            slothTurnB += 1;
            if(slothTurnB == slothTeamB.Count)
            {
                slothTurnB = 0;
            }
            
            /* If the variable is already true, it means that it is the turn for the enemy sloth.
            If we arrive here it will mean that the enemy sloth has finished his turn, and 
            it will change the variable to false.*/
        }
        else
        {
            endTurnOfSloth = true;
            DeactivateSloth(slothTeamA[slothTurnA]);
            ActivateSloth(slothTeamB[slothTurnB]);
            slothTurnA += 1;
            if (slothTurnA == slothTeamA.Count)
            {
                slothTurnA = 0;
            }

        }
    }

}
