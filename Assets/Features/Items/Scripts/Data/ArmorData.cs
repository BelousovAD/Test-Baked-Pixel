namespace TestBakedPixel.Items.Data
{
    using UnityEngine;

    /// <summary>
    /// Данные жилета
    /// </summary>
    [CreateAssetMenu(fileName = nameof(ArmorData), menuName = "TestBakedPixel/Features/Items/Data/New " + nameof(ArmorData))]
    public class ArmorData : AbstractItemData
    {
        #region Properties

        /// <summary>
        /// Значение защиты
        /// </summary>
        public int ProtectionValue => _protectionValue;
        [SerializeField, Min(0)]
        private int _protectionValue = 1;

        #endregion
    }
}