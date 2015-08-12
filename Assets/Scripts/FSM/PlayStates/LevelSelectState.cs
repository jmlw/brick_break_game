using UnityEngine;
using System.Collections;

public class LevelSelectState : FSMState <PlayController> {

    GameplayData gd = GameplayData.Instance;

    private static LevelSelectState _instance = new LevelSelectState();
    public static LevelSelectState Instance {
        get {
            return _instance;
        }
    }

    public override void StateEnter (PlayController entity) {
        // create initial Ball, attach to paddle?
        Logger.Debug("State Enter: " + this.GetType().Name);
        //TODO: init play state machine with Level Select initial state
        // level select initial state will initialize a level chooser
        // on statenetner, state exit will clear the level chooser from screen

    }
    
    public override void StateUpdate (PlayController entity) {
        Logger.Debug("State Update: " + this.GetType().Name);
        // wait for level select

    }
    
    public override void StateExit (PlayController entity) {
        Logger.Debug("State Exit: " + this.GetType().Name);
        // TODO: remove level chooser from screen if not done already
    }

}
