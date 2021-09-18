using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MessageController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI message;
    [SerializeField] private TextMeshProUGUI buttonMessage;
    public void ShowButtonMessage(string text,bool toggle )
    {

        buttonMessage.gameObject.SetActive(toggle);
        
        buttonMessage.text =text;
    }
    public void ShowMessage(string text)
    {
        message.text = text;
        StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        message.gameObject.SetActive(true);     
        yield return new WaitForSeconds(2);
        message.gameObject.SetActive(false);
    }
}
