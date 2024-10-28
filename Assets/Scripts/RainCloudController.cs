using System.Collections;
using UnityEngine;

public class RainCloudController : MonoBehaviour
{
    public Transform[] characters; // Массив персонажей
    public GameObject rainCloud; // Облако с дождем
    public float transitionDuration = 1.0f; // Длительность перехода между персонажами

    private int currentCharacterIndex = 0;
    private bool isTransitioning = false;

    void Start()
    {
        if (rainCloud == null)
        {
            Debug.LogError("Rain cloud not assigned!");
        }

        if (characters == null || characters.Length == 0)
        {
            Debug.LogError("Characters array not assigned or empty!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isTransitioning)
        {
            Debug.Log("Z key pressed");
            StartCoroutine(MoveToNextCharacter());
        }
    }

    IEnumerator MoveToNextCharacter()
    {
        isTransitioning = true;
        Debug.Log("Started moving to next character");

        // Отключаем дождь во время перехода
        if (rainCloud != null)
        {
            Debug.Log("Disabling rain effect.");
            rainCloud.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Rain cloud is not assigned or already deactivated.");
        }

        // Получаем текущую и следующую позиции
        Vector3 startPosition = transform.position;
        currentCharacterIndex = (currentCharacterIndex + 1) % characters.Length;
        Vector3 endPosition = characters[currentCharacterIndex].position;

        // Сохраняем текущую высоту облака
        endPosition.y = startPosition.y;

        Debug.Log($"Moving from {startPosition} to {endPosition}");

        // Плавно перемещаем облако
        float elapsedTime = 0;
        while (elapsedTime < transitionDuration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Устанавливаем конечную позицию
        transform.position = endPosition;

        // Включаем дождь после перехода
        if (rainCloud != null)
        {
            Debug.Log("Enabling rain effect.");
            rainCloud.SetActive(true);
        }

        Debug.Log("Reached next character, rain effect enabled");

        isTransitioning = false;
    }
}
