namespace TestBakedPixel.Slots.Model
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Провайдер слота в инвентаре
    /// </summary>
    public class SlotModelProvider : MonoBehaviour
    {
        #region Events

        /// <summary>
        /// Изменена ссылка на слот
        /// </summary>
        public event Action onSlotModelChanged = delegate { };

        #endregion

        #region Properties

        /// <summary>
        /// Слот в инвентаре
        /// </summary>
        public SlotModel SlotModel
        {
            get => _slotModel;
            set
            {
                if (value != _slotModel)
                {
                    _slotModel = value;
                    onSlotModelChanged();
                }
            }
        }
        private SlotModel _slotModel = default;

        #endregion
    }
}