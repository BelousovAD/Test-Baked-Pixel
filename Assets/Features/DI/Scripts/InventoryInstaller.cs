namespace TestBakedPixel.DI
{
    using TestBakedPixel.Inventory.Data;
    using TestBakedPixel.Inventory.Model;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Установщик инвентаря
    /// </summary>
    public class InventoryInstaller : MonoInstaller
    {
        #region Properties

        [SerializeField]
        private InventoryData _inventoryData = default;

        #endregion

        #region Methods

        /// <summary>
        /// Устанавливает привязки
        /// </summary>
        public override void InstallBindings()
        {
            Container.Bind<InventoryModel>()
                .AsSingle()
                .WithArguments(_inventoryData);
        }

        #endregion
    }
}
