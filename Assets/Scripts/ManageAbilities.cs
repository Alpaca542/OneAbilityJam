using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class ManageAbilities : MonoBehaviour
{
    private Player player;
    public TMP_Text timerTxt;
    public ManageCards crdMng;
    public bool CanReroll = true;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && CanReroll)
        {
            reroll();
        }
    }
    void reroll()
    {
        GameObject[] activeCards = crdMng.ActiveCardList.ToArray();
        GameObject chosenCard = activeCards[Random.Range(0, activeCards.Length)];
        crdMng.ActiveCardList.Remove(chosenCard);
        string chosenAbility = chosenCard.GetComponent<Card>().myAbility;
        player.GetAbility(chosenAbility);
        CanReroll = false;
        StartCoroutine(TimerReroll());
    }
    IEnumerator TimerReroll()
    {
        timerTxt.text = "10";
        yield return new WaitForSeconds(1);
        timerTxt.text = "9";
        yield return new WaitForSeconds(1);
        timerTxt.text = "8";
        yield return new WaitForSeconds(1);
        timerTxt.text = "7";
        yield return new WaitForSeconds(1);
        timerTxt.text = "6";
        yield return new WaitForSeconds(1);
        timerTxt.text = "5";
        yield return new WaitForSeconds(1);
        timerTxt.text = "4";
        yield return new WaitForSeconds(1);
        timerTxt.text = "3";
        yield return new WaitForSeconds(1);
        timerTxt.text = "2";
        yield return new WaitForSeconds(1);
        timerTxt.text = "1";
        yield return new WaitForSeconds(1);
        timerTxt.text = "<b>R</b>";
        CanReroll = true;
        if(crdMng.ActiveCardList.Count == 0)
        {
            Time.timeScale = 0f;
            crdMng.AnimPanel.SetActive(true);
        }
    }
}
