using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Enter();
    void Execute();
    void Exit();
}

public class StateMachine : MonoBehaviour
{
    private IState currentState;

    private void Update()
    {
        currentState?.Execute();
    }

    public void ChangeState(IState newState)
    {
        currentState?.Exit();                   //이전 상태값을 빠져나간다
        currentState = newState;                //인수로 받아온 상태값을 입력
        currentState?.Enter();                  //다음 상태값
    }
}
/*void Enter()
{

}
void Execute()
{

}
void Exit()
{

}*/