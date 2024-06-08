using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ManageCards : MonoBehaviour
{
    public Dictionary<GameObject, int> cardList = new Dictionary<GameObject, int>();
    public GameObject CardPanel;
    public GameObject ShopPanel;
    public GameObject[] startingDeck;
    public GameObject DeckButton;
    public int money;
    private void Start()
    {
        foreach(GameObject gm in startingDeck)
        {
            cardList.Add(gm, 1);
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
            Time.timeScale = 1f;
            ShopPanel.SetActive(false);
        }
        else if (CardPanel.activeSelf)
        {
            Time.timeScale = 1f;
            CardPanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            CardPanel.SetActive(true);
        }
        foreach(GameObject gmb in cardList.Keys)
        {
            gmb.SetActive(true);
            if (cardList[gmb] == 0)
            {
                gmb.GetComponent<Image>().color = new Color32(30, 30, 30, 255);
            }
            if (cardList[gmb] == 2)
            {
                gmb.GetComponent<Image>().color = new Color32(0, 0, 255, 255);
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
            if (cardList[gmb] == 1)
            {
                counter++;
            }
        }
        return counter;
    }
    public Dictionary<GameObject, int> GetActiveCardList()
    {
       return cardList.Where(p => p.Value == 1)
                 .ToDictionary(p => p.Key, p => p.Value);
    }
}