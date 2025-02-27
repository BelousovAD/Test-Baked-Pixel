namespace TestBakedPixel.Slots.Data
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Данные о слоте
    /// </summary>
    [Serializable]
    public class SlotData
    {
        #region Properties

        /// <summary>
        /// Заблокирован ли слот
        /// </summary>
        public bool IsLocked => _isLocked;
        [SerializeField]
        private bool _isLocked = false;

        /// <summary>
        /// Стоимость разблокировки слота
        /// </summary>
        public int CostToUnlock => _costToUnlock;
        [SerializeField]
        private int _costToUnlock = 0;

        #endregion
    }
}