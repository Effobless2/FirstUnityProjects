using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject FollowTarget;
    private Vector3 PosTarget;
    public float MoveSpeed;
    private static bool _cameraExists;

	// Use this for initialization
	void Start () {
		if (!_cameraExists)
        {
            _cameraExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        //PosTarget = new Vector3(FollowTarget.transform.position.x, FollowTarget.transform.position.y, transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, PosTarget, MoveSpeed * Time.deltaTime);
	}
}
