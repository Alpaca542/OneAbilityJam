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
    public int money;
    private void Start()
    {
        foreach (GameObject gm in startingDeck)
        {
            CardList.Add(gm);
        }
    }
    public void GetMoney(int amount)
    {
        money += amount;
    }
    public void OnStartClicked()
    {
        ActiveCardList = Deck.ToList();
        Time.timeScale = 1f;
        CardPanel.SetActive(false);
    }
}