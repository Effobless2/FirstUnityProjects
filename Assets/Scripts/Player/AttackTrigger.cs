using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {
    
    private float _attackTime;
    private float _attackTimeCounter;

    private Animator _anim;
    private Rigidbody2D _rigidbody;
    

    private Inventory _inventory;

    private UniqueObject _usedWeapon;

    private PlayerController _player;
    
    

    public void SetUsedWeapon(UniqueObject usedItem)
    {
        _usedWeapon = usedItem;
        _attackTimeCounter = _attackTime;
        _anim.SetBool("PlayerMoving", false);
        _rigidbody.velocity = Vector2.zero;
        

    }


    // Use this for initialization
    void Start () {

        _attackTime = 0.5f;
        _attackTimeCounter = 0f;
        _anim = GetComponentInParent<Animator>();

        _rigidbody = GetComponentInParent<Rigidbody2D>();
        

        _inventory = GetComponentInParent<Inventory>();
        _player = GetComponentInParent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (_usedWeapon != null)
        {

            _attackTimeCounter -= Time.deltaTime;

            if (_attackTimeCounter <= 0)
            {
                _usedWeapon = null;

                _attackTimeCounter = 0f;
            }
        }
        _anim.SetBool("Attack", _usedWeapon  != null);
    }
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
            Rigidbody2D rigid = collision.gameObject.GetComponent<Rigidbody2D>();

            collision.gameObject.GetComponent<EnnemyController>().Damaged(_usedWeapon.level, _player.LastMove * 15);
        }
        
    }


}
