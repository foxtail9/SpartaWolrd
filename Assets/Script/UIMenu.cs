using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using static UnityEngine.GraphicsBuffer;

public class UIMenu : MonoBehaviour
{
    public GameObject MenuBT;
    public GameObject PUBackGround;
    public GameObject MainUI;
    public GameObject SetNameUI;
    public GameObject SetChaterUI;
    public GameObject ShowplayerUI;
    public Text nameListText;
    public string playerTag = "Player";
    public GameObject player;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public Sprite[] characterSprites;
    public RuntimeAnimatorController[] characterAnimators;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        animator = player.GetComponent<Animator>();
        DisplayNames();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void DisplayNames()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);
        string playerNames = "";

        foreach (GameObject player in players)
        {
            Text playerNameText = player.GetComponentInChildren<Text>();
            if (playerNameText != null)
            {
                playerNames += playerNameText.text + "\n";
            }
        }
        nameListText.text = playerNames;
    }
    public void OnClickMenu()
    {
        MenuBT.SetActive(false);
        PUBackGround.SetActive(true);
    }
    public void OnClickExit()
    {
        PUBackGround.SetActive(false);
        MenuBT.SetActive(true);
    }
    public void OnClickName()
    {
        MainUI.SetActive(false);
        SetNameUI.SetActive(true);
    }
    public void OnClickChater()
    {
        MainUI.SetActive(false);
        SetChaterUI.SetActive(true);
    }
    public void OnClickShowUI()
    {
        DisplayNames();
        ShowplayerUI.SetActive(!ShowplayerUI.activeSelf);
    }
    public void OnClickSwap(int index)
    {
        if (index >= 0 && index < characterSprites.Length)
        {
            spriteRenderer.sprite = characterSprites[index];
            animator.runtimeAnimatorController = characterAnimators[index];
            PUBackGround.SetActive(false);
            SetChaterUI.SetActive(false);
            MainUI.SetActive(true);
            MenuBT.SetActive(true);
        }
    }
}

