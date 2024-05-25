using System;
using System.Collections.Generic;
using SpinTheWheelTest.Services;
using UnityEngine;

namespace SpinTheWheelTest.Configs
{
    public abstract class ItemConfig : ScriptableObject
    {
        public string ItemID;
        public abstract void ApplyItem(IItemsService itemsService);
    }
}