namespace TestBakedPixel.Items.View
{
    using TestBakedPixel.Items.Model;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Отображение предмета в инвентаре
    /// </summary>
    public class ItemView : MonoBehaviour
    {
        #region Properties

        [SerializeField]
        private Image _image = default;
        [SerializeField]
        private Text _itemCountField = default;

        /// <summary>
        /// Предмет в инвентаре
        /// </summary>
        public ItemModel ItemModel
        {
            protected get => _itemModel;
            set
            {
                if (value != ItemModel)
                {
                    if (ItemModel != null)
                    {
                        _itemModel.onStackCountChanged -= UpdateView;
                    }

                    _itemModel = value;

                    if (ItemModel != null)
                    {
                        ItemModel.onStackCountChanged += UpdateView;
                    }
                    
                    UpdateView();
                }
            }
        }
        private ItemModel _itemModel = default;

        #endregion

        #region Methods

        protected virtual void OnEnable()
            => UpdateView();

        protected virtual void OnDestroy()
            => ItemModel = null;

        protected virtual void UpdateView()
        {
            if (isActiveAndEnabled)
            {
                _image.sprite = ItemModel != null
                    ? ItemModel.ItemIcon
                    : null;
                _itemCountField.text = ItemModel != null && ItemModel.StackCount > 1
                    ? ItemModel.StackCount.ToString()
                    : string.Empty;
            }
            
            _image.gameObject.SetActive(ItemModel != null);
        }

        #endregion
    }
}
