using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UniqueObject : Item {

    public int level;
    private static bool took;

    // Use this for initialization
    public new void Start () {
        base.Start();
        if (took)
        {
            Destroy(gameObject);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override Item PutIn(Item newItem)
    {

        DontDestroyOnLoad(gameObject);
        took = true;
        level = newItem == null ? level : Mathf.Max(level, ((UniqueObject) newItem).level);
        return this;
    }
    
}
