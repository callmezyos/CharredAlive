using UnityEngine;
using System.Collections;

enum FLOOR {NONE, ONE, TWO };
enum LIFT {NONE, UP, DOWN};
enum animationChooser { floorOne, floorTwo };
public class InteractWithObject : MonoBehaviour {
	
	
	GUIText ContextualMessageGUIText;
	GameObject playerCamera;
	public float RaycastLength = 2;
	GameObject ContextualMessage;
	animationChooser switchAnimation; 
	
	GameObject leftDoor;
	GameObject rightDoor;
	GameObject elevator;
	
	GameObject spotLight1;
	GameObject spotLight2;
	GameObject spotLightBut1;
	GameObject spotLightBut2;
	
	public float Speed = 3.0f;
	Vector3 origin;
	Vector3 direction;
	
	FLOOR floor = FLOOR.ONE;
	LIFT lift = LIFT.NONE;
	float stop;
	
	bool activateButton = false;
	bool scoreAction = false;
	// Use this for initialization
	void Start () 
	{
		playerCamera = GameObject.Find("Player/Main Camera");
		
		spotLight1 = GameObject.Find("Spotlight1");
		spotLight2 = GameObject.Find("Spotlight2");
		spotLightBut1 = GameObject.Find("Elevator/Panel/SpotlightBut1");
		spotLightBut2 = GameObject.Find("Elevator/Panel/SpotlightBut2");
		
		ContextualMessage = GameObject.Find("Contextual Message");
		ContextualMessageGUIText = ContextualMessage.GetComponent<GUIText>();
		ContextualMessageGUIText.enabled = false;
		
		elevator = GameObject.Find("Elevator");
		
		floor = FLOOR.TWO;
		
		spotLight1.gameObject.light.enabled = false;
		spotLight2.gameObject.light.enabled = false;
		spotLightBut1.gameObject.light.enabled = false;
		spotLightBut2.gameObject.light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		RaycastHit raycastHit;
		origin = playerCamera.transform.position;
		direction = playerCamera.transform.forward; //See if this works at homeplayerCamera.transform.rotation;
		
		if (activateButton && !scoreAction) 
		{
			ScoreManager.SubtractFromScore(10, "You shouldn't use an elevator during a fire.");
			Overlay.Feedback = false;
			scoreAction = true;
		}
		
		if ((floor != FLOOR.TWO || elevator.transform.position.y != 6.027832f)
			&& (floor != FLOOR.ONE || elevator.transform.position.y != 1.0f)) 
		{
			lift = movement(floor, stop, lift);
		}
		
		if(Physics.Raycast(origin, direction, out raycastHit, RaycastLength))
		{
			//print ("Hit interactive object " + raycastHit.collider.name);
			if (raycastHit.collider.gameObject.tag == "InteractiveObject") 
			{
				ContextualMessageGUIText.enabled = true;
				InteractiveObject o = raycastHit.collider.gameObject.GetComponent<InteractiveObject>();
				if (o != null)
				{
					ContextualMessageGUIText.text = o.Label;
					
				}
				
				if (Input.GetKeyDown("e")) 
				{
					o.Activate();
					if (o.Label == "Floor 2" || o.Label == "Press E to activate Button") 
					{
						if (o.Label == "Floor 2") 
						{
							spotLightBut2.gameObject.light.enabled = true;
							
							if (!activateButton) 
							{
								FeedbackText.NegativeFeedback("An elevator is a bad means of exiting a building on fire.");
							}
							
							activateButton = true;
							
						}
						floor = FLOOR.TWO;
						lift = LIFT.UP;
						stop = 6.027832f;
					}
					if (o.Label == "Floor 1" || o.Label == "Call elevator" ) 
					{
						if (o.Label == "Floor 1") 
						{
							spotLightBut1.gameObject.light.enabled = true;
							
							if (!activateButton) 
							{
								FeedbackText.NegativeFeedback("An elevator is a bad means of exiting a building on fire.");
							}
							
							activateButton = true;
							
						}
						
						if (o.Label == "Call elevator") 
						{
							elevator.transform.position = new Vector3(elevator.transform.position.x, 1.0f, elevator.transform.position.z);	
						}
						floor = FLOOR.ONE;
						lift = LIFT.DOWN;
						stop = 1.0f;
					}
				}
				
				if (elevator.transform.position.y == stop && Input.GetKeyDown("e")) 
				{
					if (o.Label == "Press E to activate Button" ) 
					{
						leftDoor.animation.Play("leftDoor");	
						rightDoor.animation.Play("rightDoor");
					}
					if (o.Label == "Call elevator") 
					{
						leftDoor.animation.Play("leftDoor");	
						rightDoor.animation.Play("rightDoor");
					}
				}
			}	
		}
		else
			ContextualMessageGUIText.enabled = false;
			
		switch (floor) 
		{
			case FLOOR.ONE:
				spotLight2.gameObject.light.enabled = true;
				leftDoor = GameObject.Find ("ElevatorDoorsTwo/LeftDoor");
				rightDoor = GameObject.Find ("ElevatorDoorsTwo/RightDoor");
				break;
			case FLOOR.TWO:
				spotLight1.gameObject.light.enabled = true;
				leftDoor = GameObject.Find ("ElevatorDoors/LeftDoor");
				rightDoor = GameObject.Find ("ElevatorDoors/RightDoor");
				break;
			case FLOOR.NONE:
				spotLight1.gameObject.light.enabled = false;
				spotLight2.gameObject.light.enabled = false;
				spotLightBut1.gameObject.light.enabled = false;
				spotLightBut2.gameObject.light.enabled = false;
				break;
			default:
				break;
		}
		
		
		if (lift == LIFT.NONE && leftDoor.animation.isPlaying != true) 
		{
			spotLight1.gameObject.light.enabled = false;
			spotLight2.gameObject.light.enabled = false;
			spotLightBut1.gameObject.light.enabled = false;
			spotLightBut2.gameObject.light.enabled = false;
		}
	}
	
	LIFT movement(FLOOR floor, float stop, LIFT lift)
	{
		if (elevator.transform.position.y > stop && lift != LIFT.NONE) 
		{
			lift = LIFT.DOWN;
		}
		if (lift == LIFT.UP) 
		{
			elevator.transform.Translate(Vector3.up * Time.deltaTime * Speed);
			if (elevator.transform.position.y >= stop) 
			{
				leftDoor.animation.Play("leftDoor");	
				rightDoor.animation.Play("rightDoor");
				floor = FLOOR.NONE;
				lift = LIFT.NONE;
			}
		}
		else if(lift == LIFT.DOWN) 
		{
			elevator.transform.Translate(Vector3.down * Time.deltaTime * Speed);
			if (elevator.transform.position.y <= stop) 
			{
				leftDoor.animation.Play("leftDoor");	
				rightDoor.animation.Play("rightDoor");
				floor = FLOOR.NONE;
				lift = LIFT.NONE;
			}
		}
		return lift;
	}
}
