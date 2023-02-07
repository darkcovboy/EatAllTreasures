using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouthEating : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            _player.AddMoney(enemy.Reward);
            enemy.MoveToMounth();
        }
    }
}
