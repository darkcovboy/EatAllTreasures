using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectsToClose;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _moneyEarnedText;

    private void OnEnable()
    {
        foreach (var obj in _objectsToClose)
        {
            obj.SetActive(false);
        }

        Debug.Log(_player.StartMoney + " " + _player.EndMoney);
        StartCoroutine(FillMoney(_player.EndMoney));
    }

    private IEnumerator FillMoney(int end)
    {
        for(int i= 0; i <= end; i++ )
        {
            _moneyEarnedText.text = i.ToString();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
