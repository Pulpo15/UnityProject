using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomyManager : MonoBehaviour
{
    public Text MoneyTag;
    public Text AddedMoneyTag;

    public float money;

    public float addedMoneyTagTime = 4f;
    float curAddedMoneyTagTime;
    bool delayOn;


    void Start() {
        AddedMoneyTag.enabled = false;
    }

    void Update() {
        MoneyTag.text = money.ToString();
        curAddedMoneyTagTime -= Time.deltaTime;
        if(curAddedMoneyTagTime <= 0 && delayOn) {
            AddedMoneyTag.enabled = false;
            delayOn = false;
        }

    }

    public void AddMoney(float moneyToAdd) {
        money += moneyToAdd;
        AddedMoneyTag.enabled = true;
        AddedMoneyTag.color = new Color(0, 1, 0, 1);
        AddedMoneyTag.text = "+" + moneyToAdd.ToString();
        curAddedMoneyTagTime = addedMoneyTagTime;
        delayOn = true;
    }

    public void RemoveMoney(float moneyToRemove) {
        money -= moneyToRemove;
        AddedMoneyTag.enabled = true;
        AddedMoneyTag.color = new Color(1, 0, 0, 1);
        AddedMoneyTag.text = "-" + moneyToRemove.ToString();
        curAddedMoneyTagTime = addedMoneyTagTime;
        delayOn = true;
    }

    public void ShowCost(float cost) {
        AddedMoneyTag.enabled = true;
        AddedMoneyTag.color = new Color(1, 0, 0, 1);
        AddedMoneyTag.text = "-" + cost.ToString();
    }

    public void RemoveShowCost() {
        AddedMoneyTag.enabled = false;
    }
}
