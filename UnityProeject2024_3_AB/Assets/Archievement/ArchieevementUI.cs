using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchieevementUI : MonoBehaviour
{
    public GameObject archievementPanel;
    public GameObject archievementItemPrefabs;
    public Transform contect;

    private List<GameObject> archievementItems = new List<GameObject>();
    void Start()
    {
        UpdateArchievementUI();
    }
    public void UpdateArchievementUI()
    {
        foreach (var archievement in ArchievementManager.instance.archievements)
        {
            GameObject item = Instantiate(archievementItemPrefabs, contect);
            Text[] texts = item.GetComponentsInChildren<Text>();
            texts[0].text = archievement.name;
            texts[1].text = archievement.description;
            texts[2].text = $"{archievement.currentProgress}/{archievement.goal}";
            texts[3].text = archievement.isiUnlocked? "含失" : "耕含失";
            archievementItems.Add(item);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
