using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCamera : MonoBehaviour
{
  public AudioClip backgroundMusic; // Задайте фоновую музыку в инспекторе
    public AudioClip[] soundEffects; // Массив звуковых эффектов
    private AudioSource musicSource;
    private AudioSource effectsSource;

    void Start()
    {
        // Добавляем AudioSource для фоновой музыки
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = backgroundMusic;
        musicSource.volume = 0.5f; 
        musicSource.loop = true; 
        musicSource.Play(); 
        effectsSource = gameObject.AddComponent<AudioSource>();

        // Воспроизводим случайный звуковой эффект сразу при запуске
        PlayRandomSoundEffect();
    }

    void Update()
    {
        // Проверяем нажатие пробела для воспроизведения звукового эффекта
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayRandomSoundEffect();
        }
    }

    void PlayRandomSoundEffect()
    {
        if (soundEffects.Length > 0)
        {
            // Выбираем случайный звук из массива
            AudioClip randomClip = soundEffects[Random.Range(0, soundEffects.Length)];
            effectsSource.PlayOneShot(randomClip);
        }
    }
}
