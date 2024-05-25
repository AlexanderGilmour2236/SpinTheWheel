using System;
using UnityEngine;

namespace LuckyWheel.Configs
{
    [Serializable]
    public class PredefinedLuckyWheelConfig
    {
        [field:SerializeField] public LuckyWheelItemData[] LuckyWheelItemData { get; private set; }
        [field:SerializeField] public LuckyWheelItemData RewardItem { get; private set; }
    }
}