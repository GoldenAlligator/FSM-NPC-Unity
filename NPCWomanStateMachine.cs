using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWomanStateMachine : MonoBehaviour
{
    public NPCWomanState currentState;
    public void Instatiate(NPCWomanState _startState)
    {
        currentState = _startState;
        currentState.Enter();

    }
    public void ChangeState(NPCWomanState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
