using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IState
{
    private StateMachine statMachine;
    private float duration = 2.0f;
    private float timer;
    public ChaseState(StateMachine statMachine)//생성자
    {
        this.statMachine = statMachine;
    }

    public void Enter()
    {
        Debug.Log("Entered Chase State");
        timer = 0f;
    }
    public void Execute()
    {
        timer += Time.deltaTime;
        if (timer > duration)
        {
            //다음 전환 함수
            statMachine.ChangeState(new IdleState(statMachine));
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting Chase State");
    }
}
