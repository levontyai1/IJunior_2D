using UnityEngine;

public class DeleteBlocks : MonoBehaviour
{
    private void Start()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("BlockToDelete");

        foreach (GameObject block in blocks)
        {
            block.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
