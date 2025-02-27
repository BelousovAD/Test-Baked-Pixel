namespace TestBakedPixel.Data
{
    using TestBakedPixel.Common;
    using UnityEngine;

    /// <summary>
    /// Данные абстрактного предмета
    /// </summary>
    public abstract class AbstractItemData : ScriptableObject
    {
        #region Properties

        /// <summary>
        /// Идентификатор предмета
        /// </summary>
        public string ItemId => _itemId.Content;
        [SerializeField]
        private StringSO _itemId = default;

        /// <summary>
        /// Иконка предмета
        /// </summary>
        public Sprite ItemIcon => _itemIcon;
        [SerializeField, Min(1)]
        private Sprite _itemIcon = default;

        /// <summary>
        /// Максимальное количество предмета в стаке
        /// </summary>
        public int MaxStackCount => _maxStackCount;
        [SerializeField, Min(1)]
        private int _maxStackCount = 1;

        /// <summary>
        /// Вес единицы предмета
        /// </summary>
        public float UnitWeight => _unitWeight;
        [SerializeField, Min(0)]
        private float _unitWeight = 1f;

        #endregion
    }
}