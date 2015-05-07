using UnityEngine;
using System.Collections;

public class InteractiveObject : MonoBehaviour {

	public string Label;
	
	// Use this for initialization
	void Awake(){
		
	}
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public virtual void Activate()
	{
		print(Label);
//		if (Input.GetKeyDown("e"))
//		{
//			if (Label == "Floor 2") 
//				floorTwo = true;
//		}
	}
	
	string getLabel(){
		return Label;
	}
}
