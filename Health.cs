using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public static event UnityAction<float> ChangeHealthPoints;

    [Header("Health")]
    [SerializeField] private float _startingHealth;

    [Header("Hitframes")]
    [SerializeField] private float _framesFuration;
    [SerializeField] private float _numberOfFlashes;

    public float currentHealth { get; private set; }
    private int _minimumHealth = 0;
    private int _demage = 10;
    private int _healthBonus = 10;



    private void Awake()
    {
        currentHealth = _startingHealth;
    }

    public void OnTakeDemage()
    {
        currentHealth = Mathf.Clamp(currentHealth - _demage, _minimumHealth, _startingHealth);

        float _relativeHealth = currentHealth / _startingHealth;

        ChangeHealthPoints?.Invoke(_relativeHealth);

        Debug.Log(currentHealth);
    }

    public void RecoverHealth()
    {
        currentHealth = Mathf.Clamp(currentHealth + _healthBonus, _minimumHealth, _startingHealth);

        float _relativeHealth = currentHealth / _startingHealth;

        ChangeHealthPoints?.Invoke(_relativeHealth);
    }
}
