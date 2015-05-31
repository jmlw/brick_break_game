using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    private GameplayData gameData;

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

    private GameObject _attachedBall;
    private Ball _attachedBallController;
    private Transform _attachedBallTransform;

    void Awake() {
        gameData = GameplayData.Instance;

        gameData.registerPaddle(this);
    }

	// Use this for initialization
	void Start () {
        setStartingDefaults();
	}


	
	// Update is called once per frame
	void Update () {
		// horizontal movement
        paddlePosition = paddleTransform.position;

        paddlePosition.x += normalizeAxis(Input.GetAxis("Horizontal")) * paddleVelosity;

        paddleTransform.position = Vector2.Lerp(paddleTransform.position, paddlePosition, Time.deltaTime);

//        if (paddleTransform.position.x <= leftBoundPosition) {
//            paddleTransform.position = new Vector2(leftBoundPosition, paddleTransform.position.y);
//        } else if (paddleTransform.position.x >= rightBoundPosition) {
//            paddleTransform.position = new Vector2(rightBoundPosition, paddleTransform.position.y);
//        }
//
//        if (_attachedBall != null)
//        {
//            _attachedBallTransform.position = new Vector2(paddleTransform.position.x, _attachedBallTransform.position.y);
//
//            if (Input.GetKeyDown("Space")){
//                detachBall();
//            }
//        }
	}

    void OnCollisionExit2D(Collision2D collision) {
        Debug.Log("Collision Exit2d: " + collision);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collision Enter2d: " + collision);
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

    void setStartingDefaults() {
        paddleTransform = this.transform;
        
//        paddleTransform.position = startPosition;
//        paddlePosition = startPosition;
        
        paddleWidth = paddleTransform.GetComponent<Collider2D>().bounds.size.x;
        
        setBorderValues();
    }
    
    void setBorderValues(){
        if (leftBorder != null && rightBorder != null) {
            leftBoundPosition = leftBorder.transform.position.x + leftBorder.transform.localScale.x/2 + paddleWidth/2;
            rightBoundPosition = rightBorder.transform.position.x - rightBorder.transform.localScale.x/2 - paddleWidth/2;
            Debug.Log ("Left bound position: " +leftBoundPosition + " Right bound positon: " + rightBoundPosition);
        } else {
            Debug.Log("Missing Border");
        }
    }

    public void setAttachedBall(Ball attachedBall) 
    {
        _attachedBallController = attachedBall;
        _attachedBall = attachedBall.gameObject;
//        _attachedBallController = ;
//        _attachedBallController.isAttached = true;
        _attachedBallTransform = _attachedBall.transform;
    }

    void detachBall() {
        _attachedBall = null;
//        _attachedBallController.launch();
    }
}
