using UnityEngine;
using System.Collections;

public sealed class ArcadeModeState : FSMState <GameManager> {



    private static ArcadeModeState _instance = new ArcadeModeState();
    public static ArcadeModeState Instance {
        get {
            return _instance;
        }
    }

    public override void StateEnter (GameManager o) {
        Logger.Debug("State Enter: " + this.GetType().Name);
//        Application.LoadLevel(k.Scenes.PLAY_SCENE);

		// Do not load play scene, display level picker menu / canvas -> switch to LevelSelectState : FSMState <GameManager>

        //TODO: init play state machine with Level Select initial state
        // level select initial state will initialize a level chooser
        // on statenetner, state exit will clear the level chooser from screne
    
        // RENAME TO ArcadeModeStateMachine

        // Or initialize a PlayStateMachine to handle all play state related stuff
        // and forward update calls to playstatemachine update to forward to states
    }


    
    public override void StateUpdate (GameManager o) {
        Logger.Debug("State Update: " + this.GetType().Name);
        // TODO: listen for level selection?
    }
    
    public override void StateExit (GameManager o) {
        Logger.Debug("State Exit: " + this.GetType().Name);
    }
}
