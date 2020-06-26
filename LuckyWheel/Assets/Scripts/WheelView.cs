using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelView : MonoBehaviour
{
    [Header("Количество секторов на колесе")]
    [SerializeField] private int _numberOfSectors;
    [Header("Вероятность каждого сектора")]
    [SerializeField] private float[] _probability;
    [Header("Объект с колесом фортуны")]
    [SerializeField] private GameObject _circle;
    [Header("Кнопка для запуска колеса")]
    [SerializeField] private Button _twistButton;
    private Wheel _wheel;

    private void Start()
    {
        _wheel = new Wheel(_numberOfSectors, _probability, _circle);
        _wheel.Init();
        _twistButton.onClick.RemoveAllListeners();
        _twistButton.onClick.AddListener(() => _wheel.Twist());

    }
    private void Update()
    {
        _wheel.SpinTheWheelOfFortune();
    }
}
