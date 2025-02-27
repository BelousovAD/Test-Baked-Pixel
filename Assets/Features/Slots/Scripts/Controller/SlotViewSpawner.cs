namespace TestBakedPixel.Slots.Controller
{
    using System.Collections.Generic;
    using TestBakedPixel.Inventory.Model;
    using TestBakedPixel.Slots.View;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Спавнер отображений слотов в инвентаре
    /// </summary>
    public class SlotViewSpawner : MonoBehaviour
    {
        #region Properties

        [SerializeField]
        protected RectTransform parentForSpawnedItems = default;

        [SerializeField]
        protected SlotView prefabForSpawn = default;

        /// <summary>
        /// Инвентарь
        /// </summary>
        public InventoryModel InventoryModel
        {
            get => _inventoryModel;
            set
            {
                _inventoryModel = value;
                inventorySlotsCount = _inventoryModel.SlotModels.Count;
                SpawnItems();
            }
        }
        private InventoryModel _inventoryModel = default;

        protected int inventorySlotsCount = 1;
        protected List<SlotView> spawnedItems = new List<SlotView>();

        #endregion

        #region Methods

        [Inject]
        protected virtual void Construct(InventoryModel inventoryModel)
            => InventoryModel = inventoryModel;

        protected virtual void SpawnItems()
        {
            for (int i = 0; i < inventorySlotsCount; ++i)
            {
                GameObject slotViewGO = Instantiate(prefabForSpawn.gameObject, parentForSpawnedItems);
                spawnedItems.Add(slotViewGO.GetComponent<SlotView>());
                spawnedItems[i].SlotModel = InventoryModel.SlotModels[i];
            }
        }

        #endregion
    }
}
