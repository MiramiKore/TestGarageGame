using System.Collections.Generic;
using itemSelectionSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace ItemSelectionSystem
{
    public class DroppingArea : MonoBehaviour
    {
        [SerializeField] private List<GameObject> droppingItems;

        private void Awake()
        {
            var itemDeselection = FindObjectOfType<ItemDeselection>();
            itemDeselection.onDropItem.AddListener(DroppedItem);
        }

        private void DroppedItem(GameObject droppedItem)
        {
            droppingItems.Add(droppedItem);
            
            droppedItem.SetActive(true);

            TransformItem(droppedItem.transform);

            if (droppingItems.Count == 3)
            {
                DroppedAllItems();
            }
        }

        private void TransformItem(Transform itemTransform)
        {
            itemTransform.position = transform.position;
        }

        private void DroppedAllItems()
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}
