namespace TestBakedPixel.Data
{
    using UnityEngine;

    /// <summary>
    /// Данные шлема
    /// </summary>
    [CreateAssetMenu(fileName = nameof(HelmetData), menuName = "TestBakedPixel/Features/Data/New " + nameof(HelmetData))]
    public class HelmetData : AbstractItemData
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