using UnityEngine;
using System.Collections.Generic;

public class GameplayData {

    private GameObject paddlePrefab;
    private GameObject paddle;
    private Transform paddleTransform;
    private Transform ballSpawnPosition;

    public enum boundary{
        LEFT,
        TOP,
        RIGHT,
        BOTTOM
    };
    private Dictionary<boundary, Transform> bounds = new Dictionary<boundary, Transform>();

    //TODO: Profile / figure out maximum number of bricks
    //Set list to size at least large enough to contain max bricks
    private List<Brick> bricks = new List<Brick>();
    
    //TODO: Should we have a max number of balls? Likely no,
    //but setting a default size for the list will increase performance
    //preventing list resizing later (Likely O(n) level complexity)
    private List<Ball> balls = new List<Ball>();
    private Stack<Ball> attachedBalls = new Stack<Ball>();
    private int ballCount;
    
    private int lifeCount = 3;

    private static GameplayData _instance = new GameplayData();
    public static GameplayData Instance {
        get {
            return _instance;
        }
    }

    public int getLives() {
        return lifeCount;
    }

    public Dictionary<boundary, Transform> getBounds() {
        if (bounds.Count != 4) {
            Logger.Debug("GameplayData.getBounds: Bounds initializing");
            bounds.Clear();
            bounds.Add(boundary.LEFT, GameObject.FindGameObjectWithTag("BorderLeft").transform);
            bounds.Add(boundary.TOP, GameObject.FindGameObjectWithTag("BorderTop").transform);
            bounds.Add(boundary.RIGHT, GameObject.FindGameObjectWithTag("BorderRight").transform);
            bounds.Add(boundary.BOTTOM, GameObject.FindGameObjectWithTag("BorderDestroyer").transform);
            Logger.Debug("GameplayData.getBounds: Bounds initiaized successfully");
        }
        Logger.Debug("GameplayData.getBounds");
        return bounds;
    }

    public void registerBall(Ball ball) {

        balls.Add(ball);
        ball.isAttached = true;
        attachedBalls.Push(ball);
        Logger.Debug("Ball Registered");
    }
    
    public void removeBall(Ball ball) {
        balls.Remove(ball);
        Logger.Debug("Ball Removed");
    }
    
    public void registerBrick(Brick brick) {
        bricks.Add(brick);
        Logger.Debug("Brick Registered");
    }
    
    public void removeBrick(Brick brick) {
        bricks.Remove(brick);
        Logger.Debug("Brick Removed");
    }
    
    public void registerPaddle(GameObject p) {
        //TODO: keep reference to the paddle
        //This will come in handy to perform "upgrades" on the paddle
        
        paddle = p;
        paddleTransform = paddle.transform;
        ballSpawnPosition = paddleTransform.FindChild("ballSpawnPosition");
        Logger.Debug("Paddle Registered");
    }

    public GameObject getPaddleGO() {
        return paddle;
    }

    public Transform getPaddleTransform() {
        return paddleTransform;
    }

    public Transform getBallSpawnPosition() {
        return ballSpawnPosition;
    }
}
