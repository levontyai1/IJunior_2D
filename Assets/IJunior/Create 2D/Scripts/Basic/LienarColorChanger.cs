using UnityEngine;

public class LienarColorChanger : MonoBehaviour
{

    [HideInInspector] public SpriteRenderer Targer;
    [SerializeField] private float _duration;
    
    [SerializeField] private Color _targetColor;
    private float _runningTime;
    private Color _startColor;
    void Start()
    {
        Targer = GetComponent<SpriteRenderer>();
        _startColor = Targer.color;
    }

    void Update()
    {
        if (_runningTime <= _duration)
        {
            _runningTime += Time.deltaTime;

            float normalizeRunningTime = _runningTime / _duration;
            
            Targer.color = Color.Lerp(_startColor, _targetColor, normalizeRunningTime);
        }
    }
}
