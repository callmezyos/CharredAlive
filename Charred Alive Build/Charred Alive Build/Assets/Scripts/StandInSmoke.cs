using UnityEngine;
using System.Collections;

public class StandInSmoke : MonoBehaviour {
	private bool hasEntered;
	private bool sitInSmoke;
	
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
			if (!sitInSmoke) 
			{
				feedbackElapsedTime += Time.deltaTime;
			}
			
			FeedbackText.NegativeFeedback("Standing in smoke is bad for you.");
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
			overLay.InSmoke = true;
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.name == "Player") 
		{
			overLay.InSmoke = true;
			hasEntered = true;
			
			sitInSmoke = true;
			
			if (sitInSmoke) 
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
			overLay.InSmoke = false;
			sitInSmoke = false;
		}
	}
}
