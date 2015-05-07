using UnityEngine;
using System.Collections;

public class ExitGood : MonoBehaviour {
	
	public static bool left;
	private static float elapsedTime;
	// Use this for initialization
	void Start () {
		left = false;
		elapsedTime = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Overlay.Feedback && left) 
		{
			elapsedTime += Time.deltaTime;
		}
		
		if (elapsedTime >= 2.0f && left) 
		{
			elapsedTime = 0f;
			Overlay.Feedback = false;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player") 
		{
			if (!left) 
			{
				ScoreManager.AddToScore(15, "Taking the first floor door was a good decision.");
				left = true;
			}
			
			FeedbackText.PostiveFeedback("First floor exits are the safest.");
			
			Debug.Log ("Took good exit.");
		}
	}
}
