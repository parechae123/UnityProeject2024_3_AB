using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExPlayer : MonoBehaviour
{
    private int health = 100;

    public void TakeDamage(int damage)
    {
        //�÷��̾��� ü�� ����
        health -= damage;
        Debug.Log("�÷��̾� ü�� : " +  health);
        //ü���� 0 ������ �� ���ó��
        if (health <= 0)
        {
            DIe();
        }
    }

    private void DIe()
    {
        Debug.Log("�÷��̾� ���");
        //��� ���� �߰�
    }
}
