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

    private float _currentHealth;
    private int _minimumHealth = 0;
    private int _demage = 10;
    private int _healthBonus = 10;

    private void Awake()
    {
        _currentHealth = _startingHealth;
    }

    public void TakeDemage()
    {
        _currentHealth = Mathf.Clamp(_currentHealth - _demage, _minimumHealth, _startingHealth);

        ChangeHealthPoints?.Invoke(RelativeHealth());
    }

    public void RecoverHealth()
    {
        _currentHealth = Mathf.Clamp(_currentHealth + _healthBonus, _minimumHealth, _startingHealth);

        ChangeHealthPoints?.Invoke(RelativeHealth());
    }

    private float RelativeHealth()
    {
        float _relativeHealth = _currentHealth / _startingHealth;
        return _relativeHealth;
    }
}
