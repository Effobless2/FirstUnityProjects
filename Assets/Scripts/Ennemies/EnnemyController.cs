using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyController : MonoBehaviour {

    private Rigidbody2D _rigidbody;

    private Animator _anim;

    private EnnemyLife _life;

    public float MoveSpeed;

    private bool _moving;

    public float TimeBetweenMove;

    private float _timeBetweenMoveCounter; 

    private float _timeToMove;

    private float _timeToMoveCounter;

    private Vector3 _moveDirection;

    public float AttackDuration;

    public float AttackDurationCount;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();

        _anim = GetComponent<Animator>();

        _life = GetComponent<EnnemyLife>();

        _timeBetweenMoveCounter = UnityEngine.Random.Range(TimeBetweenMove * 0.75f, TimeBetweenMove * 1.25f);
    


	}

    // Update is called once per frame
    void Update() {
        if (AttackDurationCount <= 0)
        {
            if (_moving)
            {
                _timeToMoveCounter -= Time.deltaTime;
                _rigidbody.velocity = _moveDirection;
                AttackDurationCount = 0;

                if (_timeToMoveCounter < 0f)
                {
                    _moving = false;
                    _timeBetweenMoveCounter = UnityEngine.Random.Range(TimeBetweenMove * 0.75f, TimeBetweenMove * 1.25f);
                }

            }
            else
            {
                _timeBetweenMoveCounter -= Time.deltaTime;

                _rigidbody.velocity = Vector2.zero;

                if (_timeBetweenMoveCounter < 0f)
                {
                    MovesGenerator();

                }

            }
        }

        else
        {
            AttackDurationCount -= Time.deltaTime;
            if (AttackDuration <= 0)
            {
                AttackDurationCount = 0;
                _rigidbody.velocity = Vector2.zero;
            }
        }

        
    }

    private void MovesGenerator()
    {
        _timeToMoveCounter = _timeToMove;

        float currentMovementDirection = UnityEngine.Random.Range(-1f, 1f);

        if (currentMovementDirection < 0)
        {
            _moving = true;
            _moveDirection = new Vector3(UnityEngine.Random.Range(-1f, 1f) * MoveSpeed, 0f, 0f);
            _timeToMove = Math.Abs(_moveDirection.x);
            _timeToMoveCounter = _timeToMove;
        }
        else if (currentMovementDirection > 0)
        {
            _moving = true;
            _moveDirection = new Vector3(0f, UnityEngine.Random.Range(-1f, 1f) * MoveSpeed, 0f);
            _timeToMove = Math.Abs(_moveDirection.y);
            _timeToMoveCounter = _timeToMove;
        }

        _anim.SetFloat("MoveX", _moveDirection.x);
        _anim.SetFloat("MoveY", _moveDirection.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Link"))
        {
            collision.gameObject.GetComponent<PlayerManager>().Hit(1);
        }
        else if (collision.gameObject.tag == "PlayerWeapon")
        {
            Debug.Log("lol");
        }
        else
        {
            MovesGenerator();
        }
    }

    public void Damaged(int dmg, Vector2 vector)
    {
        _life.Damage(dmg);
        AttackDurationCount = AttackDuration;
        _rigidbody.velocity = vector;
    }
    
}
