using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAtMarket : NPCWomanState
{
    public NpcAtMarket(NPCWoman npc, NPCWomanStateMachine stateMachine, string animBoolName) : base(npc, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter(); stateTimer = 10;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update(); if (stateTimer < 0)
            stateMachine.ChangeState(npc.moveState);

    }
}
