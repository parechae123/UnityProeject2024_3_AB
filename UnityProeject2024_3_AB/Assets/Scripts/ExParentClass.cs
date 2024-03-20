using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExParentClass : MonoBehaviour
{
    protected int protectedValueParent;
}

public class ExChildClass : ExParentClass
{
    void Start()
    {
        Debug.Log(protectedValueParent);

    }
}
