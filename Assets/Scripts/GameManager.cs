using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    public GameObject ballPrefab;

    public GameObject paddlePrefab;
    private Paddle paddle;
    private Transform paddleTransform;

    //TODO: Profile / figure out maximum number of bricks
    //Set list to size at least large enough to contain max bricks
    private List<Brick> bricks = new List<Brick>();

    //TODO: Should we have a max number of balls? Likely no,
    //but setting a default size for the list will increase performance
    //preventing list resizing later (Likely O(n) level complexity)
    private List<Ball> balls = new List<Ball>();
    private int ballCount;

    private int lifeCount = 3;

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

        spawnPaddle();
    }

	// Use this for initialization
	void Start () {
        spawnBall();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void setFixedFrameRate(int targetFrames) {
        Debug.Log("Setting a target frame rate of: " + targetFrames);
        Application.targetFrameRate = targetFrames;
    }

    private void ballAdded() {
        Debug.Log("Ball Added");
        ++ballCount;
    }

    private void ballKilled() {
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

    private void spawnPaddle() {
        if (paddle != null) {
            //Opps! This shouldn't happen
            Debug.LogError("Somebody tried to make another player!");
        } else {
            Instantiate(paddlePrefab, new Vector3(6,1, 0), Quaternion.identity);
//            paddle = paddleGO.GetComponent(typeof("Paddle"));
        }
    }

    void spawnBall() {
        Vector3 ballSpawnPosition = paddle.transform.FindChild("ballSpawnPosition").position;
        GameObject ballGO = (GameObject)Instantiate(ballPrefab, ballSpawnPosition, Quaternion.identity);

//        paddle.setAttachedBall(ball);
    }

    public void registerBall(Ball ball) {
        balls.Add(ball);
        ball.isAttached = true;
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
    
    public void registerPaddle(Paddle p) {
        //TODO: keep reference to the paddle
        //This will come in handy to perform "upgrades" on the paddle

        paddle = p;
        paddleTransform = paddle.transform;
    }
}
