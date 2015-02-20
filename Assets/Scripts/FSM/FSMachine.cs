using UnityEngine;
using System.Collections;

public class FSMachine <T> {

    private T Owner;
    private FSMState<T> CurrentState;
    private FSMState<T> PreviousState;
    private FSMState<T> GlobalState;
    
    public void Awake() {
        CurrentState = null;
        PreviousState = null;
        GlobalState = null;
    }
    
    public void Configure(T owner, FSMState<T> InitialState) {
        Owner = owner;
        ChangeState(InitialState);
    }
    
    public void  Update() {
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

