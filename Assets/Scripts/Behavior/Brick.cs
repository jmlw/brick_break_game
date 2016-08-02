using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    private GameplayData data;

    void Awake() {
        data = GameplayData.Instance;
        data.registerBrick(this);
    }


    // TODO: finish!
    void OnCollisionEnter2D(Collision2D theCollision) {
        // Uncomment this line to check for collision
        Debug.Log("Hit " + theCollision.gameObject.name);

        if (theCollision.gameObject.name.Contains ("ball")) {
            data.removeBrick(this);
            Destroy(this.gameObject);
        }
    }
}
