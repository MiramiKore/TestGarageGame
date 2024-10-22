using System.Collections.Generic;
using UnityEngine;

namespace itemSelectionSystem
{
    public class ItemSelection : MonoBehaviour
    {
        // Список доступных предметов, находящихся рядом с игроком
        private readonly List<GameObject> _itemsInRange = new List<GameObject>();
        
        private ItemSelectionSystem _system;

        private Collider _collider;
        
        private void Awake()
        {
            _system = FindObjectOfType<ItemSelectionSystem>();
        }

        // Подходя к предмету, добавляем его в список доступных для подбора предметов
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Item"))
            {
                _itemsInRange.Add(other.gameObject);
            }
        }
        
        // Отходя от предмета, убираем его из списка доступных
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Item"))
            {
                _itemsInRange.Remove(other.gameObject);
            }
        }
        
        private void Update()
        {
            // Если в зоне есть предметы и игрок нажимает клавишу клавишу подбора предмета
            if (_itemsInRange.Count > 0 && Input.GetKeyDown(KeyCode.E))
            {
                SelectedItem();
            }
        }

        private void SelectedItem()
        {
            // Подбираем первый предмет из списка
            _system.GetItem(_itemsInRange[0]);
            
            _itemsInRange[0].SetActive(false);

            // Удаляем предмет из списка после подбора
            _itemsInRange.RemoveAt(0);
        }
    }
}