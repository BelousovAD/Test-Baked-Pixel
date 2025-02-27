namespace TestBakedPixel.Slots.Model
{
    using System;
    using TestBakedPixel.Items.Model;

    /// <summary>
    /// Слот в инвентаре
    /// </summary>
    public class SlotModel
    {
        #region Events

        /// <summary>
        /// Изменился статус блокировки слота
        /// </summary>
        public event Action onLockedStatusChanged = delegate { };

        /// <summary>
        /// Изменилась стоимость разблокировки слота
        /// </summary>
        public event Action onCostToUnlockChanged = delegate { };

        /// <summary>
        /// Изменился предмет в слоте
        /// </summary>
        public event Action onItemChanged = delegate { };

        #endregion

        #region Properties

        /// <summary>
        /// Заблокирован ли слот
        /// </summary>
        public bool IsLocked
        {
            get => _isLocked;
            protected set
            {
                if (value != _isLocked)
                {
                    _isLocked = value;
                    onLockedStatusChanged();
                }
            }
        }
        private bool _isLocked = false;

        /// <summary>
        /// Стоимость разблокировки слота
        /// </summary>
        public int CostToUnlock
        {
            get => _costToUnlock;
            protected set
            {
                if (value != _costToUnlock)
                {
                    _costToUnlock = value;
                    onCostToUnlockChanged();
                }
            }
        }
        private int _costToUnlock = 0;

        /// <summary>
        /// Предмет в слоте
        /// </summary>
        public ItemModel Item
        {
            get => _itemModel;
            set
            {
                if (value != _itemModel)
                {
                    _itemModel = value;
                    onItemChanged();
                }
            }
        }
        private ItemModel _itemModel = default;

        #endregion

        #region Methods

        public SlotModel(bool isLocked, int costToUnlock, ItemModel itemModel = null)
        {
            _isLocked = isLocked;
            _costToUnlock = costToUnlock;
            _itemModel = itemModel;
        }

        #endregion
    }
}