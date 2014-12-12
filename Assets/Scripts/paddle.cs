using UnityEngine;
using System.Collections;

public class paddle : MonoBehaviour {

	private Transform paddleTransform;
	private Vector2 paddlePosition;

	// Set this in the inspector to edit gameplay on the fly (y position and starting x)
	public Vector2 startPosition;

	public float paddleVelosity;
	public float maximumVelosity;

	public GameObject leftBorder;
	public GameObject rightBorder;

    // left and right bounds represent farthest center of paddle can go
	private float leftBoundPosition;
	private float rightBoundPosition;
	private float paddleWidth;

	// Use this for initialization
	void Start () {
		paddleTransform = this.transform;

	    paddleTransform.position = startPosition;
		paddlePosition = startPosition;

		paddleWidth = paddleTransform.collider2D.bounds.size.x;

		if (leftBorder != null && rightBorder != null) {
			leftBoundPosition = leftBorder.transform.position.x + leftBorder.transform.localScale.x/2 + paddleWidth/2;
			rightBoundPosition = rightBorder.transform.position.x - rightBorder.transform.localScale.x/2 - paddleWidth/2;
			Debug.Log ("Left bound position: " +leftBoundPosition + " Right bound positon: " + rightBoundPosition);
		} else {
			Debug.Log("Missing Border");
		}
	}
	
	// Update is called once per frame
	void Update () {
		// horizontal movement
        paddlePosition = paddleTransform.position;

        paddlePosition.x += normalizeAxis(Input.GetAxis("Horizontal")) * paddleVelosity;

        paddleTransform.position = Vector2.Lerp(paddleTransform.position, paddlePosition, Time.deltaTime);

        if (paddleTransform.position.x <= leftBoundPosition) {
            paddleTransform.position = new Vector2(leftBoundPosition, paddleTransform.position.y);
        } else if (paddleTransform.position.x >= rightBoundPosition) {
            paddleTransform.position = new Vector2(rightBoundPosition, paddleTransform.position.y);
        }


	}

    int normalizeAxis(float input) {
        if (input > 0)
        {
            return 1;
        } else if (input < 0)
        {
            return -1;
        } else
        {
            return 0;
        }
    }
}
