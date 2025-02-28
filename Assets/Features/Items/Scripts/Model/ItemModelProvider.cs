namespace TestBakedPixel.Items
{
    using System;
    using TestBakedPixel.Items.Model;
    using TestBakedPixel.Slots.Model;
    using UnityEngine;

    /// <summary>
    /// Провайдер предмета в слоте
    /// </summary>
    public class ItemModelProvider : MonoBehaviour
    {
        #region Events

        /// <summary>
        /// Изменён предмет в слоте
        /// </summary>
        public event Action onItemModelChanged = delegate { };

        #endregion

        #region Properties

        [SerializeField]
        private SlotModelProvider _slotModelProvider = default;

        /// <summary>
        /// Предмет в слоте
        /// </summary>
        public ItemModel ItemModel
        {
            get => _itemModel;
            protected set
            {
                if (value != ItemModel)
                {
                    _itemModel = value;
                    onItemModelChanged();
                }
            }
        }
        private ItemModel _itemModel = default;

        protected SlotModel SlotModel
        {
            get => _slotModel;
            set
            {
                if (value != SlotModel)
                {
                    if (SlotModel != null)
                    {
                        SlotModel.onItemChanged -= InitItemModel;
                    }

                    _slotModel = value;

                    if (SlotModel != null)
                    {
                        SlotModel.onItemChanged += InitItemModel;
                        InitItemModel();
                    }
                    else
                    {
                        ItemModel = null;
                    }
                }
            }
        }
        private SlotModel _slotModel = default;

        #endregion

        #region Methods

        protected virtual void Start()
        {
            _slotModelProvider.onSlotModelChanged += InitSlotModel;

            if (_slotModelProvider.SlotModel != null)
            {
                InitSlotModel();
            }
        }

        protected virtual void OnDestroy()
        {
            _slotModelProvider.onSlotModelChanged -= InitSlotModel;
            SlotModel = null;
        }

        protected virtual void InitSlotModel()
            => SlotModel = _slotModelProvider.SlotModel;

        protected virtual void InitItemModel()
            => ItemModel = SlotModel.Item;

        #endregion
    }
}
