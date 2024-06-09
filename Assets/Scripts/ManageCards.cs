using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using static UnityEngine.UI.Image;
using System;

public class ManageCards : MonoBehaviour
{
    public List<GameObject> CardList = new List<GameObject>();
    public List<GameObject> Deck = new List<GameObject>();
    public List<GameObject> ActiveCardList = new List<GameObject>();
    public GameObject CardPanel;
    public GameObject ShopPanel;
    public GameObject[] startingDeck;
    public GameObject DeckButton;
    public Button StartButton;
    public int money;
    private void Start()
    {
        Time.timeScale = 0;
        foreach (GameObject gm in startingDeck)
        {
            CardList.Add(gm);
            CardList.Add(gm);
        }
    }
    public void OpenShop()
    {
        CardPanel.SetActive(false);
        ShopPanel.SetActive(true);
    }
    public void CloseShop()
    {
        CardPanel.SetActive(true);
        ShopPanel.SetActive(false);
    }
    public void GetMoney(int amount)
    {
        money += amount;
    }
    private void Update()
    {
        if(ActiveCardList.Count >= 3)
        {
            StartButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            StartButton.GetComponent<Image>().color = new Color32(30, 30, 30, 255);
        }
    }
    public void OnStartClicked()
    {
        if(ActiveCardList.Count >= 3)
        {
            ActiveCardList = Deck.ToList();
            Time.timeScale = 1f;
            CardPanel.SetActive(false);
        }
        else
        {
            //u should fill all the 3 fields
        }
    }
}