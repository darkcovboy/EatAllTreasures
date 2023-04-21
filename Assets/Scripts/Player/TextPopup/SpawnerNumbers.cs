using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerNumbers : ObjectPool
{
    [SerializeField] private GameObject _textPopupPrefab;

    private void Start()
    {
        Initialize(_textPopupPrefab);
    }

    public void ShowTextPopup(int reward)
    {
        if (TryGetObject(out GameObject text))
        {
            text.SetActive(true);
            text.GetComponent<TextMeshPro>().text = reward.ToString();
            text.transform.position = transform.position;
        }
    }
}
