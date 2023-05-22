using UnityEngine;

[RequireComponent(typeof(Audio))]
public class Alarm : MonoBehaviour
{
    private Audio _audio;
    private bool _isInside;

    private void Awake()
    {
        _audio = GetComponent<Audio>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out Thief thief))
        {
            if (_isInside)
            {
                _isInside = false;
                _audio.DecreaseMusicVolume();
            }
            else
            {
                _isInside = true;
                _audio.IncreaseMusicVolume();
                _audio.PlayMusic();
            }
        }
    }
}
