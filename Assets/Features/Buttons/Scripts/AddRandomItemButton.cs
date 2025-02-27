namespace TestBakedPixel.Buttons
{
    using System.Collections.Generic;
    using TestBakedPixel.Inventory.Model;
    using TestBakedPixel.Items.Data;
    using TestBakedPixel.Items.Model;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Кнопка добавления случайного предмета
    /// </summary>
    public class AddRandomItemButton : AbstractButton
    {
        #region Properties

        [SerializeField]
        private List<AbstractItemData> itemDatas = new List<AbstractItemData>();

        private InventoryModel _inventoryModel = default;

        #endregion

        #region Methods

        [Inject]
        protected virtual void Construct(InventoryModel inventoryModel)
            => _inventoryModel = inventoryModel;

        protected override void OnClick()
        {
            AbstractItemData newItem = itemDatas[Random.Range(0, itemDatas.Count)];
            bool result = _inventoryModel.TryAddItem(new ItemModel(newItem, newItem.MaxStackCount));

            if (!result)
            {
                Debug.LogError("Невозможно добавить предмет: Отсутствует свободное место в инвентаре.");
            }
        }

        #endregion
    }
}
