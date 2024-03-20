using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExEnemy : MonoBehaviour
{
    public ExPlayer targetPlayer;

    //플레이어에게 입히는 데미지량,몬스터의 공격력
    private int damage = 20;

    //플레이어에게 피해를 줄 시 호출되는 함수
    public void AttackPlayer(ExPlayer player)
    {
        //플레이어에게 피해를 줌
        player.TakeDamage(damage);
        //player.health -= damage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (targetPlayer != null)
            {
                Debug.Log("공격");
                AttackPlayer(targetPlayer);
            }
            else
            {
                Debug.LogError("플레이어 안넣엇네");
            }
        }

    }

}
