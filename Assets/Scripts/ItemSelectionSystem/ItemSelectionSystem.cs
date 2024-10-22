using System.Collections.Generic;
using UnityEngine;

namespace itemSelectionSystem
{
    public class ItemSelectionSystem : MonoBehaviour
    {
        // Список подобранных предметов
        public List<GameObject> items = new List<GameObject>();
        
        public void GetItem(GameObject currentObject)
        {
            items.Add(currentObject);
        }

        public void GiveItem()
        {
            
        }
    }
}