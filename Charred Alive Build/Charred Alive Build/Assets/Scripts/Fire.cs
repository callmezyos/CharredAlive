using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
	//Add to fire when done.
	private bool hasEntered;
	private bool sitInFire;
	
	private static int minusScore;
	public static int MinusScoe { get{ return minusScore;} }
	
	private static float timeElapsed;
	private static float feedbackElapsedTime;
	
	Overlay overLay;
	
	// Use this for initialization
	void Start () 
	{
		overLay = GameObject.Find ("Overlay").GetComponent<Overlay>();
		minusScore = 0;
		hasEntered = true;
		feedbackElapsedTime = 1.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (feedbackElapsedTime < 1.0f) 
		{
			if (!sitInFire) 
			{
				feedbackElapsedTime += Time.deltaTime;
			}
			
			FeedbackText.NegativeFeedback("You shouldn't stand in fire.");
		}
		else if(!hasEntered && feedbackElapsedTime > 1.0f)
		{
			Overlay.Feedback = false;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player")
		{
			feedbackElapsedTime = 0.0f;
			hasEntered = true;
			overLay.InFire = true;
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.name == "Player") 
		{
			overLay.InFire = true;
			hasEntered = true;
			
			sitInFire = true;
			
			if (sitInFire) 
			{
				feedbackElapsedTime = 0.0f;
			}
			
			timeElapsed += Time.deltaTime;
			if (timeElapsed >= .5f && minusScore < 10) 
			{
				minusScore++;
				timeElapsed = 0;
			}
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "Player")
		{
			feedbackElapsedTime = 0.0f;
			hasEntered = false;
			overLay.InFire = false;
			sitInFire = false;
		}
	}
}
