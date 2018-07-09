using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {


    public int LifePoints;

    public int FullLife;

    private PlayerController _playerController;
	// Use this for initialization
	void Start () {
        _playerController = gameObject.GetComponent<PlayerController>();

        LifePoints = FullLife;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hit(int damage)
    {
        LifePoints = Math.Max(LifePoints - damage, 0);

        if (LifePoints == 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Debug.Log("Killed");

        _playerController.Kill();

        //gameObject.SetActive(true);
    }

    public void ReceiveHearts(Item healItem)
    {
        switch (healItem.ItemName)
        {
            case "Heart":
                {
                    break;
                }
            case "Fairy" :
                {
                    break;
                }
            case "HeartReceptacle":
                {
                    break;
                }
        }
    }

    public void Recover()
    {
        LifePoints = FullLife;
    }
}
