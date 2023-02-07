using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueMovement : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private Player _player;
    [SerializeField] private FloatingJoystick _floatingJoystick;
    
    private CharacterController _characterController;
    private Vector3 _lastPosition;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _player.DistanceChanged += OnDistanceChange;
    }

    private void Update()
    {
        //Vector3 move = new Vector3(_floatingJoystick.Horizontal, 0, _floatingJoystick.Vertical);
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        var heading = _targetTransform.position - transform.position;
        _characterController.Move(move * Time.deltaTime * _player.Speed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }

    private void OnDistanceChange(float distance)
    {
        Vector3 positionDistanceLimit = _targetTransform.position;
        positionDistanceLimit.z = -distance;
        _targetTransform.position = positionDistanceLimit;
    }
}
