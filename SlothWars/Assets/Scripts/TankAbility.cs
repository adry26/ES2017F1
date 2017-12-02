﻿using System;
using SimpleJSON;
using UnityEngine;
public class TankAbility : Ability
{
    private bool shield;
    private double boostDef;
    private int durBoostDef;
    private double boostHp;
    private int durBoostHp;
    private double hpShield;
    private bool blockAb;
    private int ap;

    public TankAbility(string id, JSONNode json)
    {

        this.shield = json[id]["shield"];
        this.boostDef = json[id]["boostDef"];
        this.durBoostDef = json[id]["durBoostDef"];
        this.boostHp = json[id]["boostHp"];
        this.durBoostHp = json[id]["durBoosthp"];
        this.hpShield = json[id]["hpShield"];
        this.blockAb = json[id]["blockAb"];
        this.ap = json[id]["ap"];
    }

    //Apply ability to another sloth
    public void Apply(ref Sloth target)
    {

    }

    //WIP: apply ability to terrain
    public void Apply(GameObject g)
    {
    }
    public void Apply(Vector3 p) { }
    public float GetRange()
    {
        return 10;
    }
    public float GetRadius()
    {
        return 1;
    }
    public bool GetBuildTerrain() { return false; }
    public int GetTerrainSize() { return 0; }
	public int GetAp(){
        return ap;
    }

    public bool GetAlterTerrain()
    {
        return false;
    }
}