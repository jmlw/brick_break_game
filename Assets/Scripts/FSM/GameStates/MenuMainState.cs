using UnityEngine;
using System.Collections;

public sealed class MenuMainState : FSMState <GameManager> {

    private static MenuMainState _instance = new MenuMainState();
    public static MenuMainState Instance {
        get {
            return _instance;
        }
    }

    public override void StateEnter (GameManager o) {
        // Load Main Menu scene?
    }
    
    public override void StateUpdate (GameManager o) {
        // Listen for button clicks on Main Menu??
        // This may not be necessary with Unity's GUI
        // messaging system to wire actions with the editor
    }
    
    public override void StateExit (GameManager o) {

    }
}
