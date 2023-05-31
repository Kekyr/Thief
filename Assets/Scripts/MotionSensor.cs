using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class MotionSensor : MonoBehaviour
{
    public event UnityAction<float> Entered;
    public event UnityAction<float> Exited;

    private float _minVolume = 0;
    private float _maxVolume = 1;
    
    private bool _isInside;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out Thief thief))
        {
            if (_isInside)
            {
                _isInside = false;
                Exited?.Invoke(_minVolume);
            }
            else
            {
                _isInside = true;
                Entered?.Invoke(_maxVolume);
            }
        }
    }
}
