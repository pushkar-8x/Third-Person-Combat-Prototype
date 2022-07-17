using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetingState : PlayerBaseState
{
    private readonly int TargetingBlendTreeHash = Animator.StringToHash("TargetingState");
  
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
        

        if(stateMachine.targeter.CurrentTarget==null)
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
            return;
        }

        Vector3 movement = CalculateMovement();
        Move(movement * stateMachine.TargetingMovementSpeed, deltaTime);

        FaceTarget();
    }

    void OnCancel()
    {
        stateMachine.targeter.Cancel();
        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    }

    private Vector3 CalculateMovement()
    {
        Vector3 movement = new Vector3();

        movement += stateMachine.transform.right * stateMachine.InputReader.MovementValue.x;

        movement += stateMachine.transform.forward * stateMachine.InputReader.MovementValue.y;

        return movement;
    }

    public override void Exit()
    {
        stateMachine.InputReader.cancelEvent -= OnCancel;
    }

    

    
}
