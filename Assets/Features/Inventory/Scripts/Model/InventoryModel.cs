namespace TestBakedPixel.Inventory.Model
{
    using System.Collections.Generic;
    using TestBakedPixel.Inventory.Data;
    using TestBakedPixel.Items.Data;
    using TestBakedPixel.Items.Model;
    using TestBakedPixel.Slots.Data;
    using TestBakedPixel.Slots.Model;
    using UnityEngine;

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

        /// <summary>
        /// Пытается добавить предмет
        /// </summary>
        /// <param name="itemModel">Добавляемый предмет</param>
        /// <returns>Результат попытки добавления предмета</returns>
        public bool TryAddItem(ItemModel itemModel)
        {
            SlotModel emptySlot = GetFirstEmptySlot();

            if (emptySlot != null)
            {
                emptySlot.Item = itemModel;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Пытается удалить случайный предмет
        /// </summary>
        /// <returns>Результат попытки удаления предмета</returns>
        public bool TryRemoveRandomItem()
        {
            List<SlotModel> occupiedSlots = GetAllOccupiedSlots();

            if (occupiedSlots.Count > 0)
            {
                SlotModel slot = occupiedSlots[Random.Range(0, occupiedSlots.Count)];
                slot.Item = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Пытается выстрелить случайным патроном
        /// </summary>
        /// <returns>Результат попытки выстрела</returns>
        public bool TryShootRandomAmmo()
        {
            List<SlotModel> ammoSlots = GetAllAmmoSlots();

            if (ammoSlots.Count > 0)
            {
                SlotModel slot = ammoSlots[Random.Range(0, ammoSlots.Count)];
                if (slot.Item.TryRemove(1) == 0)
                {
                    slot.Item = null;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Объединить слоты
        /// </summary>
        /// <param name="from">Исходный слот</param>
        /// <param name="to">Целевой слот</param>
        public void StackSlots(SlotModel from, SlotModel to)
        {
            if (to.Item == null)
            {
                to.Item = from.Item;
                from.Item = null;
            }
            else if (from.Item.ItemId == to.Item.ItemId)
            {
                int overflow = to.Item.TryAdd(from.Item.StackCount);

                if (overflow == 0)
                {
                    from.Item = null;
                }
                else
                {
                    from.Item.TryRemove(from.Item.StackCount - overflow);
                }
            }
        }

        protected SlotModel GetFirstEmptySlot()
            => SlotModels.Find(x => !x.IsLocked && x.Item == null);

        protected List<SlotModel> GetAllOccupiedSlots()
            => SlotModels.FindAll(x => !x.IsLocked && x.Item != null);

        protected List<SlotModel> GetAllAmmoSlots()
            => SlotModels.FindAll(x => x.Item?.ItemData is AmmoData);

        #endregion
    }
}