using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    public GameObject myDescribtionImg;
    public string myDescribtionText;
    public string myAbility;
    private bool MouseOnMe = false;
    private ManageCards CardMng;
    public bool ImOn = true;
    private void Start()
    {
        CardMng = GameObject.FindGameObjectWithTag("CardManager").GetComponent<ManageCards>();
        myDescribtionImg.GetComponentInChildren<TMP_Text>().text = myDescribtionText + "\n<i> Enter to disable</i>";
    }
    public void MouseEnter()
    {
        MouseOnMe = true;
        myDescribtionImg.SetActive(true);
    }
    public void MouseExit()
    {
        MouseOnMe = false;
        myDescribtionImg.SetActive(false);
    }
    private void Update()
    {
        if (MouseOnMe)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (ImOn && CardMng.GetActiveCardAmount() > 3)
                {
                    ImOn = false;
                    CardMng.cardList[gameObject] = false;
                    gameObject.GetComponent<Image>().color = new Color32(30, 30, 30, 255);
                }
                else if(!ImOn)
                {
                    ImOn = true;
                    CardMng.cardList[gameObject] = true;
                    gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                }
            }
            else
            {
                //show a warning that u need at leat 3 cards in ur deck
            }
        }
    }
}