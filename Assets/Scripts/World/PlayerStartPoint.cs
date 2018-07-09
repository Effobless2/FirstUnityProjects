using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStartPoint : MonoBehaviour {

    private PlayerController _playerController;

    public Vector2 StartDirection;

    public string LastScene;

    public bool IsForCavern;


	// Use this for initialization
	void Start () {
        _playerController = FindObjectOfType<PlayerController>();

        if (_playerController.CurrentScene.Equals(LastScene))
        {
            if (IsForCavern)
            {
                _playerController.transform.position = transform.position;
            }
            else
            {
                if (StartDirection.x != 0)
                {
                    _playerController.transform.position = new Vector3(transform.position.x, _playerController.transform.position.y, _playerController.transform.position.z);
                }
                else
                {
                    _playerController.transform.position = new Vector3(_playerController.transform.position.x, transform.position.y, _playerController.transform.position.z);
                }
            }
            _playerController.LastMove = StartDirection;
            _playerController.CurrentScene = SceneManager.GetActiveScene().name;
        }
        


        //_camera = FindObjectOfType<CameraController>();
        //_camera.transform.position = new Vector3(transform.position.x, transform.position.y, _camera.transform.position.z);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
