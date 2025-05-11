using UnityEngine;

public class PuzzleLogic : MonoBehaviour
{

    [Header("Puzzle Pieces")]
    public GameObject puzzle1;
    public GameObject puzzle2;

    [Header("Puzzle Groups")]
    public GameObject[] redPuzzles;
    public GameObject[] bluePuzzles;

    [Header("Snap Zones")]
    public GameObject snapZone1;
    public GameObject snapZone2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puzzle1.SetActive(false);
        puzzle2.SetActive(false);
        snapZone1.SetActive(false);
        snapZone2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool redPuzzleSnapped = false;
    private bool bluePuzzleSnapped = false;

    public void RedPuzzleGrabbed()
    {
        if (redPuzzleSnapped) return;
        snapZone1.SetActive(true);
    }

    public void BluePuzzleGrabbed()
    {
        if (bluePuzzleSnapped) return;
        snapZone2.SetActive(true);
    }


    public void OnRedPuzzleSnap()
    {
        redPuzzleSnapped = true;
        puzzle2.SetActive(true);
        for(int i = 0; i < redPuzzles.Length; i++)
        {
            redPuzzles[i].SetActive(false);
        }
        snapZone1.SetActive(false);
    }

    public void onBluePuzzleSnap()
    {
        bluePuzzleSnapped = true;
        puzzle1.SetActive(true);
        for(int i = 0; i < bluePuzzles.Length; i++)
        {
            bluePuzzles[i].SetActive(false);
        }
        snapZone2.SetActive(false);
    }
}
