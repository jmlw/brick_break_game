using UnityEngine;
using System.Collections;

public class PlayController : MonoBehaviour {

    private FSMachine<PlayController> playStateMachine;

	// Use this for initialization
	void Start () {
        playStateMachine = new FSMachine<PlayController>;
        playStateMachine.Configure();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
