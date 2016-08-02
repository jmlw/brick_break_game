using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArcadeModePlay : FSMState<ArcadeMode> {

    private static ArcadeModePlay _instance = new ArcadeModePlay();
    public static ArcadeModePlay Instance {
        get {
            return _instance;
        }
    }

    public override void StateEnter (ArcadeMode o) {
        Logger.Debug("State Enter: " + this.GetType().Name);
        // Perform setup!
    }

    public override void StateUpdate (ArcadeMode o) {
        // Logger.Debug("State Update: " + this.GetType().Name);
        // Run state calculations / updates
    }

    public override void StateExit (ArcadeMode o) {
        Logger.Debug("State Exit: " + this.GetType().Name);
        // Cleanup
    }
}
