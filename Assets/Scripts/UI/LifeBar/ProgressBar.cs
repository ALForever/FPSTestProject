using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image imageFiller;
    [SerializeField] private Text textValue;

    public void SetValue(float valueNormalized)
    {
        imageFiller.fillAmount = valueNormalized;

        var valueInPercent = Mathf.RoundToInt(valueNormalized * 100f);
        textValue.text = $"{valueInPercent}%";

    }
}
