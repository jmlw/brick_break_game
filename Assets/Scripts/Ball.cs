using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private GameManager manager;
    private GameObject  managerObj;
	Rigidbody2D rBody;

    public bool isAttached;

    void Awake() {
        manager = GameManager.Instance;
        manager.registerBall(this);
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy() {
        manager.removeBall(this);  
    }

    void FixedUpdate() {
        velocityCheck();
    }

    private void velocityCheck() {

    }

    public void launch() {
        rigidbody2D.velocity = new Vector2(0, 20);
    }
}
