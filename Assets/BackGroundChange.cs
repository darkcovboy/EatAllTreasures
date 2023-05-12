using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.WebUtility;

public class BackGroundChange : MonoBehaviour
{
    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += InBackgroundChange;
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= InBackgroundChange;
    }

    private void InBackgroundChange(bool isChanged)
    {
        if (isChanged)
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
    }
}
