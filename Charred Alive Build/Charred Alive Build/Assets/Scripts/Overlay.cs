using UnityEngine;
using System.Collections;

public class Overlay : MonoBehaviour {
	
	GUITexture bottomOverlay;
	GUITexture topOverlay;
	
	bool inFire;
	public bool InFire { set { inFire = value;} }
	
	bool inSmoke;
	public bool InSmoke { set { inSmoke = value; } }
	
	//Controls feedback text
	static bool feedback = false;
	public static bool Feedback { get { return feedback;} set { feedback = value; } }
	bool flash = false;
	// Use this for initialization
	void Start () {
//		enterFire = GameObject.Find ("EnterFire").GetComponent<testMinusScore>();
//		enterSmoke = GameObject.Find("EnterSmoke").GetComponent<StandInSmoke>();
		bottomOverlay = GameObject.Find("Overlay/bottomOverlay").GetComponent<GUITexture>();
		topOverlay = GameObject.Find("Overlay/topOverlay").GetComponent<GUITexture>();
		
		transparentColor (bottomOverlay);
		transparentColor(topOverlay);
	}

	void transparentColor (GUITexture overlay)
	{
		Color color = overlay.color;
		color.a = 0f;
		overlay.color = color;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (inFire) 
		{
			flashing (bottomOverlay);
			
			if (flash)
				transparencyUp (bottomOverlay);
			
			if (!flash)
				transparencyDown (bottomOverlay);
		}
		else if(!inFire && bottomOverlay.color.a > 0f)
		{
			transparencyDown(bottomOverlay);
		}
		
		if (inSmoke)
		{
			flashing(topOverlay);
			
			if(flash)
				transparencyUp(topOverlay);
			
			if(!flash)
				transparencyDown(topOverlay);
		}
		else if (!inSmoke && topOverlay.color.a > 0f)
		{
			transparencyDown(topOverlay);
		}
	}
	
	void flashing (GUITexture overlay)
	{
		if (overlay.color.a <= 0f) 
		{
			flash = true;
		}
		
		if (overlay.color.a >= .25f) 
		{
			flash = false;	
		}
	}

	void transparencyDown (GUITexture overlay)
	{
		Color color = overlay.color;
		color.a -= (.7f * Time.deltaTime);
		overlay.color = color;
	}
	
	
	void transparencyUp (GUITexture overlay)
	{
		Color color = overlay.color;
		color.a += (.7f * Time.deltaTime);
		overlay.color = color;
	}
}
