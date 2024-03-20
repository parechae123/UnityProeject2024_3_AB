using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExPlayer : MonoBehaviour
{
    private int health = 100;

    public void TakeDamage(int damage)
    {
        //플레이어의 체력 감소
        health -= damage;
        Debug.Log("플레이어 체력 : " +  health);
        //체력이 0 이하일 시 사망처리
        if (health <= 0)
        {
            DIe();
        }
    }

    private void DIe()
    {
        Debug.Log("플레이어 사망");
        //사망 로직 추가
    }
}
