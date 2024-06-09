using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Runtime;
using System.Linq;
using System;
using Unity.Mathematics;

public class ManageCards : MonoBehaviour
{
    public GameObject gridLayoutPanel;
    public List<GameObject> CardList = new List<GameObject>();
    public List<GameObject> Deck = new List<GameObject>();
    public List<GameObject> ActiveCardList = new List<GameObject>();
    public GameObject CardPanel;
    public GameObject AnimPanel;
    public GameObject ShopPanel;
    public TMP_Text moneyAmount;
    public GameObject[] startingDeck;
    public GameObject DeckButton;
    public TMP_Text StartButton;
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
        moneyAmount.text = money.ToString();
        if (Deck.Count >= 3)
        {
            StartButton.color = new Color32(255, 255, 255, 255);
            StartButton.fontSize = 132f;
            StartButton.text = "Start";
        }
        else
        {
            StartButton.color = new Color32(70, 70, 70, 255);
            StartButton.fontSize = 70f;
            StartButton.text = "You need to finish the red fields first";
        }
    }
    public void OnStartClicked()
    {
        System.Random rnd = new System.Random();

        ActiveCardList = Deck.OrderBy(x => rnd.Next()).ToList();
        foreach(Transform gmb in gridLayoutPanel.transform)
        {
            Destroy(gmb.gameObject);
        }
        foreach (GameObject gmb in ActiveCardList)
        {
            GameObject gg = Instantiate(gmb, gridLayoutPanel.transform);
            gg.GetComponent<Card>().ForSale = false;
            gg.GetComponent<Card>().ImUsed = false;
            gg.GetComponent<Card>().Draggable = false;
            gg.GetComponent<Card>().Showable = false;
        }
        if (Deck.Count >= 3)
        {
            Time.timeScale = 1f;
            AnimPanel.SetActive(false);
        }
        else
        {
            //u should fill all the 3 fields
        }
    }
}