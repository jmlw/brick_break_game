using UnityEngine;
using System.Collections;

public class PlayController : MonoBehaviour {

//    private FSMachine<PlayController> playStateMachine;
    private GameplayData data = GameplayData.Instance;

    private static PlayController _instance;
    public static PlayController Instance {
        get {
            if(_instance == null) {
                _instance = GameObject.FindObjectOfType<PlayController>();
            }

            return _instance;
        }
    }

	// Use this for initialization
	void Start () {
        Logger.Debug("PlayController.Start initialize");
//        playStateMachine = new FSMachine<PlayController>();
//        PlayController playStateMachineOwner = this;

//        playStateMachine.Configure(playStateMachineOwner, LevelSelectState.Instance);
        Logger.Debug("PlayController.Start return");
	}
	
	
//	void PlayStateMachineUpdate () {
//        playStateMachine.StateUpdate();
//	}
        
}
