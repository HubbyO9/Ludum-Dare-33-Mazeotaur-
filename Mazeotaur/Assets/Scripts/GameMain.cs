using UnityEngine;
using System.Collections;

public class GameMain : MonoBehaviour {

	GameObject[] victims;
	public GameObject player;
	public Texture healthBar;
	public Texture overlayBar;
	float gameTime = 0f;

	// Use this for initialization
	void Start () {
		victims = GameObject.FindGameObjectsWithTag ("Victim");
	}
	
	// Update is called once per frame
	void Update () {
		gameTime += Time.deltaTime;
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit)){
				for(int i = 0; i < victims.Length; i++){
					GameObject g = victims[i];
					if(hit.transform.name.Equals(g.transform.name)){
						Vector3 play = player.transform.position;
						Vector3 victim = g.transform.position;
						play.y = victim.y;
						if(Vector3.Distance(victim, play) < 20f){
							VictimAI ai = g.GetComponent<VictimAI>() as VictimAI;
							ai.health -= 10;
							if(ai.health <= 0){
								g.SetActive(false);

								int active = 0;
								for(int j = 0; j < victims.Length; j++){
									if(victims[j].activeSelf){
										active++;
									}
								}
								if(active == 0){
									if(Application.loadedLevel == 2){
										Application.LoadLevel(0);
									}else{
										Application.LoadLevel(2);
									}
								}
							}
						}
					}
				}
			}
		}
	}

	void OnGUI(){
		for (int i = 0; i < victims.Length; i++) {
			GameObject g = victims [i];
			if (g.activeSelf) {
				VictimAI ai = g.GetComponent<VictimAI> () as VictimAI;

				Vector3 pos = Camera.main.WorldToScreenPoint (g.transform.position);
				GUI.DrawTexture (new Rect (pos.x - (healthBar.width / 2), (Screen.height - pos.y) - (healthBar.height / 2), (int)(healthBar.width * 0.6f * (ai.health / ai.maxHealth)), (int)(healthBar.height * 0.6)), healthBar, ScaleMode.ScaleAndCrop, true, 0f);
				GUI.DrawTexture (new Rect (pos.x - (healthBar.width / 2), (Screen.height - pos.y) - (healthBar.height / 2), (int)(healthBar.width * 0.6f), (int)(healthBar.height * 0.6)), overlayBar, ScaleMode.ScaleAndCrop, true, 0f);
			}
		}
		int minutes = (int)(gameTime / 60);
		int seconds = (int)gameTime;
		int milliseconds = (int)((gameTime - seconds) * 10);
		GUI.Label (new Rect(10, 10, 100, 30), "Time: " + minutes + ":" + seconds + ":" + milliseconds);
	}
}
