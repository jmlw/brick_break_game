using UnityEngine;
using System.Collections;

public class FSMachine <T> {

    private T Owner;
    private FSMState<T> CurrentState = null;
    private FSMState<T> PreviousState = null;
    private FSMState<T> GlobalState = null;
    
    
    public void Configure(T owner, FSMState<T> InitialState) {
        Owner = owner;
        ChangeState(InitialState);
    }
    
    public void  StateUpdate() {
        if (GlobalState != null)  GlobalState.StateUpdate(Owner);
        if (CurrentState != null) CurrentState.StateUpdate(Owner);
    }
    
    public void  ChangeState(FSMState<T> NewState) {
        PreviousState = CurrentState;
        if (CurrentState != null)
            CurrentState.StateExit(Owner);
        CurrentState = NewState;
        if (CurrentState != null)
            CurrentState.StateEnter(Owner);
    }
    
    public void  RevertToPreviousState() {
        if (PreviousState != null)
            ChangeState(PreviousState);
    }
}

