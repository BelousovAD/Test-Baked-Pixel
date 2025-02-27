namespace TestBakedPixel.Inventory.Data
{
    using System.Collections.Generic;
    using TestBakedPixel.Slots.Data;
    using UnityEngine;

    /// <summary>
    /// Данные инвентаря
    /// </summary>
    [CreateAssetMenu(fileName = nameof(InventoryData), menuName = "TestBakedPixel/Features/Inventory/Data/New " + nameof(InventoryData))]
    public class InventoryData : ScriptableObject
    {
        #region Properties

        /// <summary>
        /// Список данных слотов по умолчанию
        /// </summary>
        public List<SlotData> DefaultSlotDatas => _defaultSlotDatas;
        [SerializeField]
        private List<SlotData> _defaultSlotDatas = new List<SlotData>();

        #endregion
    }
}
