using UnityEngine;
using System.Collections;

public class ball_controller : MonoBehaviour {

	Rigidbody2D rBody;

	// Use this for initialization
	void Start () {
		rBody = this.rigidbody2D;

		rBody.velocity = new Vector2 (12, 12);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
