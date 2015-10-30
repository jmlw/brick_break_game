using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayState : FSMState <PlayController> {

    GameplayData gd = GameplayData.Instance;

    bool launchBall;

    private static PlayState _instance = new PlayState();
    public static PlayState Instance {
        get {
            return _instance;
        }
    }

    public override void StateEnter (PlayController entity) {
        Logger.Debug("State Enter: " + this.GetType().Name);
        GameObject initBall = (GameObject)GameObject.Instantiate(Resources.Load("ball"));
        initBall.transform.SetParent(
            gd.getBallSpawnPosition(), 
            false);

    }
    
    public override void StateUpdate (PlayController entity) {
        Logger.Debug("State Update: " + this.GetType().Name);
        // TODO: get input from input controller
        // if input, then do Paddle Move
        // other checks / operations to do?
        if (launchBall == true) {
            Stack<Ball> attachedBalls = gd.getAttachedBalls();
            foreach (Ball b in attachedBalls) {
                b.Launch();
            }
        }
    }
    
    public override void StateExit (PlayController entity) {
        Logger.Debug("State Exit: " + this.GetType().Name);
    }

}
