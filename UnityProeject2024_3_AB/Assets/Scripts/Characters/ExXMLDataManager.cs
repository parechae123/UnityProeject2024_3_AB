using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerData
{
    public string playerName;
    public int playerLevel;
    public List<string> items = new List<string>();
}



[System.Serializable]
public class ExXMLDataManager : MonoBehaviour
{
    string filePath;
    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.persistentDataPath + "/playerData.xml";
        Debug.Log(filePath);
    }

    void SaveData(PlayerData data)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));
        FileStream stream = new FileStream(filePath, FileMode.Create);
        serializer.Serialize(stream, data);
        stream.Close();
    }
    PlayerData LoadData()
    {
        if (File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));
            FileStream stream = new FileStream(filePath, FileMode.Open);
            PlayerData data = (PlayerData)serializer.Deserialize(stream);
            stream.Close();
            return data;
        }
        else 
        { 
            return null;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerData playerData = new PlayerData();
            playerData.playerName = "플레이어1";
            playerData.playerLevel = 1;
            playerData.items.Add("돌1");
            playerData.items.Add("바위1");
            SaveData(playerData);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerData playerData = new PlayerData();
            
            playerData = LoadData();

            Debug.Log(playerData.playerName);
            Debug.Log(playerData.playerLevel);
            for (int i = 0; i < playerData.items.Count; i++)
            {
                Debug.Log(playerData.items[i]);
            }
        }
    }
}
