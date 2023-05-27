using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Speaker : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private float _delay;
    [SerializeField] private float _speed;

    private Coroutine _currentVolume;
    private Coroutine _currentMusic;
    private AudioSource _audioSource;
    private WaitForSeconds _waitForOneSeconds;

    private float _minVolume = 0;
    private float _maxVolume = 1;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _waitForOneSeconds = new WaitForSeconds(_delay);
    }

    public void Play()
    {
        CheckCoroutine(_currentMusic);
        _currentMusic = StartCoroutine(PlayAudioClip());
    }

    public void IncreaseMusicVolume()
    {
        CheckCoroutine(_currentVolume);
        _currentVolume = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void DecreaseMusicVolume()
    {
        CheckCoroutine(_currentVolume);
        _currentVolume = StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            float volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _speed);
            _audioSource.volume = volume;
            yield return _waitForOneSeconds;
        }
    }

    private void CheckCoroutine(Coroutine coroutine)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    private IEnumerator PlayAudioClip()
    {
        while (_audioSource.volume > _minVolume)
        {
            _audioSource.PlayOneShot(_audioClip);
            yield return _waitForOneSeconds;
        }
    }
}
