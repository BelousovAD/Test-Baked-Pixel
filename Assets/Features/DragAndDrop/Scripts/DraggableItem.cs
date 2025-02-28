namespace TestBakedPixel.DragAndDrop
{
    using TestBakedPixel.Inventory.Model;
    using TestBakedPixel.Slots.Model;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using Zenject;

    /// <summary>
    /// Перетаскиваемый предмет
    /// </summary>
    public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        #region Properties

        [SerializeField]
        private SlotModelProvider _slotModelProvider = default;

        /// <summary>
        /// Слот в инвентаре
        /// </summary>
        public SlotModel SlotModel
        {
            get => _slotModel;
            protected set
            {
                if (value != _slotModel)
                {
                    _slotModel = value;
                }
            }
        }
        private SlotModel _slotModel = default;

        private Canvas _canvas = default;
        private RectTransform _rect = default;
        private Transform _defaultParent = default;
        private Image _image = default;
        private InventoryModel _inventoryModel = default;

        #endregion

        #region Methods

        public void OnBeginDrag(PointerEventData eventData)
        {
            _image.raycastTarget = false;
            _rect.SetParent(_canvas.transform);
            _rect.SetAsLastSibling();
        }

        public void OnDrag(PointerEventData eventData)
            => _rect.anchoredPosition += eventData.delta / _canvas.scaleFactor;

        public void OnEndDrag(PointerEventData eventData)
        {
            _rect.SetParent(_defaultParent);
            _rect.SetAsFirstSibling();
            _rect.anchoredPosition = Vector2.zero;
            _image.raycastTarget = true;

            RaycastResult raycast = eventData.pointerCurrentRaycast;
            SlotModel dropSlotModel = default;

            if (raycast.gameObject.TryGetComponent(out SlotModelProvider slotModelProvider))
            {
                dropSlotModel = slotModelProvider.SlotModel;
            }
            else if (raycast.gameObject.TryGetComponent(out DraggableItem draggableItem))
            {
                dropSlotModel = draggableItem.SlotModel;
            }

            if (dropSlotModel != null)
            {
                _inventoryModel.StackSlots(SlotModel, dropSlotModel);
            }
        }

        [Inject]
        protected virtual void Construct(InventoryModel inventoryModel)
            => _inventoryModel = inventoryModel;

        protected virtual void Awake()
        {
            _canvas = GetComponentInParent<Canvas>();
            _rect = transform as RectTransform;
            _defaultParent = transform.parent;
            _image = GetComponent<Image>();
        }

        protected virtual void Start()
        {
            _slotModelProvider.onSlotModelChanged += InitSlotModel;

            if (_slotModelProvider.SlotModel != null)
            {
                InitSlotModel();
            }
        }

        protected virtual void OnDestroy()
        {
            _slotModelProvider.onSlotModelChanged -= InitSlotModel;
            SlotModel = null;
        }

        protected virtual void InitSlotModel()
            => SlotModel = _slotModelProvider.SlotModel;

        #endregion
    }
}