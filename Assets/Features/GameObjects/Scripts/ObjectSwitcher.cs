namespace TestBakedPixel.GameObjects
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Переключатель объектов
    /// </summary>
    public class ObjectSwitcher : MonoBehaviour
    {
        #region Properties

        [SerializeField]
        private List<GameObject> objectsToEnable = new List<GameObject>();
        [SerializeField]
        private List<GameObject> objectsToDisable = new List<GameObject>();

        #endregion

        #region Methods

        protected void SwitchObjects(bool status)
        {
            objectsToEnable.ForEach(x => x.SetActive(status));
            objectsToDisable.ForEach(x => x.SetActive(!status));
        }

        #endregion
    }
}
