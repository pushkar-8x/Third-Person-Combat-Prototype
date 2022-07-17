using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void Move(Vector3 motion , float deltaTime)
    {
        stateMachine.Controller.Move((motion + stateMachine.ForceReciever.Movement) * deltaTime);
    }

    protected void FaceTarget()
    {
        if (stateMachine.targeter.CurrentTarget == null)
            return;

        Vector3 lookPos = stateMachine.targeter.CurrentTarget.transform.position - stateMachine.transform.position;

        lookPos.y = 0;

        stateMachine.transform.rotation = Quaternion.LookRotation(lookPos);


    }
}
