using UnityEngine;
using System.Collections;

public class DoorTriggerBack : MonoBehaviour {

	bool doorOpen = false;
	bool parentToObject;
	public bool ParentToObject { get{ return parentToObject; } }
	
	bool flagDoor = false;
	
	GameObject player;
	// Use this for initialization
	void Start () 
	{
		parentToObject = false;
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("e") && flagDoor)
		{
			if (!transform.root.animation.isPlaying) 
			{
				if (doorOpen) 
				{
					parentToObject = false;
					transform.root.gameObject.animation.Play("DoorOpen");
					doorOpen = false;
				}
				else
				{
					parentToObject = true;
					transform.root.gameObject.animation.Play("DoorClose");
					doorOpen = true;
				}
			}
			
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player") 
		{
			flagDoor = true;
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.name == "Player") 
		{
			if(parentToObject)
			{
				player.transform.parent = gameObject.transform.root;
			}
			else if (!parentToObject) 
			{
				player.transform.parent = null;
			}
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "Player") 
		{
			flagDoor = false;
			parentToObject = false;
			player.transform.parent = null;
		}
	}
}
