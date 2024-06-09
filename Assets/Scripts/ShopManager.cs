using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ManageCards cardMng;
    public GameObject DeckPanel;
    public void Buy(GameObject what, int forHowMuch)
    {
        cardMng.money -= forHowMuch;
        GameObject spawnedCard = Instantiate(what, DeckPanel.transform);
        spawnedCard.GetComponent<Card>().myDescribtionImg.SetActive(false);
        cardMng.CardList.Add(spawnedCard);
        spawnedCard.GetComponent<Card>().ForSale = false;
        spawnedCard.GetComponent<Card>().Draggable = true;
        spawnedCard.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        what.GetComponent<Card>().Showable = false;
        what.GetComponent<Card>().myDescribtionImg.SetActive(false);
        what.GetComponent<Card>().ForSale = false;
        what.GetComponent<Image>().color = new Color32(70, 70, 70, 255);
    }
}