using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Item
{
    private int index;
    private string name;
    private ItemType type;
    private Sprite image;

    public int Index
    {
        get { return index; }
        set { index = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public ItemType Type 
    { 
        get { return type; } 
        set { type = value; } 
    }
    public Sprite Image
    {
        get { return image;}
        set { image = value;}
    }
    public Item(int index, string name, ItemType itemType)
    {
        this.Index = index;
        this.Name = name;
        this.type = itemType;
    }
}
public enum ItemType
{
    Weapon,Armor,Potion,QuestItem
}


public class Inventory
{
    private Item[] items = new Item[16];

    //아이템 인덱서(Indexer)
    public Item this[int index]
    {
        get { return items[index]; }
        set { items[index] = value; }
    }

    //현재 인벤토리에 있는 아이템 수
    public int ItemCount
    {
        get 
        {
            int count = 0;
            foreach (Item item in items)
            {
                if (item != null)
                {
                    count++;
                }
            }

            return items.Length;
        }
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                return true;
            }
        }
        return false; // 인벤토리가 가득 찼을 경우\
    }

    public void RemoveItem(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == item)
            {
                items[i] = null;
                break;
            }
        }
    }
    

}


public class ExGameSystem : MonoBehaviour
{
    Inventory inventory = new Inventory();

    Item sword = new Item(0, "Sword", ItemType.Weapon);
    Item shield = new Item(1, "Shield", ItemType.Armor);

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inventory.AddItem(sword);
            DebugInventory();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            inventory.AddItem(shield);
            DebugInventory();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            inventory.AddItem(sword);
            DebugInventory();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            inventory.AddItem(shield);
            DebugInventory();
        }
    }

    void DebugInventory()
    {
        Debug.Log("Player Inventory" + GetInventoryAsString());
    }
    private string GetInventoryAsString()
    {
        string result = "";
        for (int i = 0; i < inventory.ItemCount; i++)
        {
            if (inventory[i] != null)
            {
                result += inventory[i].Name + ",";
            }
        }
        return result.TrimEnd(','); //마지막 쉼표 빼기
    }
}
