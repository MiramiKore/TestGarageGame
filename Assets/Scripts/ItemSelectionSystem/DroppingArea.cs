using System.Collections.Generic;
using itemSelectionSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ItemSelectionSystem
{
    public class DroppingArea : MonoBehaviour
    {
        [SerializeField] private List<GameObject> droppingItems; // Список для хранения сброшенных предметов
        
        [SerializeField] private float zOffsetStep = 1.0f; // Шаг смещения по оси Z
        [SerializeField] private float xOffsetStep = 1.0f; // Шаг смещения по оси X
        [SerializeField] private int itemsPerRow = 3; // Количество предметов в ряду
        
        private float _currentZOffset = 0f; // Текущее смещение по оси Z
        private float _currentXOffset = 1.0f; // Текущее смещение по оси X

        private const int MaxItems = 9; // Максимальное количество выброшенных предметов
        
        private void Awake()
        {
            // Подписываемся на событие сброса предмета
            var itemDeselection = FindObjectOfType<ItemDeselection>();
            itemDeselection.onDropItem.AddListener(DroppedItem);
        }

        // Выбрасываем предмет
        private void DroppedItem(GameObject droppedItem)
        {
            droppingItems.Add(droppedItem);
            ItemSetting(droppedItem);
            
            if (droppingItems.Count == MaxItems)
            {
                DroppedAllItems();
            }
        }

        // Настраиваем выброшенный предмет
        private void ItemSetting(GameObject droppedItem)
        {
            droppedItem.SetActive(true);
            droppedItem.GetComponent<Collider>().enabled = false;

            TransformItem(droppedItem.transform);
        }
        
        // Смещаем предмет в нужную позицию
        private void TransformItem(Transform itemTransform)
        {
            var currentPosition = transform.position;
            
            var newPosition = new Vector3(currentPosition.x + _currentXOffset, currentPosition.y,
                currentPosition.z + _currentZOffset);

            itemTransform.position = newPosition;
            UpdateOffsets();
        }
        
        // Обновляем смещения для следующего предмета
        private void UpdateOffsets()
        {
            _currentZOffset -= zOffsetStep;

            // Если ряд заполнен, сбрасываем Z и начинаем новый ряд по X
            if (droppingItems.Count % itemsPerRow == 0)
            {
                _currentZOffset = 0;
                _currentXOffset -= xOffsetStep;
            }
        }
        
        private void DroppedAllItems()
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}
