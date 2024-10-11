using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeName : MonoBehaviour
{
    public GameObject MenuBT;
    public GameObject PUBackGround;
    public GameObject MainUI;
    public GameObject SetNameUI;
    public InputField userInputField; 
    public Text PlayerName;
    public UIMenu scriptB;
    // Start is called before the first frame update
    void Start()
    {
        userInputField.onEndEdit.AddListener(UpdateText);
    }
    public void UpdateText(string userInput)
    {
        PlayerName.text = userInput;  // InputField의 값을 Text로 설정
        SetNameUI.SetActive(false);
        MainUI.SetActive(true);
        MenuBT.SetActive(true);
        PUBackGround.SetActive(false);
        scriptB.DisplayNames();
    }
}
