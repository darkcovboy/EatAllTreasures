using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _body;
    [SerializeField] private Vector3 _offset;

    private Vector3 _endLevelPosition = new Vector3(-2, 12, -15);
    private bool _isEndOfLevel = false;

    public void WinCameraTransform()
    {
        _isEndOfLevel = true;
        transform.LookAt(_body);
        _offset = _endLevelPosition;
    }

    private void LateUpdate()
    {
        if (!_isEndOfLevel)
        {
            Vector3 position = transform.position;
            position.x = (_player.position + _offset).x;
            position.y = (_player.position + _offset).y;
            position.z = (_player.position + _offset).z;
            transform.position = position;
        }
    }
}
