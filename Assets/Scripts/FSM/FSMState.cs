using System.Collections;

abstract public class FSMState <T> {

	
    abstract public void StateEnter (T entity);
	
    abstract public void StateUpdate (T entity);

    abstract public void StateExit (T entity);
}
