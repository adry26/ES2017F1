﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class StorePersistentVariables : PersistentVariablesSingleton<StorePersistentVariables> {

    // Here we will have the variables that we want to persist between scenes. In our case,
    // it will be the sloth teams created in TeamSelection scene.

    /* 
     To refer to this variables in any cs file, you have to put the code below:

        if you want to set it:
            StorePersistentVariables.Instance.NAMEPERSISTENTVALUE = value;
        if you want to get it:
            value = StorePersistentVariables.Instance.NAMEPERSISTENTVALUE;
    
    */

    // PERSISTENT (PUBLIC) VARIABLES HERE:
	public List<Sloth> slothTeam1 = new List<Sloth>();
	public List<Sloth> slothTeam2 = new List<Sloth>();
    public string winner = "BatmanWinner";
    
    //

    public static StorePersistentVariables Instance
    {
        get
        {
            return ((StorePersistentVariables)mInstance);
        }
        set
        {
            mInstance = value;
        }
    }
    protected StorePersistentVariables() { }
}