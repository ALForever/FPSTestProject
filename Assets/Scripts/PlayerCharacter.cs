using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public delegate void PlayerHealthHandler(float valueNormalized);
    public event PlayerHealthHandler OnPlayerHealthValueChangedEvent;

    [SerializeField] private int healthDefault = 5;    
    public int health { get; private set; }
    public float healthNormalized => (float) health / healthDefault;
    

    private void Awake()
    {
        health = healthDefault;
        OnPlayerHealthValueChangedEvent?.Invoke(healthNormalized);
    }

    public void Hurt(int damage)
    {
        health -= damage;
        OnPlayerHealthValueChangedEvent?.Invoke(healthNormalized);
        Debug.Log(health);
    }
}
