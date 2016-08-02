using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class SettingsState : FSMState <GameManager> {

    private static SettingsState _instance = new SettingsState();
    public static SettingsState Instance {
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
