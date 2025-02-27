namespace TestBakedPixel.Slots.View
{
    using TestBakedPixel.GameObjects;
    using TestBakedPixel.Items.View;
    using TestBakedPixel.Slots.Model;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Отображение слота в инвентаре
    /// </summary>
    public class SlotView : ObjectSwitcher
    {
        #region Properties

        /// <summary>
        /// Слот в инвентаре
        /// </summary>
        public SlotModel SlotModel
        {
            protected get => _slotModel;
            set
            {
                if (SlotModel != null)
                {
                    SlotModel.onItemChanged -= UpdateItemView;
                    SlotModel.onCostToUnlockChanged -= UpdateView;
                    SlotModel.onLockedStatusChanged -= UpdateView;
                }

                _slotModel = value;

                if (SlotModel != null)
                {
                    SlotModel.onLockedStatusChanged += UpdateView;
                    SlotModel.onCostToUnlockChanged += UpdateView;
                    SlotModel.onItemChanged += UpdateItemView;
                    UpdateItemView();
                    UpdateView();
                }
            }
        }
        private SlotModel _slotModel = default;

        [SerializeField]
        private ItemView _itemView = default;
        [SerializeField]
        private Text _costToUnlockField = default; 

        #endregion

        #region Methods

        protected virtual void OnDestroy()
            => SlotModel = null;

        protected virtual void UpdateView()
        {
            if (isActiveAndEnabled)
            {
                _costToUnlockField.text = SlotModel.CostToUnlock.ToString();
                SwitchObjects(SlotModel.IsLocked);
            }
        }

        protected virtual void UpdateItemView()
        {
            if (isActiveAndEnabled)
            {
                _itemView.ItemModel = SlotModel.Item;
            }
        }

        #endregion
    }
}
