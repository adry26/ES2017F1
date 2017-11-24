﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicView : MonoBehaviour {

    private LogicModel logicModel;
    private AbilityModel abilityModel;
    private List<GameObject> teamSloths1, teamSloths2;
    private ChangeTurnModel changeTurnModel;
    
    // Use this for initialization
	private void Start () {
        logicModel = new LogicModel();
        abilityModel = new AbilityModel();
        changeTurnModel = new ChangeTurnModel();

        teamSloths1 = logicModel.GetTeamSloths1();
        teamSloths2 = logicModel.GetTeamSloths2();
	}
	
	// Update is called once per frame
	private void Update () {
        if (teamSloths1 != null && teamSloths2 != null)
        {
            CheckSlothsAlive();
            CheckGameOver();
            DeactivateButtonsIfNecessary();
        }
	}

    private void CheckSlothsAlive()
    {
        HealthScript health;
        AnimPlayer pla;
        int i = 0;
        foreach (GameObject sloth in teamSloths1)
        {
            health = sloth.GetComponent<HealthScript>();
            
            if (health.getHealth() <= 0)
            {
                pla = sloth.GetComponent<AnimPlayer>();
                pla.Die();
                teamSloths1.Remove(sloth);
                //REMOVE LISTGUN
            }
            i++;
        }
        i = 0;
        foreach (GameObject sloth in teamSloths2)
        {
            health = sloth.GetComponent<HealthScript>();
            if (health.getHealth() <= 0)
            {
                pla = sloth.GetComponent<AnimPlayer>();
                pla.Die();
                teamSloths2.Remove(sloth);
            }
            i++;
        }
    }

    private void CheckGameOver(){
        if(teamSloths1.Count == 0){
            StorePersistentVariables.Instance.winner = "Blue";
            SceneManager.LoadScene("GameOverScene");
        } else if(teamSloths2.Count == 0){
            StorePersistentVariables.Instance.winner = "Red";
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void DeactivateButtonsIfNecessary(){
        int ab1ap = changeTurnModel.GetCurrentSloth().GetAbility1().GetAp();
        int ab2ap = changeTurnModel.GetCurrentSloth().GetAbility2().GetAp();
        int ab3ap = changeTurnModel.GetCurrentSloth().GetAbility3().GetAp();
        abilityModel.DeactivateButtonsIfNecessary(ab1ap, ab2ap, ab3ap, changeTurnModel.GetApCurrentSloth());
    }
}