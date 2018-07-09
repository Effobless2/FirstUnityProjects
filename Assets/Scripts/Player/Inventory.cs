using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private Dictionary<string, Item> _items;


    public string EquipedA;

    public string EquipedB;
    

    public Item GetEquipedAItem()
    {
        Item item;
        _items.TryGetValue(EquipedA, out item);
        return item;
    }

    public Item GetEquipedBItem()
    {
        Item item;
        _items.TryGetValue(EquipedB, out item);
        return item;
    }

    // Use this for initialization
    void Start () {
        _items = new Dictionary<string, Item>();
        EquipedA = null;
        EquipedB = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.C) && EquipedA != null)
        {
            Item usedItem;
            _items.TryGetValue(EquipedA, out usedItem);
            usedItem.Use();
        }
	}

    public void ReceiveObject(Item newItem)
    {
        Item lastItem;

        _items.TryGetValue(newItem.ItemName, out lastItem);

        _items.Add(newItem.ItemName, newItem.PutIn(lastItem));
        if (EquipedA == null)
        {
            EquipedA = newItem.ItemName;
        }

        else if (EquipedB == null)
        {
            EquipedB = newItem.ItemName;
        }
    }
}
