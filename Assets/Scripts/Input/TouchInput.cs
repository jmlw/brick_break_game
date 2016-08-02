using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInput : MonoBehaviour
{

	public LayerMask touchInputMask;

	// private List<GameObject> touchList = new List<GameObject> ();
	// private GameObject[] touchesOld;
	// private RaycastHit hit;
	private Collider2D touchAreaCollider;
	private GameObject touchArea;



	private int mouseFrame = 0;
	private Vector3 previousMousePosition;

	private Dictionary<int, GameObject> touches = new Dictionary<int, GameObject> ();	
	private Vector3 currentTouchPosition;
	private Vector3? previousTouchPosition;
	private Vector3 touchDelta;
	
	// public delegate void OnTouchDown(Vector3 position);
	// public delegate void OnTouchMove(Vector3 position, Vector3 delta);
	// public delegate void OnTouchUp(Vector3 position, Vector3 delta);

	// Use this for initialization
	void Start ()
	{
		touchArea = GameObject.FindGameObjectWithTag (k.Tags.TOUCH_AREA);
		Logger.Debug ("Touch area: " + touchArea.ToString ());
		touchAreaCollider = touchArea.GetComponent<BoxCollider2D> ();
		Logger.Debug ("Collider: " + touchAreaCollider.ToString ());
	}


	void Update ()
	{

		#if UNITY_EDITOR
		handleMouseInputAsTouch ();
		#endif

		handleTouchInput ();

	}

	void handleTouchInput ()
	{
		if (Input.touchCount > 0) {
			Logger.Debug ("Found touches, will process each touch");

			//TODO: for performance, change this to for iterating over touches array, getting each touch manually
			foreach (Touch touch in Input.touches) {
				Vector3 touchWorldPointPosition = Camera.main.ScreenToWorldPoint (touch.position);
				Logger.Debug ("Touch world position: " + touchWorldPointPosition);
				int touchId = touch.fingerId;
				Logger.Debug ("Touch ID: " + touchId);

				switch (touch.phase) {
				// ### Drag ###
				case TouchPhase.Began:
					Logger.Debug ("Touch phase began");
					if (touches.ContainsKey (touchId) == false) {
						// drag started!
						touchDown (touch.position);
					}
					break;

				case  TouchPhase.Moved:
					Logger.Debug ("Touch phase moved");
					if (touches.ContainsKey (touchId)) {
						// drag moved!
						touchMove (touch.position);
					}
					break;

				case  TouchPhase.Ended:
					Logger.Debug ("Touch phase ended");
					if (touches.ContainsKey (touchId)) {
						touches.Remove (touchId);

						// drag has ended!
						touchUp (touch.position);
					}
					break;

				default:
					Logger.Debug ("Touch phase not handled.");
					break;
				}
			}
		}
	}

	void handleMouseInputAsTouch ()
	{
		int touchId = 0;
		
		if (Input.GetMouseButtonDown(0)) {
			Logger.Debug("Current mouse frame: " + mouseFrame);
			Logger.Debug ("Found mouse touch");

			Vector3 touchWorldPointPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Logger.Debug ("Touch world position: " + touchWorldPointPosition);
			
			Logger.Debug ("Touch ID: " + touchId);

			if (mouseFrame == 0) {
				Logger.Debug ("Touch phase began");
				touchDown (touchWorldPointPosition);
			}

			mouseFrame++;
		}
		
		if (Input.GetMouseButton(0)) {
			Logger.Debug("Current mouse frame: " + mouseFrame);
			Logger.Debug ("Found mouse hold");

			Vector3 touchWorldPointPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Logger.Debug ("Touch world position: " + touchWorldPointPosition);
			
			Logger.Debug ("Touch ID: " + touchId);
			
			if (mouseFrame > 0) {
				Logger.Debug ("Mouse Phase down");
				if( !V3Equal(previousMousePosition, touchWorldPointPosition) ) {
					Logger.Debug("Mouse Phase moved");
					touchMove (touchWorldPointPosition);
				} else {
					Logger.Debug("Mouse Stay");
				}
			}
			
			mouseFrame++;
		}

		if (Input.GetMouseButtonUp(0)) {
			Logger.Debug("Current mouse frame: " + mouseFrame);
			Vector3 touchWorldPointPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Logger.Debug ("Touch world position: " + touchWorldPointPosition);
			Logger.Debug ("Touch ID: " + touchId);
			Logger.Debug ("Touch phase ended");
			
			touchUp (touchWorldPointPosition);
			
			mouseFrame = 0;
			Logger.Debug("Resetting mouse frame: " + mouseFrame);
		}
	}
	
	private bool V3Equal(Vector3 a, Vector3 b){
		return Vector3.SqrMagnitude(a - b) < 0.0001;
 	}


	void touchDown (Vector3 position)
	{
		Logger.Debug ("Touch start registered");
		
		previousTouchPosition = null;
		currentTouchPosition = position;
		
		// OnTouchUp(currentTouchPosition);
	}

	void touchMove (Vector3 position)
	{
		Logger.Debug ("Touch move registered");
		
		previousTouchPosition = currentTouchPosition;
		currentTouchPosition = position;
		
		// OnTouchUp(currentTouchPosition, previousTouchPosition - currentTouchPosition);
	}

	void touchUp (Vector3 position)
	{
		Logger.Debug ("Touch end registered");
		
		previousTouchPosition = currentTouchPosition;
		currentTouchPosition = position;
		
		// OnTouchUp(currentTouchPosition, previousTouchPosition - currentTouchPosition);
	}

}



