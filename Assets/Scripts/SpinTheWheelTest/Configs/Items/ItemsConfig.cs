using System.Collections.Generic;
using UnityEngine;

namespace SpinTheWheelTest.Configs
{
    [CreateAssetMenu(fileName = "ItemsConfig", menuName = "Configs/ItemsConfig")]
    public class ItemsConfig : ScriptableObject
    {
        public List<ItemConfig> Items;

        private Dictionary<string, ItemConfig> _idToItemConfig;

        public ItemConfig GetItemByID(string id)
        {
            if (_idToItemConfig == null)
            {
                CreateItemsDictionary();
            }

            return _idToItemConfig[id];
        }

        private void CreateItemsDictionary()
        {
            _idToItemConfig = new Dictionary<string, ItemConfig>();
            foreach (ItemConfig currencyItemConfig in Items)
            {
                _idToItemConfig[currencyItemConfig.ItemID] = currencyItemConfig;
            }
        }
    }
}