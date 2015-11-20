using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInput : MonoBehaviour {

    public LayerMask touchInputMask;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;
    private RaycastHit hit;
    private Collider2D touchAreaCollider;
    private GameObject touchArea;

	// Use this for initialization
	void Start () {
        touchArea = GameObject.FindGameObjectWithTag(k.Tags.TOUCH_AREA);
        Logger.Debug("Touch area: " + touchArea.ToString());
        touchAreaCollider = touchArea.GetComponent<BoxCollider2D>();
        Logger.Debug("Collider: " + touchAreaCollider.ToString());
	}


    void Update () {


        #if UNITY_EDITOR
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) {

            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();


            Vector3 position3 = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            Vector2 position2 = new Vector2(position3.x, position3.y);

            if (touchAreaCollider.OverlapPoint(position2)) {

                Logger.Debug("Physics hit TouchInput!");

                GameObject recipient = touchArea;

                Logger.Debug("Recipient: " + recipient);
                Logger.Debug("Position2: " + position2);

                touchList.Add(recipient);

                if (Input.GetMouseButtonDown(0)) {
                    recipient.SendMessage("OnTouchDown",position2,SendMessageOptions.DontRequireReceiver);
                }
                if (Input.GetMouseButtonUp(0)) {
                    recipient.SendMessage("OnTouchUp",position2,SendMessageOptions.DontRequireReceiver);
                }
                if (Input.GetMouseButton(0)) {
                    recipient.SendMessage("OnTouchStay",position2,SendMessageOptions.DontRequireReceiver);
                }

            }

            foreach (GameObject g in touchesOld) {
                if (!touchList.Contains(g)) {
                    g.SendMessage("OnTouchExit",position2,SendMessageOptions.DontRequireReceiver);
                }
            }
        }


        #endif


        if (Input.touchCount > 0) {

            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            Vector2 position2 = new Vector2(-100,-100);

            foreach (Touch touch in Input.touches) {

                Vector3 position3 = GetComponent<Camera>().ScreenToWorldPoint(touch.position);
                position2 = new Vector2(position3.x, position3.y);

                if (touchAreaCollider.OverlapPoint(position2)) {

                    GameObject recipient = touchArea;
                    touchList.Add(recipient);

                    if (touch.phase == TouchPhase.Began) {
                        recipient.SendMessage("OnTouchDown",position2,SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Ended) {
                        recipient.SendMessage("OnTouchUp",position2,SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
                        recipient.SendMessage("OnTouchStay",position2,SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Canceled) {
                        recipient.SendMessage("OnTouchExit",position2,SendMessageOptions.DontRequireReceiver);
                    }

                }

            }
            foreach (GameObject g in touchesOld) {
                if (!touchList.Contains(g)) {
                    g.SendMessage("OnTouchExit",position2,SendMessageOptions.DontRequireReceiver);
                }
            }
        }

    }
}
