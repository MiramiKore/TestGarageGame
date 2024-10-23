using UnityEngine;
using UnityEngine.Events;

namespace itemSelectionSystem
{
    public class ItemDeselection : MonoBehaviour
    {
        // Событие вызываемое при сбросе предмета
        [HideInInspector] public UnityEvent<GameObject> onDropItem = new UnityEvent<GameObject>();

        // Флаг указывающий находится ли игрок в зоне сброса
        [SerializeField] private bool canDropping = false;

        private ItemSelectionSystem _itemSelectionSystem;

        private void Awake()
        {
            _itemSelectionSystem = FindObjectOfType<ItemSelectionSystem>();
        }

        private void Update()
        {
            if (canDropping && Input.GetKeyDown(KeyCode.E))
            {
                DeselectedItem();
            }
        }

        // Подходя к предмету, добавляем его в список доступных для подбора предметов
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("DroppingObjectsArea"))
            {
                canDropping = true;
            }
        }

        // Отходя от предмета, убираем его из списка доступных
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("DroppingObjectsArea"))
            {
                canDropping = false;
            }
        }

        // Выбрасываем предмет
        private void DeselectedItem()
        {
            if (_itemSelectionSystem.items.Count > 0)
            {
                onDropItem.Invoke(_itemSelectionSystem.items[0]);

                _itemSelectionSystem.DropItem(_itemSelectionSystem.items[0]);
            }
        }
    }
}