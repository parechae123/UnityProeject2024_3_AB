using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private StateMachine statMachine;
    private float duration = 2.0f;
    private float timer;
    public IdleState(StateMachine statMachine)//생성자
    {
        this.statMachine = statMachine;
    }

    public void Enter()
    {
        Debug.Log("Entered Idle State");
        timer = 0f;
    }
    public void Execute()
    {
        timer += Time.deltaTime;
        if (timer > duration) 
        {
            //다음 전환 함수
            statMachine.ChangeState(new PatrolState(statMachine));
        }
    }

    public void Exit() 
    {
        Debug.Log("Exiting Idle State");    
    }
}
