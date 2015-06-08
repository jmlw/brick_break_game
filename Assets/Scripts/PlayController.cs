using UnityEngine;
using System.Collections;

public class PlayController : MonoBehaviour {

    private FSMachine<PlayController> playStateMachine;
    private GameplayData data = GameplayData.Instance;

	// Use this for initialization
	void Start () {
        Logger.Debug("PlayController.Start initialize");
        playStateMachine = new FSMachine<PlayController>();
        PlayController playStateMachineOwner = this;

        playStateMachine.Configure(playStateMachineOwner, PlayInitState.Instance);
        Logger.Debug("PlayController.Start return");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
