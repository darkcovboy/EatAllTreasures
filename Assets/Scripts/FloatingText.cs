using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private float _destroyTime;
    [SerializeField] private Vector3 _scaleDecrease;

    private void Start()
    {
        Destroy(gameObject, _destroyTime);
        transform.DOScale(_scaleDecrease, _destroyTime);
    }
}
