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


    void OnDestroy() {
        data.removeBall(this);  
    }

    public void launch() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
    }
}
