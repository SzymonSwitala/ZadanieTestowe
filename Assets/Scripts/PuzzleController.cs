using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public List<Scarab> goldenScarabPath;
    private Scarab[] allScarabs;
    private LineRenderer line;
    private MessageController messageController;
    [SerializeField] private Material redMaterial;
    private void Start()
    {
        line = GetComponent<LineRenderer>();
        allScarabs = GetComponentsInChildren<Scarab>();
        messageController = GameObject.FindGameObjectWithTag("Message").GetComponent<MessageController>();
    }
    private void RefreshScarabs()
    {
        if (goldenScarabPath.Count > 0)
        {
            for (int i = 0; i < goldenScarabPath.Count - 1; i++)
            {
                goldenScarabPath[i].SetScarabType(Scarab.ScarabType.blue);
            }
            goldenScarabPath[goldenScarabPath.Count - 1].SetScarabType(Scarab.ScarabType.golden);
        }

    }
    public bool CheckIsCompleted()
    {

        for (int i = 0; i < allScarabs.Length; i++)
        {

            for (int j = 0; j < allScarabs[i].isConnected.Length; j++)
            {

                if ((allScarabs[i].isConnected[j]) == false)
                {
                  
                    return false;
                }

            }

        }
        Debug.Log("Completed");
        messageController.ShowMessage("Puzzle Completed!");
        SoundController.playSound(SoundController.completedSound);
        line.material = redMaterial;
        return true;
    }
    private void DrawLine()
    {
        line.positionCount = goldenScarabPath.Count;
        for (int i = 0; i < goldenScarabPath.Count; i++)
        {
            line.SetPosition(i, goldenScarabPath[i].transform.position);
        }


    }
    public void SetNewGoldenScarab(Scarab scarab)
    {
        goldenScarabPath.Add(scarab);
        RefreshScarabs();
        DrawLine();

    }
    public void ResetGame()
    {
        for (int i = 0; i < goldenScarabPath.Count; i++)
        {
            goldenScarabPath[i].SetScarabType(Scarab.ScarabType.stone);
            goldenScarabPath[i].RefreshScarabType();
            goldenScarabPath[i].ClearAllConnection();
        }
        line.positionCount = 0;
        goldenScarabPath.Clear();

    }
    public void BackOneMove()
    {
        if (goldenScarabPath.Count > 0)
        {
            goldenScarabPath[goldenScarabPath.Count - 1].SetScarabType(Scarab.ScarabType.stone);
            goldenScarabPath[goldenScarabPath.Count - 1].ClearOneConnection(goldenScarabPath[goldenScarabPath.Count-2].gameObject);
            goldenScarabPath[goldenScarabPath.Count - 2].ClearOneConnection(goldenScarabPath[goldenScarabPath.Count - 1].gameObject);
            goldenScarabPath.RemoveAt(goldenScarabPath.Count - 1);
            RefreshScarabs();
            line.positionCount -= 1;
        }
    }

}
