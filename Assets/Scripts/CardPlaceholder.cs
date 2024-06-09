using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardPlaceholder : MonoBehaviour, IDropHandler
{
    public ManageCards mngc;
    public void OnDrop(PointerEventData eventData)
    {
        if(mngc.Deck.Count < 6)
        {
            GameObject dropped = eventData.pointerDrag;
            dropped.GetComponent<Card>().parentAfterDrag = transform;
            GameObject.FindGameObjectWithTag("CardManager").GetComponent<ManageCards>().Deck.Add(dropped);
        }
    }
}