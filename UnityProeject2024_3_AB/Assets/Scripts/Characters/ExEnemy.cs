using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExEnemy : MonoBehaviour
{
    public ExPlayer targetPlayer;

    //�÷��̾�� ������ ��������,������ ���ݷ�
    private int damage = 20;

    //�÷��̾�� ���ظ� �� �� ȣ��Ǵ� �Լ�
    public void AttackPlayer(ExPlayer player)
    {
        //�÷��̾�� ���ظ� ��
        player.TakeDamage(damage);
        //player.health -= damage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (targetPlayer != null)
            {
                Debug.Log("����");
                AttackPlayer(targetPlayer);
            }
            else
            {
                Debug.LogError("�÷��̾� �ȳ־���");
            }
        }

    }

}
