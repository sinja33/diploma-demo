using UnityEngine;

public class InvisiblePuzzle : MonoBehaviour
{

    public GameObject puzzle1;
    public GameObject puzzle2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puzzle1.SetActive(false);
        puzzle2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
