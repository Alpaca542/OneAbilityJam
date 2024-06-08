using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    public GameObject myDescribtionImg;
    public string myDescribtionText;
    private bool MouseOnMe = false;
    private void Start()
    {
        myDescribtionImg.GetComponentInChildren<TMP_Text>().text = myDescribtionText + "\n<i> Enter to disable</i>";
    }
    private void OnMouseEnter()
    {
        MouseOnMe = true;
        myDescribtionImg.SetActive(true);
    }
    private void OnMouseExit()
    {
        MouseOnMe = false;
        myDescribtionImg.SetActive(false);
    }
    private void Update()
    {
        if (MouseOnMe && Input.GetKeyDown(KeyCode.Return))
        {
            gameObject.GetComponent<Image>().color = new Color32(30, 30, 30, 255);
        }
    }
}