namespace TestBakedPixel.Items.Model
{
    using System;
    using TestBakedPixel.Items.Data;
    using UnityEngine;

    /// <summary>
    /// Предмет в инвентаре
    /// </summary>
    public class ItemModel
    {
        #region Events

        /// <summary>
        /// Изменилось количество предмета в стеке
        /// </summary>
        public event Action onStackCountChanged = delegate { };

        #endregion

        #region Properties

        /// <summary>
        /// Идентификатор предмета
        /// </summary>
        public string ItemId => _itemData.ItemId;

        /// <summary>
        /// Иконка предмета
        /// </summary>
        public Sprite ItemIcon => _itemData.ItemIcon;

        /// <summary>
        /// Количество предмета в стеке
        /// </summary>
        public int StackCount
        {
            get => _stackCount;
            protected set
            {
                _stackCount = Mathf.Clamp(value, 0, _itemData.MaxStackCount);
                onStackCountChanged();
            }
        }
        private int _stackCount = 1;

        /// <summary>
        /// Данные предмета
        /// </summary>
        public AbstractItemData ItemData => _itemData;
        private AbstractItemData _itemData = default;

        #endregion

        #region Methods

        public ItemModel(AbstractItemData itemData, int stackCount = 1)
        {
            _itemData = itemData;
            StackCount = stackCount;
        }

        /// <summary>
        /// Пытается добавить количество предмета в стак
        /// </summary>
        /// <param name="count">Добавляемое количество</param>
        /// <returns>Количество предмета не вошедшее в стак</returns>
        public int TryAdd(int count)
        {
            int overflow = StackCount + count - _itemData.MaxStackCount;
            StackCount += count;
            return overflow;
        }

        /// <summary>
        /// Пытается удалить количество предмета из стака
        /// </summary>
        /// <param name="count">Удаляемое количество</param>
        /// <returns>Дефицит предмета</returns>
        public int TryRemove(int count)
        {
            int deficiency = count - StackCount;
            StackCount -= count;
            return deficiency > 0
                ? 0
                : deficiency;
        }

        #endregion
    }
}