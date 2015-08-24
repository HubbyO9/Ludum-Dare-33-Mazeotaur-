using UnityEngine;
using System.Collections;

public class SimpleControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			this.transform.Translate(new Vector3(0, 0, Time.deltaTime * 50));
		}
		if (Input.GetKey (KeyCode.S)) {
			this.transform.Translate(new Vector3(0, 0, Time.deltaTime * -50));
		}

	
		Plane playerPlane = new Plane (Vector3.up, transform.position);

		Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);

		float hitDist = 0.0f;

		if (playerPlane.Raycast (r, out hitDist)) {

			Vector3 targetPoint	 = r.GetPoint(hitDist);
			Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 4 * Time.deltaTime);

		}

	
	}
}
