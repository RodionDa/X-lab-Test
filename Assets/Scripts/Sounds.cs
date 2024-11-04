using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
public AudioClip[] soundClips; // Массив аудиофайлов
    private AudioSource audioSource;

    void Start()
    {
        // Добавляем AudioSource к объекту
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        // Проверяем нажатие левой кнопки мыши
        if (Input.GetMouseButtonDown(0))
        {
            PlaySound();
        }
    }

    void PlaySound()
    {
        if (audioSource != null && soundClips.Length > 0)
        {
            // Выбираем случайный звук из массива
            AudioClip randomClip = soundClips[Random.Range(0, soundClips.Length)];
            audioSource.PlayOneShot(randomClip);
        }
    }
}
