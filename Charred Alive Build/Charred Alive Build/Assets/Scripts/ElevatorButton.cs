using UnityEngine;
using System.Collections;

public class ElevatorButton : InteractiveObject
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void Activate()
	{
		print ("Elevator buton has been pressed.");
	}
}
