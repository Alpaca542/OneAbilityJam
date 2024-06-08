using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ManageCards : MonoBehaviour
{
    public Dictionary<GameObject, bool> cardList = new Dictionary<GameObject, bool>();
    public GameObject CardPanel;
    public GameObject ShopPanel;
    public GameObject[] startingDeck;
    public GameObject DeckButton;
    public int money;
    private void Start()
    {
        foreach(GameObject gm in startingDeck)
        {
            cardList.Add(gm, true);
        }
    }
    public void GetMoney(int amount)
    {
        money += amount;
    }
    public void OnDeckClicked()
    {
        if (ShopPanel.activeSelf)
        {
            ShopPanel.SetActive(false);
        }
        else if (CardPanel.activeSelf)
        {
            CardPanel.SetActive(false);
        }
        else
        {
            CardPanel.SetActive(true);
        }
        foreach (GameObject gmb in cardList.Keys)
        {
            if (cardList[gmb])
            {
                gmb.SetActive(true);
            }
        }
    }
    public void OShopClicked()
    {
        CardPanel.SetActive(false);
        ShopPanel.SetActive(true);
    }
    public int GetActiveCardAmount()
    {
        int counter = 0;
        foreach(GameObject gmb in cardList.Keys)
        {
            if (cardList[gmb])
            {
                counter++;
            }
        }
        return counter;
    }
    public Dictionary<GameObject, bool> GetActiveCardList()
    {
       return cardList.Where(p => p.Value == true)
                 .ToDictionary(p => p.Key, p => p.Value);
    }
}