using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] private Image _image;
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        var color = _image.color;

        for (int i = 0; i < 255; i++)
        {
            color.a = 1f - (1f / 255f * i);
            _image.color = color;
            yield return null;
        }
    }
}
