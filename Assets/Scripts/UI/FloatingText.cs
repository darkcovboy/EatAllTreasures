using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleDecrease;
    [SerializeField] private float _speedScaleDecrease;

    private void OnEnable()
    {
        StartCoroutine(OnScaleDecrease());
    }
    private void OnDisable()
    {
        StopCoroutine(OnScaleDecrease());
    }

    private IEnumerator OnScaleDecrease()
    {
        gameObject.transform.localScale = Vector3.one;

        while(transform.localScale != _scaleDecrease)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _scaleDecrease, _speedScaleDecrease);
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
