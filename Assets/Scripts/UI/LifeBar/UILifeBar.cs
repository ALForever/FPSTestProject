using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILifeBar : MonoBehaviour
{
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private PlayerCharacter playerHealth;

    private void OnEnable()
    {      
        playerHealth.OnPlayerHealthValueChangedEvent += OnPlayerHealthValueChanged;
    }
    private void OnPlayerHealthValueChanged(float newValueNormalized)
    {
        progressBar.SetValue(newValueNormalized);
    }

    private void OnDisable()
    {        
        if (playerHealth)
            playerHealth.OnPlayerHealthValueChangedEvent -= OnPlayerHealthValueChanged;
    }
}
