using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWomanState : MonoBehaviour
{
    protected NPCWoman npc;
    protected NPCWomanStateMachine stateMachine;
    string animBoolName;
    protected Rigidbody rb;
    protected float stateTimer;
    protected bool triggerCalled;
    public NPCWomanState(NPCWoman npc, NPCWomanStateMachine stateMachine, string animBoolName)
    {
        this.npc = npc;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }
    public virtual void Enter()
    {
        npc.anim.SetBool(animBoolName, true);
        rb = npc.rb;
        triggerCalled = false;
    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;

    }
    public virtual void Exit()
    {
        npc.anim.SetBool(animBoolName, false);
    }
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
