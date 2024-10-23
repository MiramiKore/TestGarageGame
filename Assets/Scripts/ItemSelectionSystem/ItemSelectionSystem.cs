using System.Collections.Generic;
using UnityEngine;

namespace itemSelectionSystem
{
    public class ItemSelectionSystem : MonoBehaviour
    {
        // Список подобранных игроком предметов
        public List<GameObject> items = new List<GameObject>();
        
        // Добавляем подобранный предмет
        public void GetItem(GameObject currentObject)
        {
            items.Add(currentObject);
        }

        // Убираем подобранный предмет
        public void DropItem(GameObject currentObject)
        {
            items.Remove(currentObject);
        }
    }
}