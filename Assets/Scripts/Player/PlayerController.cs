using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public string CurrentScene;

    public int moveSpeed;

    private Animator _anim;

    private bool _playerMoving;

    public Vector2 LastMove;

    private Rigidbody2D _rigidbody;

    private static bool _playerExists;

    private float _timeForDeath;

    private float _timeForDeathCount;

    private PlayerManager _playerManager;

    private AttackTrigger _attackTrigger;
    

	// Use this for initialization
	void Start () {
        _anim = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _playerManager = GetComponent<PlayerManager>();

        _timeForDeath = 3f;
        _timeForDeathCount = _timeForDeath;
        
        _attackTrigger = GetComponentInChildren<AttackTrigger>();
        
        if (!_playerExists)
        {
            _playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        if (!_anim.GetBool("Killed") && !_anim.GetBool("Attack"))
        {
            _playerMoving = false;

            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                _playerMoving = true;

                _rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, _rigidbody.velocity.y);

                LastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                _playerMoving = true;

                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);

                LastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            if (!(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f))
            {
                _rigidbody.velocity = new Vector2(0f, _rigidbody.velocity.y);
            }


            if (!(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f))
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0f);
            }

            _anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            _anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            _anim.SetBool("PlayerMoving", _playerMoving);
        }

        else if(_anim.GetBool("Killed"))
        {
            _timeForDeathCount -= Time.deltaTime;
            if (_timeForDeathCount <= 0)
            {
                CurrentScene = "None";
                _timeForDeathCount = _timeForDeath;
                SceneManager.LoadScene("H8");
                _playerManager.Recover();
                _anim.SetBool("Killed", false);
                _rigidbody.bodyType = RigidbodyType2D.Dynamic;
                LastMove = new Vector2(0, -1);

            }
        }
        _anim.SetFloat("LastMoveX", LastMove.x);
        _anim.SetFloat("LastMoveY", LastMove.y);


    }

    public void Kill()
    {
        _rigidbody.bodyType = RigidbodyType2D.Static;
        _anim.SetBool("Killed", true);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ennemy"))
        {
            Debug.Log("Touched by an Ennemy");
        }
    }

}
