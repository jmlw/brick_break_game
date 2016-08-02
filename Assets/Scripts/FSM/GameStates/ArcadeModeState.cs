using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class ArcadeMode : FSMState <GameManager>
{

    private FSMachine<ArcadeMode> arcadeModeStateMachine;

    private static ArcadeMode _instance = new ArcadeMode();

    public static ArcadeMode Instance
    {
        get
        {
            return _instance;
        }
    }

    public override void StateEnter(GameManager o)
    {
        Logger.Debug("State Enter: " + this.GetType().Name);
//        Application.LoadLevel(k.Scenes.PLAY_SCENE);

        // load play scene, play scene to display level picker menu 
        arcadeModeStateMachine = new FSMachine<ArcadeMode>();
        arcadeModeStateMachine.Configure(this, ArcadeModeLevelSelect.Instance);

        Application.LoadLevel(k.Scenes.PLAY_SCENE);
    }


    
    public override void StateUpdate(GameManager o)
    {
        // Logger.Debug("State Update: " + this.GetType().Name);

    }

    public override void StateExit(GameManager o)
    {
        Logger.Debug("State Exit: " + this.GetType().Name);
    }
    
    public void LevelSelected(int level) {
        level = 0;
        arcadeModeStateMachine.ChangeState(ArcadeModePlay.Instance);
    }
}
