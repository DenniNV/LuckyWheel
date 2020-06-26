using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector
{
    private int _rewardNumber;
    public int RewardNumber => _rewardNumber;
    private float _angelSector;
    public float AngelSector => _angelSector;
    private float _probabilityOfReward;
    public float Probability => _probabilityOfReward;
    public Sector(int rewardNumber, float angelSector , float probabilityOfReward)
    {
        _rewardNumber = rewardNumber;
        _angelSector = angelSector;
        _probabilityOfReward = probabilityOfReward;
    }
}
