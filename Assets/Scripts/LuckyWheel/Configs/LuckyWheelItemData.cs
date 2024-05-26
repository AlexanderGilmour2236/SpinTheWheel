using System;
using UnityEngine;

namespace LuckyWheel.Configs
{
    [CreateAssetMenu(fileName = "LuckyWheelItemData", menuName = "Configs/LuckyWheelItemData")]
    public class LuckyWheelItemData : ScriptableObject, ILuckyWheelItemData
    {
        [field:SerializeField] public string ItemID { get; private set; }
        
        [field:SerializeField] public int Probability { get; private set; }
        [field:SerializeField] public int ProbabilityOnWheel { get; private set; }
        [field:SerializeField] public bool Consumable { get; private set; }
    }
}