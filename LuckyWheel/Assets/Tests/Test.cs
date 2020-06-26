using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Test
    {
        private List<int> _winNumbers = new List<int>();
        private static float[] probability = new float[] { 10, 8, 5, 3, 2,1 , 0.5f, 0.001f };
        private static GameObject _circle = null;
        private Wheel _wheel = new Wheel(8, probability, _circle);
        private double[] _statistics = new double[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
        double _overallProbability = 0;
        [Test]
        public void TestSimplePasses()
        {
            _winNumbers.Clear();
            _wheel.Init();
            _overallProbability = 0;
            for (int i = 0; i < 1000; i++)
            {
                _winNumbers.Add(_wheel.CalculationProbabilityWin());
            }
            foreach(int number in _winNumbers)
            {
                switch (number)
                {
                    case 0:
                        _statistics[0]++;
                        break;
                    case 1:
                        _statistics[1]++;
                        break;
                    case 2:
                        _statistics[2]++;
                        break;
                    case 3:
                        _statistics[3]++;
                        break;
                    case 4:
                        _statistics[4]++;
                        break;
                    case 5:
                        _statistics[5]++;
                        break;
                    case 6:
                        _statistics[6]++;
                        break;
                    case 7:
                        _statistics[7]++;
                        break;
                }
            }
            for (int i = 0; i < _statistics.Length; i++)
            {
                ShowStatistics(i);
            }
            Debug.Log("Общая вероятность выпадения " + _overallProbability);
        }


        private void ShowStatistics(int index)
        {
            Debug.Log("На 1000 оборотов колеса поле " + (index + 1) + " выпало " + _statistics[index]);
            Debug.Log("Процентное выпадение числа " + (index + 1) + " равно " + (_statistics[index] / 1000));
            _overallProbability += _statistics[index] / 1000;
        }
    }
}
 