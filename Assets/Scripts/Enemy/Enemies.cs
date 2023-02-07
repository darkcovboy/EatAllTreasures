using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private int _maxEnemies;
    [SerializeField] private int _enemiesAte;
    [SerializeField] private Player _player; 

    public void EatEnemy()
    {
        _enemiesAte++;

        if (_enemiesAte > _maxEnemies)
        {
            _player.Win();
        }
    }
}
