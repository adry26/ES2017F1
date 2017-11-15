﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameControl : ControllerSingleton<MonoBehaviour> {
    
    // GameControl instance that you may call from any other script in the scene using GameControl.control 
    // and then you may access to any of its public variables and/or expressions.
    public static GameControl control;

    // List of 'sloths' of each team. List of strings, which are the type of sloth.
    [HideInInspector]
    public List<Sloth> slothTeam1;
    [HideInInspector]
    public List<Sloth> slothTeam2;

    public readonly int maxTeamSloths = 4;

    private void Start()
    {
		slothTeam1 = new List<Sloth>();
		slothTeam2 = new List<Sloth>();
    }
}
