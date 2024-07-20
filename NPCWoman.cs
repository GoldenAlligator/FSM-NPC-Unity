using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;

public class NPCWoman : Entity
{
    public TextMeshProUGUI stateText;

    #region Rigs
    public Rig box;
    public Rig Spoon;
    #endregion
    #region States
    public NPCWomanStateMachine stateMachine;
    public WomanCook WomanCook { get; private set; }
    public WomanEatBreakfast eatBreakfasst { get; private set; }
    public WomanEatDinner WomanEatDinner { get; private set; }
    public NpcAtMarket WomanGoMarket { get; private set; }
    public NpcMoveState moveState { get; private set; }
    public NpcSleep WomanNPCSleep { get; private set; }
    public NpcSocialize WomanSocialize { get; private set; }
    public WomanWakeUp womanWakeUp { get; private set; }
    public WomanWashDIshes WomanWashDIshes { get; private set; }
    #endregion
    public Transform[] actionPositions;
    public int currentActionIndex = 0;

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new NPCWomanStateMachine();
        WomanNPCSleep = new NpcSleep(this, stateMachine, "Idle");
        WomanCook = new WomanCook(this, stateMachine, "Idle");
        eatBreakfasst = new WomanEatBreakfast(this, stateMachine, "Idle");
        WomanEatDinner = new WomanEatDinner(this, stateMachine, "Idle");
        WomanGoMarket = new NpcAtMarket(this, stateMachine, "Idle");
        womanWakeUp = new WomanWakeUp(this, stateMachine, "Idle");
        moveState = new NpcMoveState(this, stateMachine, "Walk");
        WomanSocialize = new NpcSocialize(this, stateMachine, "Idle");
        WomanWashDIshes = new WomanWashDIshes(this, stateMachine, "Idle");
    }
    protected override void Start()
    {
        base.Start();
        stateMachine.Instatiate(womanWakeUp);

    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update(); UpdateStateText();


    }
    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    public void UpdateStateText()
    {
        if (stateText != null)
        {
            stateText.text = "Current State: " + stateMachine.currentState.GetType().Name;
        }
    }

}
