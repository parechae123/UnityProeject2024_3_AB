using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchievementManager : MonoBehaviour
{
    public static ArchievementManager instance;
    public List<Archievement> archievements;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void AddProgress(string archievementName , int amount)
    {
        Archievement archievement = archievements.Find(a=>a.name == archievementName);
        if (archievement != null) { archievement.AddProgress(amount); }
    }
}
