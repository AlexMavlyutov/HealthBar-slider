using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class ChangeSliderValue : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        Health.ChangeHealthPoints += OnChangeHealthPoints;
    }
    private void OnDisable()
    {
        Health.ChangeHealthPoints -= OnChangeHealthPoints;
    }

    private void OnChangeHealthPoints(float relativeHealth)
    {
        _slider.DOValue(relativeHealth, 1);
    }
}
