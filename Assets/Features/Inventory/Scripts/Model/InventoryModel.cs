namespace TestBakedPixel.Inventory.Model
{
    using System.Collections.Generic;
    using TestBakedPixel.Inventory.Data;
    using TestBakedPixel.Slots.Data;
    using TestBakedPixel.Slots.Model;

    /// <summary>
    /// Инвентарь
    /// </summary>
    public class InventoryModel
    {
        #region Properties

        /// <summary>
        /// Список слотов
        /// </summary>
        public List<SlotModel> SlotModels { get; } = default;

        #endregion

        #region Methods

        public InventoryModel(InventoryData inventoryData)
        {
            List<SlotData> slotDatas = inventoryData.DefaultSlotDatas;

            SlotModels = new List<SlotModel>(inventoryData.DefaultSlotDatas.Count);

            for (int i = 0; i < inventoryData.DefaultSlotDatas.Count; ++i)
            {
                SlotModels.Add(new SlotModel(slotDatas[i].IsLocked, slotDatas[i].CostToUnlock));
            }
        }

        #endregion
    }
}