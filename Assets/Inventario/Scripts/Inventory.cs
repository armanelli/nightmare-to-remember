using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventário : MonoBehaviour
{
    GameObject inventoryPanel;
    GameObject slotPanel;
    ItemDatabase database;

    public GameObject inventorySlot;
    public GameObject inventoryItem;

    int slotAmount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        database = GetComponent < ItemDatabase>();
        slotAmount = 6;//define o tamanho do inventário
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        slots.Add(Instantiate(inventorySlot));
        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots[i].transform.SetParent(slotPanel.transform);
        }

        AddItem(0);//adiciona o item de id 0
        AddItem(1);//adiciona o item de id 1

        Debug.Log(items[1].Title);
    }

    public void AddItem(int id)
    {
        Item itemToAdd = database.FentchItemByID(id);
        if (itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(inventoryItem);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.transform.position = Vector2.zero;
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    break;//vai sair do loop quando achar um slot pro item
                }
            }
        }
    }

    bool CheckIfItemIsInInventory(Item item)//verificará se o item coletado está presente no inventário
    {
        for (int i = 0; i < items.Count; i++)
        
            if (items[i].ID == item.ID)
                return true;
        
        return false;
    }
}

