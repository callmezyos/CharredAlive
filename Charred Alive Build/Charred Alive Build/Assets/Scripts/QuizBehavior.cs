using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuizBehavior : MonoBehaviour {
	
	int quizMin = 1;
	int quizMax = 21;
	int randomHolder;
	
	bool checkDuplicate;
	int backUpCount = 0;
	
	int maxQuestions = 10;
	int questionCap = 21;
	
	string questionValue;
	
	string correctAnswers;
	string[] wrongAnswers;
	
	int questionListing = 0;
	int answerListing = 0;
	Dictionary<int, string> questions = new Dictionary<int, string>();
	Dictionary<int, Answers> Answers = new Dictionary<int, Answers>();
	public Answers QuestionAnswers;
	
	string currentQuestion;
	Answers currentAnswers;
	
	List<int> generateNumList = new List<int>();
	
	GUIText questionText;
	
	GUIText answerTracker;
	int totalQuestions = 10;
	int rightAnswer = 0;
	int answeredQuestions = 0;
	
	int score = 0;
	int prevScore = 0;
	string textOutput;
	
	private string buttonText = "Submit";
	
	bool beginSim = false;
	Rect buttonRect = new Rect(400, 300, 100, 50);
	int leftAlignment = 200;
	int width = 30;
	
	private int toggleXPosition = 1;
	private bool correctToggle = false;
	private int correctTogglePos = 100;
	private bool wrongToggle1 = false;
	private int wrongToggle1Pos = 150;
	private bool wrongToggle2 = false;
	private int wrongToggle2Pos = 200;
	private bool wrongToggle3 = false;
	private int wrongToggle3Pos = 250;
	
	// Use this for initialization
	void Start () 
	{
		questionText = GameObject.Find("Question").GetComponent<GUIText>();
		answerTracker = GameObject.Find("answerTracker").GetComponent<GUIText>();
		
		if (GameManager.Restart) 
		{
			GameManager.ResetGame();
			Debug.Log("ScoreManager has reset");
		}
		else
			prevScore = GameManager.QuizScore;
		
		int backUpCap = 0;
		for (int i = 0; i < maxQuestions; i++) 
		{
			randomHolder = Random.Range(quizMin, quizMax);
			checkDuplicate = true;
			backUpCount += 1;
			while (!generateNumList.Contains(randomHolder))
			{
				generateNumList.Add(randomHolder);
				checkDuplicate = false;
				backUpCount = 0;
				backUpCap = i;
			}
			if (checkDuplicate && backUpCount == 1 && i > backUpCap) 
			{
				i--;
			}
			else if(backUpCount >= 2 && i > backUpCap) 
			{
				i--;
			}
			else if(backUpCount < 0 && i > backUpCap)
			{
				i--;
			}
		}
		quizQuestions();
		
		questions.TryGetValue(generateNumList[questionListing++], out currentQuestion);
		Answers.TryGetValue(generateNumList[answerListing++], out currentAnswers);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	private void quizQuestions()
	{
		
		for (int i = 1; i <= questionCap; i++) 
		{
			switch (i) 
			{
				case 1:
					questionValue = "If on fire you should?";
					correctAnswers = "Stop, drop, and roll.";
					wrongAnswers = new string[3] {"Scream for help.", "Try to pat the fire out.","Run around."};
					break;
				case 2:
					questionValue = "Which is a safe means of exiting a building on fire?";
					correctAnswers = "Stairs";
					wrongAnswers = new string[3] {"Elevator", "Second floor window","Service elevator"};
					break;
				case 3:
					questionValue = "Where should you meet up?";
					correctAnswers = "Outside the building at a safe place.";
					wrongAnswers = new string[3] {"By the exit.", "On the street.","In front of the building."};
					break;
				case 4:
					questionValue = "When you notice a fire which should you do?";
					correctAnswers = "Activate a nearby fire alarm.";
					wrongAnswers = new string[3] {"Tell no one.", "Run and hide.","Attempt to put the fire out yourself."};
					break;
				case 5:
					questionValue = "When is it safe to reenter the building?";
					correctAnswers = "When the fire department tells you so.";
					wrongAnswers = new string[3] {"When the fire looks out.", "When your friend says, \"it is safe.\"","When you feel like it."};
					break;
				case 6:
					questionValue = "If you're with a disabled person what should you do?";
					correctAnswers = "Find someone who can help them out.";
					wrongAnswers = new string[3] {"Leave them.", "Stay with them and wait for help.","Attempt to help them yourself"};
					break;
				case 7:
					questionValue = "Before opening doors what should you do?";
					correctAnswers = "Check the door for heat.";
					wrongAnswers = new string[3] {"Just open the door.", "Call for help.","Pour water on yourself."};
					break;
				case 8:
					questionValue = "If caught in smoke what should you do?";
					correctAnswers = "Stay low.";
					wrongAnswers = new string[3] {"Run out of it as fast as possible", "Head back the way you came.","Hold your breath."};
					break;
				case 9:
					questionValue = "If all exits are blocked what should you do?";
					correctAnswers = "Find a safe spot and wait for the fire department.";
					wrongAnswers = new string[3] {"Panic.", "Attempt to get through the fire.","Hide somewhere."};
					break;
				case 10:
					questionValue = "When the fire alarm sounds what do you want to do?";
					correctAnswers = "Leave immediately.";
					wrongAnswers = new string[3] {"Wait, maybe it's a drill.", "Ignore it.","Hide."};
					break;
				case 11:
					questionValue = "Fire signs point to?";
					correctAnswers = "The nearest exit.";
					wrongAnswers = new string[3] {"The fire.", "Where the best hiding spots are.","The wrong way."};
					break;
				case 12:
					questionValue = "In the event of a fire how should you behave?";
					correctAnswers = "Calmly";
					wrongAnswers = new string[3] {"Panicky", "Wildly","Rowdy"};
					break;
				case 13:
					questionValue = "To prevent fires you should?";
					correctAnswers = "Never play with fire.";
					wrongAnswers = new string[3] {"Play with matches.", "Keep a bucket of water nearby","Play with electrical sockets."};
					break;
				case 14:
					questionValue = "Before exiting a room you should?";
					correctAnswers = "Look for fire and smoke.";
					wrongAnswers = new string[3] {"Just go as quickly as possible.", "Chat with friends.","Hide."};
					break;
				case 15:
					questionValue = "If you get burned, what should you use to cool it?";
					correctAnswers = "Cool water.";
					wrongAnswers = new string[3] {"Ice", "Butter","A band aid"};
					break;
				case 16:
					questionValue = "Matches and lighters are _____";
					correctAnswers = "Tools for adults";
					wrongAnswers = new string[3] {"Toys for kids.", "Real cool.","Fun to play with."};
					break;
				case 17:
					questionValue = "If you find matches and lighters you should?";
					correctAnswers = "Find a grownup";
					wrongAnswers = new string[3] {"Throw them away", "Play with them.","Tell noone."};
					break;
				case 18:
					questionValue = "Fire fighters are?";
					correctAnswers = "Your friends.";
					wrongAnswers = new string[3] {"Scary, you should hide.", "Looking to harm you.","Someone to tease."};
					break;
				case 19:
					questionValue = "Once your safe which number should you call?";
					correctAnswers = "911";
					wrongAnswers = new string[3] {"Your best friend.", "Your parents.","Make no calls."};
					break;
				case 20:
					questionValue = "A smoke alarm can warn you of?";
					correctAnswers = "A fire.";
					wrongAnswers = new string[3] {"Flood.", "Bad cooking.","Your teacher's farts."};
					break;
				default:
					questionValue = "Switch statement has malfunctioned.";
					break;
			}
			questions.Add(i, questionValue);
			Answers.Add(i, new Answers(correctAnswers, wrongAnswers));
		}
	}
	void OnGUI()
	{
		
		questionText.text = currentQuestion;
		
		if (answeredQuestions >= 10) 
		{
			if (rightAnswer < 5) 
			{
				score = 0;
				textOutput = "You need to study the basics of fire safety some more.";
			}
			switch (rightAnswer) 
			{
				case 5:
					score = 5;
					textOutput = "You're closer to understanding the basics of fire safety.";
					break;
				case 6:
					score = 10;
					textOutput = "You're getting on the right path to fire safety.";
					break;
				case 7:
					score = 20;
					textOutput = "You're getting better at fire safety.";
					break;
				case 8:
					score = 30;
					textOutput = "You and fire safety are now friends.";
					break;
				case 9:
					score = 40;
					textOutput = "You have a strong grasp of fire safety.";
					break;
				case 10:
					score = 50;
					textOutput = "You're a fire safety expert now.";
					break;
				default:
				break;
			}
		}
		else
		{
			if (correctToggle = GUI.Toggle(new Rect( leftAlignment, correctTogglePos , 300, width), correctToggle, currentAnswers.CorrectAnswer)) 
			{
				wrongToggle1 = GUI.Toggle(new Rect( leftAlignment, wrongToggle1Pos, 300, width), false, currentAnswers.WrongAnswers[0]);
				wrongToggle2 = GUI.Toggle(new Rect( leftAlignment, wrongToggle2Pos, 300, width), false, currentAnswers.WrongAnswers[1]);
				wrongToggle3 = GUI.Toggle(new Rect( leftAlignment, wrongToggle3Pos, 300, width), false, currentAnswers.WrongAnswers[2]);
			}
			if (wrongToggle1 = GUI.Toggle(new Rect( leftAlignment, wrongToggle1Pos, 300, width), wrongToggle1, currentAnswers.WrongAnswers[0])) 
			{
				correctToggle = GUI.Toggle(new Rect( leftAlignment, correctTogglePos, 300, width), false, currentAnswers.CorrectAnswer);
				wrongToggle2 = GUI.Toggle(new Rect( leftAlignment, wrongToggle2Pos, 300, width), false, currentAnswers.WrongAnswers[1]);
				wrongToggle3 = GUI.Toggle(new Rect( leftAlignment, wrongToggle3Pos, 300, width), false, currentAnswers.WrongAnswers[2]);
			}
			if (wrongToggle2 = GUI.Toggle(new Rect( leftAlignment, wrongToggle2Pos, 300, width), wrongToggle2, currentAnswers.WrongAnswers[1])) 
			{
				correctToggle = GUI.Toggle(new Rect( leftAlignment, correctTogglePos, 300, width), false, currentAnswers.CorrectAnswer);
				wrongToggle1 = GUI.Toggle(new Rect( leftAlignment, wrongToggle1Pos, 300, width), false, currentAnswers.WrongAnswers[0]);
				wrongToggle3 = GUI.Toggle(new Rect( leftAlignment, wrongToggle3Pos, 300, width), false, currentAnswers.WrongAnswers[2]);
			}
			if (wrongToggle3 = GUI.Toggle(new Rect( leftAlignment, wrongToggle3Pos, 300, width), wrongToggle3, currentAnswers.WrongAnswers[2])) 
			{
				correctToggle = GUI.Toggle(new Rect( leftAlignment, correctTogglePos, 300, width), false, currentAnswers.CorrectAnswer);
				wrongToggle1 = GUI.Toggle(new Rect( leftAlignment, wrongToggle1Pos, 300, width), false, currentAnswers.WrongAnswers[0]);
				wrongToggle2 = GUI.Toggle(new Rect( leftAlignment, wrongToggle2Pos, 300, width), false, currentAnswers.WrongAnswers[1]);
			}
		}
		answerTracker.text = rightAnswer + " / " + totalQuestions;
		
		if(GUI.Button(buttonRect, buttonText) && (correctToggle || wrongToggle1 || wrongToggle2 || wrongToggle3) )
		{
			if (beginSim)
			{
				ScoreManager.AddQuizToScore(score, prevScore, textOutput);
				
				if (GameManager.QuizTwo)
					Application.LoadLevel(3);
				else
				{	
					prevScore = score;
					GameManager.QuizScore = prevScore;
					Application.LoadLevel(2);
				}
			}
				
			
			if (questionListing < 10) 
			{
				toggleXPosition = Random.Range(1, 4);
				switch (toggleXPosition) 
				{
					case 1:
						correctTogglePos = 100;
						wrongToggle1Pos = 150;
						wrongToggle2Pos = 200;
						wrongToggle3Pos = 250;
						break;
					case 2:
						correctTogglePos = 150;
						wrongToggle1Pos = 200;
						wrongToggle2Pos = 250;
						wrongToggle3Pos = 100;
						break;
					case 3:
						correctTogglePos = 200;
						wrongToggle1Pos = 250;
						wrongToggle2Pos = 100;
						wrongToggle3Pos = 150;
						break;
					case 4:
						correctTogglePos = 250;
						wrongToggle1Pos = 100;
						wrongToggle2Pos = 150;
						wrongToggle3Pos = 200;
						break;
					default:
					break;
				}
				if (questionListing < 10) 
				{
					questions.TryGetValue(generateNumList[questionListing++], out currentQuestion);
					Answers.TryGetValue(generateNumList[answerListing++], out currentAnswers);
				}
			}
			
			if (correctToggle && rightAnswer < totalQuestions)//Might need to fix so correct answers cannot continually advance, but when switch to sim after 10th question it might be moot.
			{
				rightAnswer++;
			}
			answeredQuestions++;
			if (answeredQuestions == 10)
			{
				beginSim = true;
				if (GameManager.QuizTwo)
					buttonText = "See After Action Report";
				else
					buttonText = "Begin Simulation";
				
				currentQuestion = "Try your luck in the simulator.";
				buttonRect = new Rect(375, 150, 150, 50);
				correctToggle = GUI.Toggle(new Rect( 0, 0, 0, 0), true, currentAnswers.CorrectAnswer);
				wrongToggle1 = GUI.Toggle(new Rect( 0, 0, 0, 0), true, currentAnswers.WrongAnswers[0]);
				wrongToggle2 = GUI.Toggle(new Rect( 0, 0, 0, 0), true, currentAnswers.WrongAnswers[1]);
				wrongToggle3 = GUI.Toggle(new Rect( 0, 0, 0, 0), true, currentAnswers.WrongAnswers[2]);
			}
			else
			{
				correctToggle = GUI.Toggle(new Rect( correctTogglePos, 400, 300, 50), false, currentAnswers.CorrectAnswer);
				wrongToggle1 = GUI.Toggle(new Rect( wrongToggle1Pos, 400, 300, 50), false, currentAnswers.WrongAnswers[0]);
				wrongToggle2 = GUI.Toggle(new Rect( wrongToggle2Pos, 400, 300, 50), false, currentAnswers.WrongAnswers[1]);
				wrongToggle3 = GUI.Toggle(new Rect( wrongToggle3Pos, 400, 300, 50), false, currentAnswers.WrongAnswers[2]);
				
			}
		}
	}
}

public struct Answers
{
	public string CorrectAnswer;
	public string[] WrongAnswers;
	
	private int maxWrongSize;
	public Answers(string correctAnswer, string[] wrongAnswers)
	{
		CorrectAnswer = correctAnswer;
		WrongAnswers = new string[3];
		maxWrongSize = 3;
		for (int i = 0; i < maxWrongSize; i++) 
		{
			WrongAnswers[i] = wrongAnswers[i];
		}
	}
}
