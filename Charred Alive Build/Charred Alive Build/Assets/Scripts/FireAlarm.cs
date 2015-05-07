using UnityEngine;
using System.Collections;

public class FireAlarm : MonoBehaviour {
	
	bool active = false;
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("e") && active)
		{
			transform.parent.gameObject.animation.Play("AlarmDown");
			if (!GameManager.FireAlarm)
			{
				ScoreManager.AddToScore(10, "Good job you activated the fire alarm.");
				GameManager.FireAlarm = true;
				print ("Fire Alarm added to score.");
			}
		}
		
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "Player")
		{
			active = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "Player") 
		{
			active = false;
		}
	}
}
