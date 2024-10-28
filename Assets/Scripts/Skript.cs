using UnityEngine;

public class Skript : MonoBehaviour
{
    public Transform SpawnPos; // Позиция спавна
    public GameObject rock; // Префаб камня

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SpawnRock();
        }
    }

    void SpawnRock()
    {
        Instantiate(rock, SpawnPos.position, Quaternion.identity);
    }
}
