﻿using UnityEngine;
using System.Collections;

public class LoadQuizTwoBad : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if (Fire.MinusScoe > 0) 
		{
			ScoreManager.SubtractFromScore(Fire.MinusScoe, "You stepped in fire.");
		}
		
		if (StandInSmoke.MinusScoe > 0) 
		{
			ScoreManager.SubtractFromScore(StandInSmoke.MinusScoe, "You did not crawl through the smoke.");
		}
		
		ScoreManager.SubtractFromScore(10, "The street is not a good meeting place.");
		GameManager.QuizTwo = true;
		Application.LoadLevel(1);
	}
}