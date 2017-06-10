using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour
{
    private List<Item> database = new List<Item>();
    private JsonData itemData;

    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/items.json"));
        ConstructItemDatabase();

        Debug.Log(database[1].Title);
    }
    
    public Item FentchItemByID(int id)
    {
        for (int i = 0; i < database.Count; i++)
            if(database[i].ID == id)
                return database[i];
        return null;
    }

void ConstructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), itemData[i]["description"].ToString(), itemData[i]["slug"].ToString(), (bool)itemData[i]["stackable"]));
        }
    }
}
public class Item
{
    //Getters & Setters de cada atribudo do item
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public bool Stackable { get; set; }
    public Sprite Sprite { get; set; }

    public Item(int id, string title, string description, string slug, bool stackable)
    {
        this.ID = id;
        this.Title = title;
        this.Description = description;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("/Resources/Items" + slug);
    }



    public Item()
    {
        this.ID = -1;
    }
}