namespace TestBakedPixel.Inventory.Controller
{
    using System;
    using TestBakedPixel.Inventory.Data;
    using TestBakedPixel.Inventory.Model;
    using UnityEngine;

    /// <summary>
    /// Инициализатор инвентаря
    /// </summary>
    public class InventoryModelInitializer : MonoBehaviour
    {
        #region Events

        /// <summary>
        /// Инвентарь инициализирован
        /// </summary>
        public event Action onInventoryModelInited = delegate { };

        #endregion

        #region Properties

        [SerializeField]
        private InventoryData _inventoryData = default;

        /// <summary>
        /// Модель сетчатого инвентаря
        /// </summary>
        public InventoryModel InventoryModel
        {
            get => _inventoryModel;
            protected set
            {
                if (_inventoryModel == null)
                {
                    _inventoryModel = value;
                    onInventoryModelInited();
                }
            }
        }
        private InventoryModel _inventoryModel = default;

        #endregion

        #region Methods

        protected virtual void Awake()
            => InventoryModel = new InventoryModel(_inventoryData);

        #endregion
    }
}
