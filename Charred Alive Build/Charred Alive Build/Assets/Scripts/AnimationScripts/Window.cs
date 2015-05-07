using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Window : MonoBehaviour {
	
	bool flagWindow = false;
	bool windowOpen = false;
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("e") && flagWindow)
		{
			if (windowOpen) 
			{
				transform.root.gameObject.animation.Play("WindowClose");
				windowOpen = false;
			}
			else
			{
				transform.root.gameObject.animation.Play("WindowOpen");
				windowOpen = true;
			}
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "Player")
		{
			flagWindow = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "Player") 
		{
			flagWindow = false;	
		}
	}
}
