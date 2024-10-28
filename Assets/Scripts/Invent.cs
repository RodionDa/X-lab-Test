using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public GameObject currentItem; // Текущий предмет
    public Transform itemHolder; // Точка, где предмет находится (например, рука персонажа)
    public GameObject newItemPrefab; // Новый предмет, который будет заменять текущий

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchItem(newItemPrefab);
        }
    }

    public void SwitchItem(GameObject newItem)
    {
        if (itemHolder == null)
        {
            Debug.LogError("Item Holder is not assigned.");
            return;
        }
        
        if (currentItem != null)
        {
            Destroy(currentItem); // Удаляем текущий предмет
        }
        
        if (newItem != null)
        {
            currentItem = Instantiate(newItem, itemHolder.position, itemHolder.rotation, itemHolder); // Создаем новый предмет
        }
        else
        {
            Debug.LogError("New Item Prefab is not assigned.");
        }
    }
}
