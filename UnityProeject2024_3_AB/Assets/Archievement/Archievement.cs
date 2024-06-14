using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[System.Serializable]
public class Archievement
{
    public string name;
    public string description;
    public bool isiUnlocked;
    public int currentProgress;         //���� ����
    public int goal;                    //Ƚ��

    public Archievement(string name, string description, int goal)
    {
        this.name = name;
        this.description = description;
        this.isiUnlocked = false;
        this.currentProgress = 0;
        this.goal = goal;
    }
    public void AddProgress(int amount)
    {
        if (!isiUnlocked)
        {
            currentProgress += amount;
            if (currentProgress >= goal)
            {
                isiUnlocked = true;
                OnArchievementUnlocked();
            }
        }
    }

    protected virtual void OnArchievementUnlocked()
    {
        Debug.Log($"���� �޼� : {name} ");
    }

}
