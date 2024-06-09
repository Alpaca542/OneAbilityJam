using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public Transform parentAfterDrag;
    public GameObject myDescribtionImg;
    public bool Draggable;
    public bool ForSale;
    public int price;
    public string myDescribtionText;
    public string myAbility;
    public bool Showable = true;
    public bool ImOn = true;
    public bool ImUsed = false;
    private void Start()
    {
        myDescribtionImg.GetComponentInChildren<TMP_Text>().text = myDescribtionText + "\n\n<i> Enter to disable</i>";
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Draggable)
        {
            myDescribtionImg.SetActive(false);
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            GetComponent<Image>().raycastTarget = false;
        }
    }
   
    public void OnDrag(PointerEventData eventData)
    {
        if (Draggable)
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Draggable)
        {
            GetComponent<Image>().raycastTarget = true;
            transform.SetParent(parentAfterDrag);
        }
    }
    public void MouseEnter()
    {
        if (Showable)
        {
            myDescribtionImg.SetActive(true);
        }
    }
    public void MouseExit()
    {
        if (Showable)
        {
            myDescribtionImg.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (ForSale)
        {
            GameObject.FindGameObjectWithTag("ShopManager").GetComponent<ShopManager>().Buy(gameObject, price);
        }
    }
}