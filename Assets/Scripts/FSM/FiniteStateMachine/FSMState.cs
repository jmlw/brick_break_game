using System.Collections;
using System.Collections.Generic;

abstract public class FSMState <T> {

    protected List<IStateUpdateable> toUpdate;

    public void registerUpdatable(IStateUpdateable item) {
       if (toUpdate == null) {
           toUpdate = new List<IStateUpdateable>();
       }
       toUpdate.Add(item);
   }

    public void removeUpdatable(IStateUpdateable item) {
       if (toUpdate == null)
       {
           return;
       }
       toUpdate.Remove(item);
   }

	abstract public void StateEnter (T entity);
	
    abstract public void StateUpdate (T entity);

    abstract public void StateExit (T entity);
}
