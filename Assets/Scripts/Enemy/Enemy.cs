using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _reward;
    [SerializeField] private Transform _target;
    [SerializeField] private Enemies _enemies;
    [SerializeField] private float _speedAttraction;
    [SerializeField] private Vector3 _scaleDecrease;
    [SerializeField] private float _speedScaleDecrease;

    public float Reward => _reward;

    private readonly string _levelKey = "Level";
    private readonly string _isDeadAnimation = "IsDead";

    private Animator _animator;

    private void Start()
    {
        if(gameObject.TryGetComponent<Animator>(out Animator animator) != false)
        {
            _animator = animator;
        }

        _enemies = GameObject.FindObjectOfType<Enemies>();
        _target = GameObject.FindObjectOfType<MouthEating>().transform;
        _reward *= PlayerPrefs.GetInt(_levelKey);
    }

    private void OnDisable()
    {
        StopCoroutine(MoveCoroutine());
    }

    public void MoveToMounth()
    {
        if (_animator != null)
        {
            _animator.SetBool(_isDeadAnimation, true);
        }

        StartCoroutine(MoveCoroutine());
        _enemies.EatEnemy();
    }

    private IEnumerator MoveCoroutine()
    {
        while (Vector3.Distance(transform.position, _target.position) > 0.2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * _speedAttraction);
            transform.localScale = Vector3.Lerp(transform.localScale, _scaleDecrease, _speedScaleDecrease);
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
