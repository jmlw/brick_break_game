using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

//    public float skinWidth = 0.15f;

    private GameplayData data;
    private Transform ballTransform;
    public float ballSpeed = 5;
	Rigidbody2D rBody;
    private Vector2 originalPos;

//    public bool isAttached;

    public bool triggerLaunch = false;
    public bool triggerReset = false;

    [Range(0f,360f)]
    public float maxTheta = 0;
    [Range(0f,360f)]
    public float minTheta = 0;

//    private int raysInCircle = 16; //number of pie slices to divide ball into when raycasting

    void Awake() {
        data = GameplayData.Instance;
        data.registerBall(this);
        ballTransform = this.transform;
        originalPos = ballTransform.position;
    }


    void OnDestroy() {
        data.removeBall(this);
    }

    void Update() {
        if (triggerLaunch)
        {
            Launch();
            triggerLaunch = false;
        }

        if (triggerReset)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            ballTransform.position = originalPos;
            triggerReset = false;
        }
    }

    public void Launch() {
        float randTheta = Random.Range(minTheta, maxTheta);
        Logger.Debug("theta: " + randTheta);
        float xComponent = Mathf.Cos(Mathf.Deg2Rad * randTheta);
        float yComponent = Mathf.Sin(Mathf.Deg2Rad * randTheta);
        GetComponent<Rigidbody2D>().velocity = (new Vector2(xComponent, yComponent)).normalized * ballSpeed;
    }
}
