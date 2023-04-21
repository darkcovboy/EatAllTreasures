using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueMovementKeybord : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private Player _player;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _characterController.Move(move * Time.deltaTime * _player.Speed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }
}
