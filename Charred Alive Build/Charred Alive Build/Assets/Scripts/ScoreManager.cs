using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour {
	static List<Actions> actionsToDisplay = new List<Actions>();
	public static IEnumerable<Actions> ActionsToDisplay{ get {return actionsToDisplay;} }
	static Actions actions;
	
	private string blank = " ";
	private int totalScore;
	
	GUIText correctActions;
	GUIText wrongActions;
	GUIText score;
	GUIText passed;
	
	bool updateGUI;
	
	Rect exit = new Rect(80, 450, 100, 50);
	Rect restart = new Rect(200, 450, 100, 50);
	
	bool pass = false;
	bool fail = false;
	
	public static void AddToScore(int plusScore, string afterActionText)
	{
		actions = new Actions(plusScore, afterActionText); 
		actionsToDisplay.Add (actions);
	}
	
	public static void AddQuizToScore(int score, int prevScore, string afterActionText)
	{
		if (score > prevScore && actionsToDisplay.Count != 0) 
			actionsToDisplay[0] = new Actions(score, afterActionText);
		else if(actionsToDisplay.Count == 0)
			actionsToDisplay.Add(new Actions(score, afterActionText));
	}
	
	public static void SubtractFromScore(int minusScore, string afterActionText)
	{
		minusScore*= -1;
		actions = new Actions(minusScore, afterActionText);
		actionsToDisplay.Add (actions);
	}
	
	public static void ResetActions()
	{
		actionsToDisplay.Clear();
	}
	// Use this for initialization
	void Start () 
	{
		correctActions = GameObject.Find ("CorrectActions").GetComponent<GUIText>();
		wrongActions = GameObject.Find("WrongActions").GetComponent<GUIText>();
		score = GameObject.Find("Score").GetComponent<GUIText>();
		passed = GameObject.Find("Passed").GetComponent<GUIText>();
		updateGUI = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnGUI()
	{
		if (actionsToDisplay != null && updateGUI) 
		{
			foreach (Actions action in actionsToDisplay)
			{
				if (action.Positive != blank)
				{
					correctActions.text += "\n" + action.Positive;
				}
				
				if (action.Negative != blank) 
				{
					wrongActions.text += "\n" + action.Negative;
				}
				totalScore += action.Score;
			}
			
			if (totalScore < 0)
				totalScore = 0;
			
			score.text += "\n" + totalScore.ToString() + " / 100";
			updateGUI = false;
		}
		
		if (totalScore >= 80) 
		{
			passed.text = "Congratulations!!! Now, you know your fire safety.";
			pass = true;
			fail = false;
		}
		else if(totalScore < 80)
		{
			passed.text = "Sorry!!! It looks like you still have more to learn about fire safety.";
			pass = false;
			fail = true;
		}
		
		if (fail || pass) 
		{
			if (GUI.Button(exit, "Exit")) 
			{
				Application.Quit();
			}
		}
		
		if (fail) 
		{
			if (GUI.Button(restart, "Restart")) 
			{
				GameManager.RestartQuiz();
				Application.LoadLevel(1);
			}
		}
		
	}
}

public struct Actions
{
	public string Positive;
	public string Negative;
	public int Score;
	
	private string blank; 
	
	public Actions(int score, string scoreText)
	: this()
	{
		blank = " ";
		
		if (score >= 1) 
		{
			Positive = scoreText;
			Negative = blank;
		}
		
		else if (score <= 0) 
		{
			Positive = blank;
			Negative = scoreText;
		}
		
		Score = score; 
//		Positive = Positive;
//		Negative = Negative;
		
	}
}
