using UnityEngine;
using System.Collections;

public class LevelSelectState : FSMState <GameManager> {

    GameplayData gd = GameplayData.Instance;

    private static LevelSelectState _instance = new LevelSelectState();
    public static LevelSelectState Instance {
        get {
            return _instance;
        }
    }

	public override void StateEnter (GameManager entity) {
        
        Logger.Debug("State Enter: " + this.GetType().Name);
        
		// read XML? of levels in (name, lvl #, (unlockable, locked for future release?), etc...), 
		// load last completed level and set all below unlocked, generate grid for all levels
		// 

    }
    
	public override void StateUpdate (GameManager entity) {
        Logger.Debug("State Update: " + this.GetType().Name);
        // wait for level select

    }
    
	public override void StateExit (GameManager entity) {
        Logger.Debug("State Exit: " + this.GetType().Name);
        // TODO: remove level chooser from screen if not done already
    }

}
