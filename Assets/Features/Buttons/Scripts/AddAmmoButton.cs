namespace TestBakedPixel.Buttons
{
    using System.Collections.Generic;
    using TestBakedPixel.Inventory.Model;
    using TestBakedPixel.Items.Data;
    using TestBakedPixel.Items.Model;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Кнопка добавления патронов
    /// </summary>
    public class AddAmmoButton : AbstractButton
    {
        #region Properties

        [SerializeField]
        private List<AmmoData> ammoDatas = new List<AmmoData>();

        private InventoryModel _inventoryModel = default;

        #endregion

        #region Methods

        [Inject]
        protected virtual void Construct(InventoryModel inventoryModel)
            => _inventoryModel = inventoryModel;

        protected override void OnClick()
        {
            bool result = true;

            foreach (AmmoData ammoData in ammoDatas)
            {
                result = _inventoryModel.TryAddItem(new ItemModel(ammoData, ammoData.MaxStackCount));

                if (!result)
                {
                    Debug.LogError("Невозможно добавить предмет: Отсутствует свободное место в инвентаре.");
                    break;
                }
            }
        }

        #endregion
    }
}
