using UnityEngine;

public class Lifetime : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    void Start()
    {
        Debug.Log("Start - " + gameObject.name);
    }

    void Update()
    {
        // Debug.Log("Update - " + gameObject.name);
    }
}
