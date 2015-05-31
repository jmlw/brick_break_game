using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private GameplayData data;
	Rigidbody2D rBody;

    public bool isAttached;

    void Awake() {
        data = GameplayData.Instance;
        data.registerBall(this);
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy() {
        data.removeBall(this);  
    }

    void FixedUpdate() {
        velocityCheck();
    }

    private void velocityCheck() {

    }

    public void launch() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
    }
}
