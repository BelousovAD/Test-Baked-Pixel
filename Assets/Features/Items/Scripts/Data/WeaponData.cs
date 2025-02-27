namespace TestBakedPixel.Items.Data
{
    using System.Collections.Generic;
    using TestBakedPixel.Common;
    using UnityEngine;

    /// <summary>
    /// Данные оружия
    /// </summary>
    [CreateAssetMenu(fileName = nameof(WeaponData), menuName = "TestBakedPixel/Features/Items/Data/New " + nameof(WeaponData))]
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
        public List<StringSO> UsingAmmoIds => _usingAmmoIds;
        [SerializeField]
        private List<StringSO> _usingAmmoIds = new List<StringSO>();

        #endregion
    }
}