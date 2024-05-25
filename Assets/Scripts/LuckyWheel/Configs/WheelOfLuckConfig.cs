using LuckyWheel.Configs;
using UnityEngine;

namespace SpinTheWheelTest.Configs
{
    [CreateAssetMenu(fileName = "WheelConfig", menuName = "Configs/WheelConfig")]
    public class WheelOfLuckConfig : ScriptableObject
    {
        [field:SerializeField] public LuckyWheelItemData[] PossibleItemIDs { get; set; }
        [field:SerializeField] public string[] FirstRollsItems { get; set; }
        
        [field:SerializeField] public int SectorsOnWheel { get; set; }
        [field:SerializeField] public int ConsumablesCount { get; set; }
        [field:SerializeField] public int NonConsumablesCount { get; set; }
    }
}