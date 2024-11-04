using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
public AudioClip soundClip; // Перетащите сюда ваш аудиофайл в инспекторе
    private AudioSource audioSource;

    void Start()
    {
        // Добавляем AudioSource к объекту
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip;
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
        if (audioSource != null && soundClip != null)
        {
            audioSource.PlayOneShot(soundClip);
        }
    }
}
