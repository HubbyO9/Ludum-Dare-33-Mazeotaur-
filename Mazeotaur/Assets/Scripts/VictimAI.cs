using UnityEngine;
using System.Collections;

public class VictimAI : MonoBehaviour {

	public GameObject[] points;
	private int destPoints = 0;
	private NavMeshAgent agent;
	private float travelTime = 0;

	public float maxHealth = 100f;
	public float health = 100f;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.autoBraking = false;
		points = GameObject.FindGameObjectsWithTag ("Waypoint");
		GotoNextPoint ();
		maxHealth = 100f;
		health = 100f;
	}
	
	// Update is called once per frame
	void Update () {
		travelTime += Time.deltaTime;
	 	if (agent.remainingDistance < 0.5f)
			GotoNextPoint ();
		if (travelTime > 10f)
			GotoNextPoint ();

		}

	void GotoNextPoint(){
		travelTime = 0f;
		if (points.Length == 0) {
			Debug.Log("NO POINTS FOUND!");
			return;
		}

		agent.destination = points[Random.Range (0, points.Length)].transform.position;

		destPoints = (destPoints + 1) % points.Length;
	}
}
