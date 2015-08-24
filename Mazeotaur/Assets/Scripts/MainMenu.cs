using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GUISkin skin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.skin = skin;
		if (GUI.Button (new Rect(65, 210, 180, 43), ".")) {
			//START
			Application.LoadLevel(1);
		}

		if (GUI.Button (new Rect(65, 270, 150, 43), "")) {
			//EXIT
			Application.Quit();
		}
	}
}
