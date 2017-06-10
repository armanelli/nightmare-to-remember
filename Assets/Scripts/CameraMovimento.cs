using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovimento : MonoBehaviour
{
    public Transform _target;

    Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }
    
    void Update()
    {
        _camera.orthographicSize = (Screen.height / 100f) / 4f;

        if (_target)
        {
            transform.position = Vector3.Lerp(transform.position, _target.position + new Vector3(0, 0, -10), 0.1f);

        }

    }
}
