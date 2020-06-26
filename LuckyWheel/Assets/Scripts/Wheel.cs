using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel 
{
    private int _numberOfSectors;
    private float _sectorSize;
    private bool _isStarted;
    private float _finalAngle;
    private float _startAngle = 0;
    private float _currentLerpRotationTime;
    private Sector[] _sectors;
    private float[] _probability;
    private GameObject _circle;

    public Wheel(int numberOfSectors , float[] probability , GameObject circle)
    {
        _numberOfSectors = numberOfSectors;
        _probability = probability;
        _circle = circle;
    }
    
    public void Init()
    {
        _sectorSize = 360 / _numberOfSectors;
        _sectors = new Sector[_numberOfSectors];
        for (int i = 0; i < _numberOfSectors; i++)
        {
            _sectors[i] = new Sector(i + 1, _sectorSize * i, _probability[i]);
        }
    }
    public void Twist()
    {
        _currentLerpRotationTime = 0f;
        int fullCircles = 13;
        float randomFinalAngle = _sectors[CalculationProbabilityWin()].AngelSector;
        _finalAngle = (fullCircles * 360 + randomFinalAngle);
        _isStarted = true;
    }
    public int CalculationProbabilityWin()
    {
        float total = 0;
        foreach (Sector elem in _sectors)
        {
            total += elem.Probability;
        }
        float randomPoint = Random.value * total;
        for (int i = 0; i < _sectors.Length; i++)
        {
            if (randomPoint < _sectors[i].Probability)
            {
                return i;
            }
            else
            {
                randomPoint -= _sectors[i].Probability;
            }
        }
        return _sectors.Length - 1;
    }
    public void GiveAwardByAngle()
    {
        foreach (Sector sector in _sectors)
        {
            if (sector.AngelSector == _startAngle)
            {
                Debug.Log("Вы выиграли " + sector.RewardNumber);
            }
        }
    }
    public void SpinTheWheelOfFortune()
    {
        if (!_isStarted)
            return;
        SpinWheel();
    }
    private void SpinWheel()
    {
        float maxLerpRotationTime = 5f;
        _currentLerpRotationTime += Time.deltaTime;
        if (_currentLerpRotationTime > maxLerpRotationTime || _circle.transform.eulerAngles.z == _finalAngle)
        {
            _currentLerpRotationTime = maxLerpRotationTime;
            _isStarted = false;
            _startAngle = _finalAngle % 360;
            GiveAwardByAngle();
        }
        float t = _currentLerpRotationTime / maxLerpRotationTime;
        t = t * t * t * (t * (6f * t - 15f) + 10f);
        float angle = Mathf.Lerp(_startAngle, _finalAngle, t);
        _circle.transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
