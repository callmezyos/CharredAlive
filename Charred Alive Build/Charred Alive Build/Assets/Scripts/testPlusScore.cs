using UnityEngine;
using System.Collections;

public class testPlusScore : MonoBehaviour {

	private bool hasEntered = false;
	private int plusScore = 1;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (!hasEntered) 
		{
			print ("Entered green once, and hasEntered = " + hasEntered);
			ScoreManager.AddToScore(plusScore, "You did good.");
			hasEntered = true;
		}
	}
}
