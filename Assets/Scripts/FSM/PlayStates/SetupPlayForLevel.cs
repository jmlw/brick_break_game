using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetupPlayForLevel : FSMState <PlayController> {
	
	GameplayData gd = GameplayData.Instance;

	bool launchBall;

	private static SetupPlayForLevel _instance = new SetupPlayForLevel();
	public static SetupPlayForLevel Instance {
        get {
            return _instance;
        }
    }

    public override void StateEnter (PlayController entity) {
        Logger.Debug("State Enter: " + this.GetType().Name);
		// TODO: Layout Bricks
		// TOOD: Setup Paddle and Ball
		GameObject initBall = (GameObject)GameObject.Instantiate(Resources.Load("ball"));
		initBall.transform.SetParent(
			gd.getBallSpawnPosition(), 
			false);
		
    }
    
    public override void StateUpdate (PlayController entity) {
        // Logger.Debug("State Update: " + this.GetType().Name);
		// TODO: Switch to playstate on first tap!!!

		if (launchBall == true) {
			Stack<Ball> attachedBalls = gd.getAttachedBalls();
			foreach (Ball b in attachedBalls) {
//				b.launch();
			}
		}
    }
    
    public override void StateExit (PlayController entity) {
        Logger.Debug("State Exit: " + this.GetType().Name);
    }

}
