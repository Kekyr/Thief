using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Speaker))]
public class MotionSensor : MonoBehaviour
{
    private Speaker _speaker;
    private bool _isInside;

    private void Awake()
    {
        _speaker = GetComponent<Speaker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out Thief thief))
        {
            if (_isInside)
            {
                _isInside = false;
                _speaker.DecreaseMusicVolume();
            }
            else
            {
                _isInside = true;
                _speaker.IncreaseMusicVolume();
                _speaker.Play();
            }
        }
    }
}
