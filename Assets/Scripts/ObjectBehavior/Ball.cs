using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

//    public float skinWidth = 0.15f;

    private GameplayData data;
    private Transform ballTransform;
    public float ballSpeed = 5;
	Rigidbody2D rBody;

    public bool isAttached;

//    private int raysInCircle = 16; //number of pie slices to divide ball into when raycasting

    void Awake() {
        data = GameplayData.Instance;
        data.registerBall(this);
        ballTransform = this.transform;
    }

    void OnCollisionEnter2D (Collision2D collider) {
        //TODO: check position ball hit paddle
        // calculate how much X velocity to add
        // normailze ball speed from collision 
    }


    void OnDestroy() {
        data.removeBall(this);  
    }

    public void launch() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
    }

//    public void checkCollisions() {
//        Vector2 raycastOrigin = ballTransform.position;
//    }
}
