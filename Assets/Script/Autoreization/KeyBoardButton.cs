using Org.BouncyCastle.Tls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoardButton : MonoBehaviour
{
    public GameObject ButtonKeyBoard;
    public GameObject DelKey;
    public GameObject Clone;

    public InputField TestText;
    void Start()
    {
        string keyboardChars = "!@#$%^&*_-.QWERTYUIOPASDFGHJKLZXCVBNM";
        string[] keyboardArray = new string[keyboardChars.Length];
        for (int i = 0; i < 10; i++)
        {
            Clone = Instantiate(ButtonKeyBoard);
            Clone.SetActive(true);
            Clone.transform.parent = ButtonKeyBoard.transform.parent;
            Clone.transform.position = ButtonKeyBoard.transform.position;
            Clone.transform.localScale = ButtonKeyBoard.transform.localScale;
            Clone.transform.GetChild(0).GetComponent<Text>().text = i.ToString();
            Clone.name = i.ToString();
        }
        ButtonKeyBoard.transform.SetSiblingIndex(10);
        for (int i = 1; i < keyboardChars.Length; i++)
        {
            keyboardArray[i] = keyboardChars[i].ToString();
            Clone = Instantiate(ButtonKeyBoard);
            Clone.SetActive(true);
            Clone.transform.parent = ButtonKeyBoard.transform.parent;
            Clone.transform.position = ButtonKeyBoard.transform.position;
            Clone.transform.localScale = ButtonKeyBoard.transform.localScale;
            Clone.transform.GetChild(0).GetComponent<Text>().text = keyboardArray[i];
            Clone.name = keyboardArray[i].ToString();
        }
        DelKey.transform.SetSiblingIndex(DelKey.transform.parent.childCount);

    }

    public void TestTextScr() 
    { 
    
    }
}
