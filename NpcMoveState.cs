using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcMoveState : NPCWomanState
{
    public NpcMoveState(NPCWoman npc, NPCWomanStateMachine stateMachine, string animBoolName) : base(npc, stateMachine, animBoolName) { }

    public override void Enter()
    {
        base.Enter();
        // Set the NavMeshAgent to move to the current action position
        npc.navAgent.SetDestination(npc.actionPositions[npc.currentActionIndex].position);
    }

    public override void Update()
    {
        base.Update();
        // Check if the NPC has reached the destination
        if (!npc.navAgent.pathPending && npc.navAgent.remainingDistance <= npc.navAgent.stoppingDistance)
        {
            if (!npc.navAgent.hasPath || npc.navAgent.velocity.sqrMagnitude == 0f)
            {
                // Move to the next action state in the sequence
                npc.currentActionIndex = (npc.currentActionIndex + 1) % npc.actionPositions.Length;
                ChangeToNextActionState();
            }
        }
    }

    private void ChangeToNextActionState()
    {
        switch (npc.currentActionIndex)
        {
            case 0:
                stateMachine.ChangeState(npc.womanWakeUp);

                break;
            case 1:
                stateMachine.ChangeState(npc.eatBreakfasst);

                break;
            case 2:
                stateMachine.ChangeState(npc.WomanGoMarket);

                break;
            case 3:
                stateMachine.ChangeState(npc.WomanSocialize);


                break;
            case 4:
                stateMachine.ChangeState(npc.WomanCook);

                break;
            case 5:
                stateMachine.ChangeState(npc.WomanEatDinner);


                break;
            case 6:
                stateMachine.ChangeState(npc.WomanWashDIshes);

                break;
            case 7:
                stateMachine.ChangeState(npc.WomanNPCSleep);
                return;
                    break;
        }
    }
}
