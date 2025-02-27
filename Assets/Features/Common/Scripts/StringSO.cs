namespace TestBakedPixel.Common
{
    using UnityEngine;

    /// <summary>
    /// Строка в виде SO
    /// </summary>
    [CreateAssetMenu(fileName = nameof(StringSO), menuName = "TestBakedPixel/Features/Common/New " + nameof(StringSO))]
    public class StringSO : ScriptableObject
    {
        #region Properties

        /// <summary>
        /// Содержимое
        /// </summary>
        public string Content => _content;
        [SerializeField]
        private string _content = string.Empty;

        #endregion
    }
}