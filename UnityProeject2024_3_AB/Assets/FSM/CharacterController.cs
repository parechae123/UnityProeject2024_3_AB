using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : StateMachine
{
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new IdleState(this));
    }
}
