namespace TestBakedPixel.Buttons
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Абстрактная кнопка
    /// </summary>
    [RequireComponent(typeof(Button))]
    public abstract class AbstractButton : MonoBehaviour
    {
        #region Properties

        protected Button button = default;

        #endregion

        #region Methods

        protected virtual void Awake()
            => button = GetComponent<Button>();

        protected virtual void Start()
            => button.onClick.AddListener(OnClick);

        protected virtual void OnDestroy()
            => button.onClick.RemoveListener(OnClick);

        protected abstract void OnClick();

        #endregion
    }
}