using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {
	
	private Rect play = new Rect(450, 225, 100, 50);
	void OnGUI()
	{
		if (GUI.Button(play, "Play")) 
			Application.LoadLevel(1);
	}
}
