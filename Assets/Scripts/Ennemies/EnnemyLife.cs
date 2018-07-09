using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyLife : MonoBehaviour {

    public int LifePoints;

    private Rigidbody2D _rigidbody;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage(int dmg)
    {
        LifePoints = Mathf.Max(LifePoints - dmg, 0);
        if (LifePoints == 0)
        {
            Destroy(gameObject);
        }
        else
        {

        }
    }
}
