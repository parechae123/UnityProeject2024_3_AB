using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExAccessControl : MonoBehaviour
{
    public int publicValue;
    private int privateValue;
    protected int protectedValue;
    //internal�� ����� ������ ���� �����(������Ʈ �� �ٸ� ��ũ��Ʈ)������ ���� ����
    //����Ƽ ���� ���� ����� �ȿ��� �ִٸ� ����� �����ϴٰ� �Ͻôµ� �� �� �ڼ��� �˾ƺ����ҵ��� ��ȭ ��Ȳ �� Static�� �װ� �ȵǴ°Ű���
    internal int interanlValue;
}
