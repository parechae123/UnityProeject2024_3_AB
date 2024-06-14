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
    public int currentProgress;         //진행 상태
    public int goal;                    //횟수

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
        Debug.Log($"업적 달성 : {name} ");
    }

}
