using System;
using System.Collections.Generic;
using UnityEngine;

public class DoorAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _doorSound;
    private readonly List<GameObject> _players = new List<GameObject>();
    private bool _isPlaying = false;
    private const float TargetVolume = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_players.Contains(other.gameObject))
            {
                _players.Remove(other.gameObject);
                if (_players.Count == 0)
                {
                    
                    _isPlaying = false;
                }
            }
            else
            {
                _players.Add(other.gameObject);
                _doorSound.Play();
                _isPlaying = true;
            }
        }
    }

    private void Update()
    {
        if (_isPlaying)
        {
            _doorSound.volume = Mathf.MoveTowards(_doorSound.volume, 1f, Time.deltaTime / TargetVolume);
        }
        else if (!_isPlaying)
        {
            _doorSound.volume = Mathf.MoveTowards(_doorSound.volume, 0f, Time.deltaTime / TargetVolume);
            if (_doorSound.volume <= 0f) _doorSound.Stop();
        }
    }
}
