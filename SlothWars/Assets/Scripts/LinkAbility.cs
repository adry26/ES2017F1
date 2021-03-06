﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class LinkAbility : Ability
{
    private int ap;
    private string projectile;
    private string source;
    private bool mark;
    private Sloth link = null;
    private float range;
    private GameObject linkObject = null;
    public LinkAbility(string id, JSONNode json)
    {
        this.mark = json[id]["mark"];
        this.ap = json[id]["ap"];
        this.projectile = json[id]["projectile"];
        this.range = json[id]["reach"];
    }

    //Apply ability to another sloth
    public void Apply(ref Sloth target)
    {
   
    }

    //WIP: apply ability to terrain
    public void Apply(GameObject g)
    {
        if(link != null)
        {
            link.QuitTank();
            GameObject.Destroy(linkObject);
        }
        link = g.GetComponent<Sloth>();
        linkObject = (GameObject)GameObject.Instantiate(Resources.Load("Objects/LightningBolt/Link"), g.transform.position, Quaternion.identity);
        g.GetComponent<Sloth>().SetTank(Camera.main.GetComponent<GameController>().GetCurrentSloth());
        linkObject.GetComponent<LinkScript>().SetOrigin(Camera.main.GetComponent<GameController>().GetCurrentSloth().transform);
        linkObject.GetComponent<LinkScript>().SetEnd(g.transform);
    }
    public void Apply(Vector3 p) {
    }
    public float GetRange()
    {
        return range;
    }
    public float GetRadius()
    {
        return 1;
    }
    public bool GetBuildTerrain() { return false; }
    public int GetTerrainSize() { return 0; }
    public int GetAp()
    {
        return ap;
    }
    public bool GetMark() { return this.mark; }
    public bool GetAlterTerrain()
    {
        return false;
    }
    public string GetProjectile()
    {
        return projectile;
    }
    public bool GetExplosive()
    {
        return false;
    }
    public string GetSource()
    {
        return source;
    }
}