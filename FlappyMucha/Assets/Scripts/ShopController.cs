using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class ShopController : MonoBehaviour
{
    public static ShopController instance;

    public int fly = 1;
    public int bee = 1;
    public int mosquito = 0;
    public int rock = 0;
    public int flar = 0;
    public int girl = 1;
    
    public int day = 1;
    public int night = 1;
    public int halloween= 1;
    public int graveyard = 1;
    public int ocean= 1;
    public int candyland = 1;

    public GameObject flyitem;
    public GameObject beeitem;
    public GameObject mosquitoitem;
    public GameObject rockitem;
    public GameObject flaritem;
    public GameObject girlitem;
    
    public GameObject dayitem;
    public GameObject nightitem;
    public GameObject graveyarditem;
    public GameObject halloweenitem;
    public GameObject oceanitem;

    private int[] intInfo;
    private GameObject[] goInfo;

    public TextMeshProUGUI backgroundsCoinInfo;
    public TextMeshProUGUI skinsCoinInfo;
    public TextMeshProUGUI musicCoinInfo;

    public int coins = 10000;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
        UpdateObtainedCoinsLabel();
        InitializeUnlockedItemsInfo();
        UnlockObtainedItems();
    }

    public void InitializeUnlockedItemsInfo()
    {
        intInfo = new int[] { fly, bee, mosquito, rock, flar, girl, day, night, halloween, graveyard, ocean };
        goInfo = new GameObject[] { flyitem, beeitem, mosquitoitem, rockitem, flaritem, girlitem, dayitem, nightitem, halloweenitem, graveyarditem, oceanitem };
    }

    public void UnlockObtainedItems()
    {
        //Debug.Log("siema");
        for (int i=0;i<intInfo.Length; i++)
        {
            //Debug.Log("petla sie wykonuje btw");
            if (intInfo[i] == 1)
            {
                //Debug.Log("a tu srodek");
                goInfo[i].transform.GetChild(0).gameObject.SetActive(false);
                goInfo[i].transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }

    public void AddCoin()
    {
        coins++;
        UpdateObtainedCoinsLabel();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateObtainedCoinsLabel();
    }

    public void RemoveCoins(int amount)
    {
        coins -= amount;
        UpdateObtainedCoinsLabel();
    }

    public void UpdateObtainedCoinsLabel()
    {
        skinsCoinInfo.text = coins.ToString();
        backgroundsCoinInfo.text = coins.ToString();
        musicCoinInfo.text = coins.ToString();
    }
}
