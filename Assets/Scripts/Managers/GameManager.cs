using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;
    private FSMachine<GameManager> gameStateMachine;

    public static GameManager Instance {
        get {
            if(_instance == null) {
                _instance = GameObject.FindObjectOfType<GameManager>();
                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }
            
            return _instance;
        }
    }

    void Awake() {
        if(_instance == null) {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        } else {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if(this != _instance)
                Destroy(this.gameObject);
        }

        setFixedFrameRate(60);

        gameStateMachine = new FSMachine<GameManager>();
        gameStateMachine.Configure(this, MenuMainState.Instance); // TODO: SET INITIAL STATE

//        spawnPaddle();
    }

    void Update() {
        gameStateMachine.StateUpdate();
    }

    private void setFixedFrameRate(int targetFrames) {
        Logger.Debug("Setting a target frame rate of: " + targetFrames);
        Application.targetFrameRate = targetFrames;
    }

    public void actionArcadeMode() {
        gameStateMachine.ChangeState(ArcadeModeState.Instance);
    }

    public void actionEndlessMode() {
        gameStateMachine.ChangeState(EndlessModeState.Instance);
    }

    public void actionScoreboard() {
        gameStateMachine.ChangeState(ScoreboardState.Instance);
    }

    public void actionSettings() {
        gameStateMachine.ChangeState(SettingsState.Instance);
    }


// Use this for initialization
//  void Start () {
//        spawnBall();
//  }

// Update is called once per frame
//  void Update () {
//  
//  }
//    
//    private void ballAdded() {
//        Debug.Log("Ball Added");
//        ++ballCount;
//    }
//
//    private void ballKilled() {
//        Debug.Log("Ball Killed");
//        --ballCount;
//
//        if (ballCount <= 0)
//        {
//            gameOver();
//        } else
//        {
//            spawnBall();
//        }
//    }
//
//    void gameOver() {
//        Debug.Log("Game Over!");
//    }
//
//    private void spawnPaddle() {
//        if (paddle != null) {
//            //Opps! This shouldn't happen
//            Debug.LogError("Somebody tried to make another player!");
//        } else {
//            GameObject paddleGO = (GameObject) Instantiate(paddlePrefab, new Vector3(8,1, 0), Quaternion.identity);
//            paddleTransform = paddleGO.transform;
//        }
//    }
//
//    void spawnBall() {
//        Vector3 ballSpawnPosition = paddle.transform.FindChild("ballSpawnPosition").position;
//        GameObject ballGO = (GameObject)Instantiate(ballPrefab, ballSpawnPosition, Quaternion.identity);
//
////        paddle.setAttachedBall(ball);
//    }
//
//    private void launchBall() {
//        Ball b = attachedBalls.Pop();
//        // TODO: perform launch
//        b.launch();
//    }
}
