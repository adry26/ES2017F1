﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NUnit.Framework;

public class SetUp : GameController {
    // Use this for initialization
    
    void Start () {
        PlacePlayers();
	}



	private void PlacePlayers(){ 
		GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
		plane.transform.localScale = new Vector3 (100, 1, 100);
		int i = 0;
		GameObject sloth;
		Player pla;
		HealthScript health;
		Animator anim;
		ShotScript shot;
		SlothSelected selected;
        print(GetPlayerTeam(1)[1].GetType());
		foreach(Player playerSloth in GetPlayerTeam(1)){
			sloth = (GameObject) Instantiate (Resources.Load ("Prefabs/Sloth"), new Vector3 (i+2, 0, 0), Quaternion.identity);
			// setting health
			health = sloth.AddComponent <HealthScript>();
			health.setHealth (playerSloth.GetSloth ().GetHp ());
			health.enabled = true;
			//Start the animation
			anim = sloth.GetComponent <Animator>();
			anim.enabled = true;

			pla = sloth.GetComponent<Player>();
			pla.SetSloth (playerSloth.GetSloth());
			pla.enabled = true;

			shot = sloth.GetComponent <ShotScript>();
			shot.enabled = true;

			selected = sloth.AddComponent <SlothSelected> ();
			selected.enabled = false;
			teamSloths1.Add (sloth);

			i++;
		}
		i = 0;
		foreach (Player playerSloth in GetPlayerTeam(2)) {
			sloth = (GameObject) Instantiate (Resources.Load ("Prefabs/Sloth"), new Vector3 (-i-2, 0, 0), Quaternion.identity);
			// setting health
			health = sloth.AddComponent <HealthScript>();
			health.setHealth (playerSloth.GetSloth ().GetHp ());
			health.enabled = true;
			//Start the animation
			anim = sloth.GetComponent <Animator>();
			anim.enabled = true;

			pla = sloth.GetComponent <Player> ();
			pla.SetSloth (playerSloth.GetSloth ());
			pla.enabled = true;

			shot = sloth.GetComponent <ShotScript>();
			shot.enabled = true;

			selected = sloth.AddComponent <SlothSelected> ();
			selected.enabled = false;

			teamSloths2.Add (sloth);
			i++;
		}
	}
}
