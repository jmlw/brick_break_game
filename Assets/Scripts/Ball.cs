using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public GameManager manager;
	Rigidbody2D rBody;

    public bool isAttached;

    void Awake() {
        
    }

	// Use this for initialization
	void Start () {
//        manager.ballAdded();

//		rBody = this.rigidbody2D;
//
//		rBody.velocity = new Vector2 (12, 12);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy() {
//        manager.ballKilled();
    }

    public void launch() {
        rigidbody2D.velocity = new Vector2(0, 20);
    }
}
