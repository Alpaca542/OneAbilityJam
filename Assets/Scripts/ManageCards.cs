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
    private void Start()
    {
        foreach(GameObject gm in startingDeck)
        {
            cardList.Add(gm, true);
        }
    }
    public void OnDeckClicked()
    {
        CardPanel.SetActive(!CardPanel.activeSelf);
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