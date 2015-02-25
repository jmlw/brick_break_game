using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    public GameObject ballPrefab;
    public Paddle _paddle;

    ArrayList bricks;
    ArrayList balls;
    GameObject paddle;
    int ballCount;
    public int lifeCount = 3;

    Vector2 ballSpawnPosition;


    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
                
                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }
            
            return _instance;
        }
    }


    void Awake() {
        if(_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if(this != _instance)
                Destroy(this.gameObject);
        }

        setFixedFrameRate(60);

        ballSpawnPosition = _paddle.transform.FindChild("ballSpawnPosition").position;
    }

	// Use this for initialization
	void Start () {
        spawnBall();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void setFixedFrameRate(int targetFrames) {
        Debug.Log("Setting a target frame rate of: " + targetFrames);
        Application.targetFrameRate = targetFrames;
    }

    public void ballAdded() {
        Debug.Log("Ball Added");
        ++ballCount;
    }

    public void ballKilled() {
        Debug.Log("Ball Killed");
        --ballCount;

        if (ballCount <= 0)
        {
            gameOver();
        } else
        {
            spawnBall();
        }
    }

    void gameOver() {
        Debug.Log("Game Over!");
    }

    void spawnBall() {
//        ball_controller ball = (ball_controller)Instantiate(ballPrefab, ballSpawnPosition, Quaternion.identity);
//        ball.isAttached = true;
////        ball_controller ballScript = ball.GetComponents<ball_controller>();
////        ballScript.manager = this;
//        _paddle.setAttachedBall(ball);
//        ballAdded();
    }

//    public void registerBrick(GameObject brick) {
//
//    }
//
//    public void registerBall(GameObject ball) {
//
//    }

    public void registerBall(Ball ball) {
        balls.Add(ball);
    }

    public void removeBall(Ball ball) {
        balls.Remove(ball);
    }
    
    public void registerBrick(Brick brick) {
        bricks.Add(brick);
    }

    public void removeBrick(Brick brick) {
        bricks.Remove(brick);
    }
    
    public void registerPaddle(Paddle paddle) {
        
    }
}
