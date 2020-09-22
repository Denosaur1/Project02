using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;
    [SerializeField] AudioClip startingSong;
    AudioSource audioSource;

    private void Start()
    {
        if (startingSong != null)
        {
            AudioManager.Instance.PlaySong(startingSong);
        }
    }

    private void Awake()
    {

        #region Singleton Pattern (Simple)
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
    }
    public void PlaySong(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    
}
