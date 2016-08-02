using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class MenuMainState : FSMState <GameManager> {

    private static MenuMainState _instance = new MenuMainState();
    public static MenuMainState Instance {
        get {
            return _instance;
        }
    }

    public override void StateEnter (GameManager o) {
        Logger.Debug("State Enter: " + this.GetType().Name);
        // Load Main Menu scene?
    }
    
    public override void StateUpdate (GameManager o) {
        // Logger.Debug("State Update: " + this.GetType().Name);
        // Listen for button clicks on Main Menu??
        // This may not be necessary with Unity's GUI
        // messaging system to wire actions with the editor
    }
    
    public override void StateExit (GameManager o) {
        Logger.Debug("State Exit: " + this.GetType().Name);

    }
}
