using UnityEngine;
using System.Collections;

public class destroyer : MonoBehaviour {

    public GameManager manager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider) {
        //if ball, inform game manager
        Debug.Log("Destroyer Collision Enter 2d");
        if (collider.gameObject.tag == "Ball")
        {
            Debug.Log("Ball to be destroyed");
            manager.removeBall((Ball)collider.gameObject.GetComponent(typeof(Ball)));
            Destroy(collider.gameObject);
        } else
        {
            //now destroy
            Destroy(collider.gameObject);  //TODO: return object to pool?
        }
    }
}
