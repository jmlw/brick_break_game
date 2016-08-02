using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class EndlessModeState : FSMState <GameManager> {

    private static EndlessModeState _instance = new EndlessModeState();
    public static EndlessModeState Instance {
        get {
            return _instance;
        }
    }

    public override void StateEnter (GameManager o) {
        Logger.Debug("State Enter: " + this.GetType().Name);
    }
    
    public override void StateUpdate (GameManager o) {
        // Logger.Debug("State Update: " + this.GetType().Name);
    }
    
    public override void StateExit (GameManager o) {
        Logger.Debug("State Exit: " + this.GetType().Name);
    }
}
