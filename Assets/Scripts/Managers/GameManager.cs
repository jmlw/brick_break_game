using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;
    private FSMachine<GameManager> gameStateMachine;

    public static GameManager Instance {
        get {
            if(_instance == null) {
                _instance = GameObject.FindObjectOfType<GameManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            
            return _instance;
        }
    }

    void Awake() {
        if(_instance == null) {
            _instance = this;
            DontDestroyOnLoad(this);
        } else {
            if(this != _instance)
                Destroy(this.gameObject);
        }

        setFixedFrameRate(60);

        gameStateMachine = new FSMachine<GameManager>();
        gameStateMachine.Configure(this, MenuMainState.Instance);
    }

    void Update() {
        gameStateMachine.StateUpdate();
    }

    private void setFixedFrameRate(int targetFrames) {
        Logger.Debug("Setting a target frame rate of: " + targetFrames);
        Application.targetFrameRate = targetFrames;
    }

    public void actionArcadeMode() {
        Logger.Debug("State changing to ArcadeMode");
        gameStateMachine.ChangeState(ArcadeModeState.Instance);
    }

    public void actionEndlessMode() {
        Logger.Debug("State changing to EndlessMode");
        gameStateMachine.ChangeState(EndlessModeState.Instance);
    }

    public void actionScoreboard() {
        Logger.Debug("State changing to Scoreboard");
        gameStateMachine.ChangeState(ScoreboardState.Instance);
    }

    public void actionSettings() {
        Logger.Debug("State changing to Settings");
        gameStateMachine.ChangeState(SettingsState.Instance);
    }
}
