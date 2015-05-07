using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	private static bool fireAlarm = false;
	public static bool FireAlarm { get {return fireAlarm; } set {fireAlarm = value; }}
	
	private static bool quizTwo = false;
	public static bool QuizTwo { get{ return quizTwo; } set {quizTwo = value; } }
	
	private static bool restart = false;
	public static bool Restart { get { return restart; } }
	
	private static int quizScore = 0;
	public static int QuizScore { get {return quizScore; } set { quizScore = value; } }
	
	public static void RestartQuiz()
	{
		restart = true;
	}
	
	public static void ResetGame()
	{
		restart = false;
		quizTwo = false;
		quizScore = 0;
		
		ScoreManager.ResetActions();
	}
	
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
