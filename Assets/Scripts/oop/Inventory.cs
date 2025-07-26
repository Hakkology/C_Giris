using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Single,
    Quest
}

[System.Serializable]
public class Malzeme
{
    public string itemName;
    public ItemType itemType;
    public string description;
    public int quantity;

    public Malzeme(string name, string desc, int qty)
    {
        itemName = name;
        description = desc;
        quantity = qty;
    }
}

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory", order = 2)]
public class Inventory : ScriptableObject
{
    public List<Malzeme> items = new List<Malzeme>();

    public void AddItem(Malzeme itemToAdd)
    {
        bool itemExists = false;

        // Envanter listesindeki her öðe için döngü
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemName == itemToAdd.itemName)
            {
                // Eðer eþya bulunursa, miktarýný artýr
                items[i].quantity += itemToAdd.quantity;
                itemExists = true;
                break;
            }
        }

        // Eðer eþya bulunamazsa, yeni olarak listeye ekle
        if (!itemExists)
        {
            items.Add(itemToAdd);
        }
    }

    public void RemoveItem(Malzeme itemToRemove)
    {
        if (itemToRemove.itemType == ItemType.Quest)
        {
            Debug.Log("lA BÝ GÝT");
            return;
        }
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemName == itemToRemove.itemName && items[i].description == itemToRemove.description)
            {

                // Eþyanýn miktarýný azalt
                items[i].quantity -= itemToRemove.quantity;

                // Eðer miktar 0 veya daha az ise, listeden çýkar
                if (items[i].quantity <= 0)
                {
                    items.RemoveAt(i);
                    break;
                }
            }
        }

        //itens.Add()
    }
}
