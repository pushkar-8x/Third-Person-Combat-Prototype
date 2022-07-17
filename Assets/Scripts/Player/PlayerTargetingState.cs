using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetingState : PlayerBaseState
{
    private readonly int TargetingBlendTreeHash = Animator.StringToHash("TargetingState");
  //  PlayerStateMachine stateMachine;
    public PlayerTargetingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public override void Enter()
    {
        stateMachine.InputReader.cancelEvent += OnCancel;
        stateMachine.Animator.Play(TargetingBlendTreeHash);
    }


    public override void Tick(float deltaTime)
    {
        Debug.Log(stateMachine.targeter.CurrentTarget.name);

        if(stateMachine.targeter.CurrentTarget==null)
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
        stateMachine.InputReader.cancelEvent -= OnCancel;
    }

    void OnCancel()
    {
        stateMachine.targeter.Cancel();
        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    }

    
}
