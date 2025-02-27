namespace TestBakedPixel.Items.Model
{
    using TestBakedPixel.Items.Data;

    /// <summary>
    /// Предмет в инвентаре
    /// </summary>
    public class ItemModel
    {
        #region Properties

        /// <summary>
        /// Количество предмета в стеке
        /// </summary>
        public int StackCount => _stackCount;
        private int _stackCount = 1;

        private AbstractItemData _itemData = default;

        #endregion

        #region Methods

        public ItemModel(AbstractItemData itemData, int stackCount = 1)
        {
            _itemData = itemData;
            _stackCount = stackCount;
        }

        #endregion
    }
}