using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
   // Массив предметов, которые могут быть уничтожены
    public GameObject[] itemsToDestroy;

    // Точки, где предметы будут уничтожаться
    public Transform[] destroyPoints;

    // Радиус зоны, в которой объекты будут уничтожаться
    public float destroyRadius = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, если объект из массива "itemsToDestroy"
        foreach (GameObject item in itemsToDestroy)
        {
            if (collision.gameObject == item)
            {
                // Проверка, находится ли объект в радиусе одной из точек уничтожения
                foreach (Transform point in destroyPoints)
                {
                    if (Vector3.Distance(collision.transform.position, point.position) <= destroyRadius)
                    {
                        // Удаляем объект
                        Destroy(collision.gameObject);
                        // Выводим сообщение в консоль для отладки
                        Debug.Log("Уничтожен предмет: " + collision.gameObject.name);
                    }
                }
            }   
        }
    }   
}
