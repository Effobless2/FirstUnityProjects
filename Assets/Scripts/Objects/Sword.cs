using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : UniqueObject{

    // Use this for initialization
    new void Start () {
        base.Start();
        ItemName = "Sword";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Use()
    {
        _player.GetComponentInChildren<AttackTrigger>().SetUsedWeapon(this);

    }
    

}
