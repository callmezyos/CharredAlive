using UnityEngine;
using System.Collections;

public class FeedbackText : MonoBehaviour {
	
	//SHould move all of this into Overlay.
	private static Color color;
	private static string output = " ";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Overlay.Feedback) 
		{
			guiText.enabled = true;
			if (color != Color.green) 
			{
				guiText.material.color = color/255;
			}
			else
				guiText.material.color = color;
				
			guiText.text = output;
		}
		else
			guiText.enabled = false;
	}
	
	public static void PostiveFeedback(string input)
	{
		Overlay.Feedback = true;
		color = Color.green;
		output = input;
	}
	
	public static void NegativeFeedback(string input)
	{
		Overlay.Feedback = true;
		color = new Color(255, 67, 67, 255);
		output = input;
	}
}
