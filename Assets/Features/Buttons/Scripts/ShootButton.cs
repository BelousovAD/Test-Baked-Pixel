namespace TestBakedPixel.Buttons
{
    using System.Collections.Generic;
    using TestBakedPixel.Inventory.Model;
    using TestBakedPixel.Items.Data;
    using TestBakedPixel.Items.Model;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Кнопка выстрела
    /// </summary>
    public class ShootButton : AbstractButton
    {
        #region Properties

        private InventoryModel _inventoryModel = default;

        #endregion

        #region Methods

        [Inject]
        protected virtual void Construct(InventoryModel inventoryModel)
            => _inventoryModel = inventoryModel;

        protected override void OnClick()
        {
            bool result = _inventoryModel.TryShootRandomAmmo();

            if (!result)
            {
                Debug.LogError("Невозможно выстрелить: Патроны закончились.");
            }
        }

        #endregion
    }
}
