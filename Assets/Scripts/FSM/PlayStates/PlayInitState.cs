using UnityEngine;
using System.Collections;

public class PlayInitState : FSMState <PlayController> {

    GameplayData gd = GameplayData.Instance;

    private static PlayInitState _instance = new PlayInitState();
    public static PlayInitState Instance {
        get {
            return _instance;
        }
    }

    public override void StateEnter (PlayController entity) {
        // create initial Ball, attach to paddle?
        Logger.Debug("PlayInitState Enter");
        GameObject initBall = (GameObject)GameObject.Instantiate(Resources.Load("ball"));
        initBall.transform.SetParent(
            gd.getBallSpawnPosition(), 
            false);
    }
    
    public override void StateUpdate (PlayController entity) {
        // wait for first tap to launch ball, launch in direction of tap
        // move to playing state
    }
    
    public override void StateExit (PlayController entity) {

    }

}
