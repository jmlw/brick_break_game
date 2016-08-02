using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArcadeModeLevelSelect : FSMState<ArcadeMode> {

    private static ArcadeModeLevelSelect _instance = new ArcadeModeLevelSelect();
    public static ArcadeModeLevelSelect Instance {
        get {
            return _instance;
        }
    }
    
    private bool conditionToMoveToNextState = false;

    public override void StateEnter (ArcadeMode o) {
        Logger.Debug("State Enter: " + this.GetType().Name);
        // Perform setup!
        
    }

    public override void StateUpdate (ArcadeMode o) {
        // Logger.Debug("State Update: " + this.GetType().Name);
        // Run state calculations / updates
        if (conditionToMoveToNextState) {
            // move to next state using OWNER
        } else {
            o.LevelSelected(0);
        }
    }

    public override void StateExit (ArcadeMode o) {
        Logger.Debug("State Exit: " + this.GetType().Name);
        // Cleanup
    }
}
