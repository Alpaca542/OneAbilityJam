using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardPlaceholder : MonoBehaviour, IDropHandler
{
    public ManageCards mngc;
    public bool bgngn = false;
    public void OnDrop(PointerEventData eventData)
    {
        if (mngc.Deck.Count < 6 || !bgngn)
        {
            GameObject dropped = eventData.pointerDrag;
            dropped.GetComponent<Card>().parentAfterDrag = transform;
            if (bgngn)
            {
                GameObject.FindGameObjectWithTag("CardManager").GetComponent<ManageCards>().Deck.Remove(dropped);
            }
            else
            {
                GameObject.FindGameObjectWithTag("CardManager").GetComponent<ManageCards>().Deck.Add(dropped);
            }
        }
    }
}