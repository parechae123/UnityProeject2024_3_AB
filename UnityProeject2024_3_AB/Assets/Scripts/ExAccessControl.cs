using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExAccessControl : MonoBehaviour
{
    public int publicValue;
    private int privateValue;
    protected int protectedValue;
    //internal로 선언된 변수는 같은 어셈블리(프로젝트 내 다른 스크립트)내에서 접근 가능
    //유니티 외의 같은 어셈블리 안에만 있다면 사용이 가능하다고 하시는데 좀 더 자세히 알아봐야할듯함 대화 정황 상 Static은 그게 안되는거같음
    internal int interanlValue;
}
