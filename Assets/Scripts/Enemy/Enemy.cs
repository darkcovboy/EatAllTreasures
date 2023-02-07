using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _reward;
    [SerializeField] private Transform _target;
    [SerializeField] private float _duration;
    [SerializeField] private Enemies _enemies;
    [SerializeField] private Vector3 _scaleDecrease;

    public float Reward => _reward;

    public void MoveToMounth()
    {
        transform.DOMove(_target.position,_duration);
        transform.DOScale(_scaleDecrease, _duration);
        _enemies.EatEnemy();
        Destroy(gameObject, _duration);
    }
}
