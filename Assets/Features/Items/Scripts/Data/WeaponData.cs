namespace TestBakedPixel.Data
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Данные оружия
    /// </summary>
    [CreateAssetMenu(fileName = nameof(WeaponData), menuName = "TestBakedPixel/Features/Data/New " + nameof(WeaponData))]
    public class WeaponData : AbstractItemData
    {
        #region Properties

        /// <summary>
        /// Наносимый урон
        /// </summary>
        public int Damage => _damage;
        [SerializeField, Min(0)]
        private int _damage = 1;

        /// <summary>
        /// Список используемых патронов
        /// </summary>
        public List<AmmoData> UsingAmmo => _usingAmmo;
        [SerializeField]
        private List<AmmoData> _usingAmmo = new List<AmmoData>();

        #endregion
    }
}