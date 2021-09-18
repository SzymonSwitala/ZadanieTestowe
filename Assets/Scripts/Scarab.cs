using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarab : MonoBehaviour
{
    private Material goldenScarab;
    private Material blueScarab;
    private Material stoneScarab;
    private Renderer rend;
    private Animator anim;
    private PuzzleController puzzleController;
    public enum ScarabType
    {
        stone,
        blue,
        golden
    }
    [SerializeField] private ScarabType scarabType;
    [SerializeField] private Scarab[] connectedScarabs;
    public bool[] isConnected;

    private void Start()
    {
        puzzleController = GetComponentInParent<PuzzleController>();
        goldenScarab = Resources.Load<Material>("goldenScarab");
        blueScarab = Resources.Load<Material>("blueScarab");
        stoneScarab = Resources.Load<Material>("stoneScarab");
        rend = GetComponent<Renderer>();
        isConnected = new bool[connectedScarabs.Length];
        anim = GetComponent<Animator>();
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (puzzleController.goldenScarabPath.Count == 0)
            {
                // set new GoldenScarab
                puzzleController.SetNewGoldenScarab(this.gameObject.GetComponent<Scarab>());
                anim.SetTrigger("changeType");
                SoundController.playSound(SoundController.scarabSound);
            }
            else
            {
                Scarab currentGoldenScarab = puzzleController.goldenScarabPath[puzzleController.goldenScarabPath.Count - 1];
                if (IsThisScarabConnectedWith(currentGoldenScarab.gameObject))
                {
                    // set new GoldenScarab
                    puzzleController.SetNewGoldenScarab(this.gameObject.GetComponent<Scarab>());                  
                    anim.SetTrigger("changeType");
                    SoundController.playSound(SoundController.scarabSound);
                    //connecting scarabs
                    ConnectThisScarabWith(currentGoldenScarab.gameObject);
                    currentGoldenScarab.ConnectThisScarabWith(this.gameObject);
                    puzzleController.CheckIsCompleted();
                   
                }            
            }
        }
    }
    private bool IsThisScarabConnectedWith(GameObject scarab)
    {

        for (int i = 0; i < connectedScarabs.Length; i++)
        {
            if (connectedScarabs[i].gameObject == scarab)
            {

                //if scarabs are not connected
                if (!isConnected[i])
                {

                    return true;
                }

            }
        }

        return false;
    }
    public void RefreshScarabType()
    {
        if (scarabType == ScarabType.stone)
        {
            rend.material = stoneScarab;
        }
        else if (scarabType == ScarabType.blue)
        {
            rend.material = blueScarab;
        }
        else if (scarabType == ScarabType.golden)
        {
            rend.material = goldenScarab;
        }
    }
    public void ConnectThisScarabWith(GameObject scarab)
    {
        for (int i = 0; i < connectedScarabs.Length; i++)
        {
            if (connectedScarabs[i].gameObject == scarab)
            {
                isConnected[i] = true;


            }
        }
       

    }
    public void ClearOneConnection(GameObject scarab)
    {
        for (int i = 0; i < isConnected.Length; i++)
        {
            if (scarab==connectedScarabs[i].gameObject)
            {
                isConnected[i] = false;
                anim.SetTrigger("changeType");
            }
        }
        }
    public void SetScarabType(ScarabType type)
    {
        scarabType = type;
        RefreshScarabType();
    }
    public void ClearAllConnection()
    {
       
            for (int i=0;i < isConnected.Length;i++)
        {
            isConnected[i] = false;
            anim.SetTrigger("changeType");
        }
    }
}
