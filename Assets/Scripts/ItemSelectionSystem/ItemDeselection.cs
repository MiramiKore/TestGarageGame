using UnityEngine;
using UnityEngine.Events;

namespace itemSelectionSystem
{
    public class ItemDeselection : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<GameObject> onDropItem = new UnityEvent<GameObject>();
        
        [SerializeField] private bool canDropping = false;
        
        private ItemSelectionSystem _itemSelectionSystem;
        
        private void Awake()
        {
            _itemSelectionSystem = FindObjectOfType<ItemSelectionSystem>();
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

        private void Update()
        {
            if (canDropping && Input.GetKeyDown(KeyCode.E))
            {
                DeselectedItem();
            }
        }

        private void DeselectedItem()
        {
            onDropItem.Invoke(_itemSelectionSystem.items[0]);
            
            _itemSelectionSystem.DropItem(_itemSelectionSystem.items[0]);
        }
    }
}