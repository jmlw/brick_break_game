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
        
        // This line looks for "laser" in the names of
        // anything collided.
        if (theCollision.gameObject.name.Contains ("ball")) {
            data.removeBrick(this);
            Destroy(this.gameObject);
        }
//        if (theCollision.gameObject.name.Contains ("laser")) {
//            LaserBehavior laser = theCollision.gameObject.GetComponent("LaserBehavior") as LaserBehavior;
//            health -= laser.damage;
//            audio.PlayOneShot(hitSound);
//            Destroy(theCollision.gameObject);
//        }
//        
//        if (health <= 0) {
//            Destroy(this.gameObject);
//            
//            if (explosion) {
//                GameObject exploder = ((Transform) Instantiate(explosion, 
//                                                               this.transform.position, 
//                                                               this.transform.rotation)).gameObject;
//                exploder.GetComponent<AudioSource>().Play();
//                Destroy(exploder, 2.0f);
//            }
//            
//            controller.KilledEnemy();
//        }
    }
}
