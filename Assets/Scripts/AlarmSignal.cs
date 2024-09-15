using System.Collections;
using UnityEngine;

public class AlarmSignal : MonoBehaviour
{
    [SerializeField] private House _house;
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _coroutine;
    private float _speed;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
        _speed = 0.5f;
    }

    private void OnEnable()
    {
        _house.Entered += IncreaseSound;
        _house.Leaved += DecreaseSound;
    }

    private void OnDisable()
    {
        _house.Entered -= IncreaseSound;
        _house.Leaved -= DecreaseSound;
    }

    private void IncreaseSound()
    {
        float targetVolume = 1;
        _audioSource.Play();

        LaunchCoroutine(targetVolume);
    }

    private void DecreaseSound()
    {
        float targetVolume = 0;

        LaunchCoroutine(targetVolume);
    }

    private void LaunchCoroutine(float targetVolume)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        _coroutine = StartCoroutine(ChangeVolume(targetVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _speed * Time.deltaTime);

            yield return null;
        }

        if(_audioSource.volume == 0)
        {
            _audioSource.Pause();
        }
    }
}
