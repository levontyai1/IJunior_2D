using UnityEngine;

public class CircleInstantiate : MonoBehaviour
{
    public GameObject Template;
    public int Count;
    public float Radius;

    private void Start()
    {
        float angelStep = 360f / Count * Mathf.Deg2Rad;
        
        for (int i = 1; i <= Count; i++)
        {
            GameObject newObject = Instantiate(Template, Vector3.zero, Quaternion.identity);
            
            Transform newObjectTransform = newObject.transform;
            
            newObjectTransform.position = new Vector3(Radius * Mathf.Cos(angelStep * i), Radius * Mathf.Sin(angelStep * i), 0);
        }
    }
}
