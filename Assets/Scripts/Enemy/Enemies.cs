using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    
    [SerializeField] private int _maxEnemies;
    [SerializeField] private int _enemiesAte;
    [SerializeField] private float _percentOfEnemiesToEat;
    [SerializeField] private Player _player;
    [SerializeField] private List<List<Transform>> _phazes = new List<List<Transform>>();
    [SerializeField] private List<Transform> _phaze1;
    [SerializeField] private List<Transform> _phaze2;
    [SerializeField] private List<Transform> _phaze3;
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private bool _haveSpawnObjectRandomly;

    private void Start()
    {
        if (_phaze1.Count > 0)
        {
            _phazes.Add(_phaze1);
        }

        if (_phaze2.Count > 0)
        {
            _phazes.Add(_phaze2);
        }

        if (_phaze3.Count > 0)
        {
            _phazes.Add(_phaze3);
        }


        if (_haveSpawnObjectRandomly)
        {
            RandomSpawnObjects();
        }
        else
        {
            SubsequentSpawnObjects();
        }

        _maxEnemies = Mathf.RoundToInt(_maxEnemies * _percentOfEnemiesToEat);
    }

    public void EatEnemy()
    {
        _enemiesAte++;

        if (_enemiesAte >= _maxEnemies)
        {
            _player.Win();
        }
    }

    private void RandomSpawnObjects()
    {
        foreach (var phaze in _phazes)
        {
            int option = Random.Range(0, phaze.Count);
            phaze[option].gameObject.SetActive(true);

            for (int i = 0; i < phaze[option].childCount; i++)
            {
                int enemyPrefabIndex = Random.Range(0, _enemyPrefabs.Count);
                GameObject gameObject = _enemyPrefabs[enemyPrefabIndex];
                Instantiate(gameObject, phaze[option].GetChild(i).gameObject.transform.position, gameObject.transform.rotation);
                _maxEnemies++;
            }
        }
    }

    private void SubsequentSpawnObjects()
    {
        foreach (var phaze in _phazes)
        {
            int option = Random.Range(0, phaze.Count);
            int enemyPrefabIndex = Random.Range(0, _enemyPrefabs.Count);
            GameObject gameObject = _enemyPrefabs[enemyPrefabIndex];
            phaze[option].gameObject.SetActive(true);

            for (int i = 0; i < phaze[option].childCount; i++)
            {
                Instantiate(gameObject, phaze[option].GetChild(i).gameObject.transform.position, gameObject.transform.rotation);
                _maxEnemies++;
            }
        }
    }
}
