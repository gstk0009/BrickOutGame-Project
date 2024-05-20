using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    AudioSource audioSource;
    [SerializeField] private AudioClip backGroundAudio;
    [SerializeField] private AudioClip btnClickAudio;
    [SerializeField] private AudioClip brickAudio;
    [SerializeField] private AudioClip GameClearAudio;
    [SerializeField] private AudioClip GameOverAudio;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayBackGroundAudio();
    }

    private void PlayBackGroundAudio()
    {
        audioSource.clip = this.backGroundAudio;
        audioSource.Play();
    }

    public void BtnClickAudio()
    {
        audioSource.PlayOneShot(this.btnClickAudio);
    }

    public void BallCollisionAudio()
    {
        audioSource.PlayOneShot(brickAudio);
    }
}
