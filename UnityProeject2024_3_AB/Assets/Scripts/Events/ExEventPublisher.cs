using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExEventPublisher : MonoBehaviour
{
    public ExEventChannel[] eventChannel;

    private void Update()
    {
        //�����̽��ٸ� ������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            eventChannel[0].RaiseEvent();  //��ũ���ͺ� �̺�Ʈ ȣ��
        }
        //W�� ������
        if (Input.GetKeyDown(KeyCode.W))
        {
            eventChannel[1].RaiseEvent();  //��ũ���ͺ� �̺�Ʈ ȣ��
        }
    }
}
