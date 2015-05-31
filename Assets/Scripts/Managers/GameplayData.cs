using UnityEngine;
using System.Collections.Generic;

public class GameplayData {

    private Paddle paddle;
    private Transform paddleTransform;

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

    public void registerBall(Ball ball) {
        balls.Add(ball);
        ball.isAttached = true;
        attachedBalls.Push(ball);
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
