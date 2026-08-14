using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public int itemPrice = 10;
    public bool bougth = false;

    public GameObject notBoughtGO;
    public GameObject BoughtGO;

    private AudioSource audioSource;
    public AudioClip buySound;
    public AudioClip deniedBuySound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Unlock()
    {
        if (bougth)
            return;

        if (ShopController.instance.coins >= itemPrice)
        {
            ShopController.instance.RemoveCoins(itemPrice);

            // ustawienie klucza zakupu na podsatwie nazwy itemu
            string itemName = transform.parent.name.ToLower();
            Debug.Log(itemName);    

            FieldInfo field = typeof(ShopController).GetField(itemName);
            field.SetValue(ShopController.instance, 1);

            bougth = true;

            if (SoundController.instance.effectsActive)
            {
                GameObject go = new GameObject();
                go.AddComponent<AudioSource>().clip = buySound;
                go.AddComponent<Suicider>();

                Instantiate(go);
            }
                
            
            notBoughtGO.SetActive(false);
            BoughtGO.SetActive(true);
        }
        else
        {
            audioSource.clip = deniedBuySound;
            audioSource.Play();
        }

        SavingController.instance.SaveData();
    }
}
