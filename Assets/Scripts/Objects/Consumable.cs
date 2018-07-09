using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumable : Item {

    public int quantity;

    // Use this for initialization
    new void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override Item PutIn(Item newItem)
    {
        quantity = newItem == null ? quantity : quantity + ((Consumable)newItem).quantity;
        return this;
    }
}
