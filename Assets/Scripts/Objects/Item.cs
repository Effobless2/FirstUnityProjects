using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour {
    

    protected GameObject _player;

    public string ItemName;

    public float animationTime;

    public float animationTimeCount;

	// Use this for initialization
	public void Start () {
        animationTimeCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Link"))
        {
            collision.gameObject.GetComponent<Inventory>().ReceiveObject(this);

            _player = collision.gameObject;
                
            gameObject.SetActive(false);
        }

    }

    public abstract Item PutIn(Item newItem);

    public abstract void Use();
    
}
