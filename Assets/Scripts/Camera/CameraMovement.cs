using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset; 

    private void Update()
    {
        Vector3 position = transform.position;
        position.y = (_player.position + _offset).y;
        position.z = (_player.position + _offset).z;
        transform.position = position;
    }
}
