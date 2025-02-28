namespace TestBakedPixel.Slots.Controller
{
    using System.Collections.Generic;
    using TestBakedPixel.Inventory.Model;
    using TestBakedPixel.Slots.Model;
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
        protected SlotModelProvider prefabForSpawn = default;

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
        protected List<SlotModelProvider> spawnedItems = new List<SlotModelProvider>();
        protected IInstantiator instantiator = default;

        #endregion

        #region Methods

        [Inject]
        protected virtual void Construct(IInstantiator _instantiator, InventoryModel inventoryModel)
        {
            instantiator = _instantiator;
            InventoryModel = inventoryModel;
        }

        protected virtual void SpawnItems()
        {
            for (int i = 0; i < inventorySlotsCount; ++i)
            {
                SlotModelProvider slotModelProvider = instantiator.InstantiatePrefabForComponent<SlotModelProvider>(prefabForSpawn.gameObject, parentForSpawnedItems);
                spawnedItems.Add(slotModelProvider);
                spawnedItems[i].SlotModel = InventoryModel.SlotModels[i];
            }
        }

        #endregion
    }
}
