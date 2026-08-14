using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingController : MonoBehaviour
{
    public static SavingController instance;

    private void Start()
    {
        instance = this;
        LoadData();    
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("highscoreClassic", GameController.instance.highscoreClassic);
        PlayerPrefs.SetInt("highscoreTimeAttack", GameController.instance.highscoreTimeAttack);
        PlayerPrefs.SetInt("highscoreCrazy", GameController.instance.highscoreCrazy);
        PlayerPrefs.SetInt("highscoreCrazyTimeAttack", GameController.instance.highscoreCrazyTimeAttack);
        PlayerPrefs.SetInt("coins", 10000);
        
        PlayerPrefs.SetInt("day", ShopController.instance.day);
        PlayerPrefs.SetInt("night", ShopController.instance.night);
        PlayerPrefs.SetInt("graveyard", ShopController.instance.graveyard);
        PlayerPrefs.SetInt("halloween", ShopController.instance.halloween);
        PlayerPrefs.SetInt("ocean", ShopController.instance.ocean);
        PlayerPrefs.SetInt("candyland", ShopController.instance.candyland);
        
        PlayerPrefs.SetInt("fly", ShopController.instance.fly);
        PlayerPrefs.SetInt("bee", ShopController.instance.bee);
        PlayerPrefs.SetInt("mosquito", ShopController.instance.mosquito);
        PlayerPrefs.SetInt("rock", ShopController.instance.rock);
        PlayerPrefs.SetInt("flar", ShopController.instance.flar);
        PlayerPrefs.SetInt("girl", ShopController.instance.girl);

        PlayerPrefs.SetInt("timeAttackUnlocked", ModeUnlockController.instance.timeAttack);
        PlayerPrefs.SetInt("crazyUnlocked", ModeUnlockController.instance.crazy);
        PlayerPrefs.SetInt("timeAttackCrazyUnlocked", ModeUnlockController.instance.timeAttackCrazy);

        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        GameController.instance.highscoreClassic = PlayerPrefs.HasKey("highscoreClassic") ? PlayerPrefs.GetInt("highscoreClassic") : GameController.instance.highscoreClassic;
        GameController.instance.highscoreTimeAttack = PlayerPrefs.HasKey("highscoreTimeAttack") ? PlayerPrefs.GetInt("highscoreTimeAttack") : GameController.instance.highscoreTimeAttack;
        GameController.instance.highscoreCrazy = PlayerPrefs.HasKey("highscoreCrazy") ? PlayerPrefs.GetInt("highscoreCrazy") : GameController.instance.highscoreCrazy;
        GameController.instance.highscoreCrazyTimeAttack = PlayerPrefs.HasKey("highscoreCrazyTimeAttack") ? PlayerPrefs.GetInt("highscoreCrazyTimeAttack") : GameController.instance.highscoreCrazyTimeAttack;
        ShopController.instance.coins = 10000;

        ShopController.instance.day = PlayerPrefs.HasKey("day") ? PlayerPrefs.GetInt("day") : ShopController.instance.day;
        ShopController.instance.night = PlayerPrefs.HasKey("night") ? PlayerPrefs.GetInt("night") : ShopController.instance.night;
        ShopController.instance.graveyard = PlayerPrefs.HasKey("graveyard") ? PlayerPrefs.GetInt("graveyard") : ShopController.instance.graveyard;
        ShopController.instance.halloween = PlayerPrefs.HasKey("halloween") ? PlayerPrefs.GetInt("halloween") : ShopController.instance.halloween;
        ShopController.instance.ocean = PlayerPrefs.HasKey("ocean") ? PlayerPrefs.GetInt("ocean") : ShopController.instance.ocean;
        ShopController.instance.candyland = PlayerPrefs.HasKey("candyland") ? PlayerPrefs.GetInt("candyland") : ShopController.instance.candyland;

        ShopController.instance.fly = PlayerPrefs.HasKey("fly") ? PlayerPrefs.GetInt("fly") : ShopController.instance.fly;
        ShopController.instance.bee = PlayerPrefs.HasKey("bee") ? PlayerPrefs.GetInt("bee") : ShopController.instance.bee;
        ShopController.instance.mosquito = PlayerPrefs.HasKey("mosquito") ? PlayerPrefs.GetInt("mosquito") : ShopController.instance.mosquito;
        ShopController.instance.rock = PlayerPrefs.HasKey("rock") ? PlayerPrefs.GetInt("rock") : ShopController.instance.rock;
        ShopController.instance.flar = PlayerPrefs.HasKey("flar") ? PlayerPrefs.GetInt("flar") : ShopController.instance.flar;
        ShopController.instance.girl = PlayerPrefs.HasKey("girl") ? PlayerPrefs.GetInt("girl") : ShopController.instance.girl;

        ModeUnlockController.instance.timeAttack = PlayerPrefs.HasKey("timeAttackUnlocked") ? PlayerPrefs.GetInt("timeAttackUnlocked") : ModeUnlockController.instance.timeAttack;
        ModeUnlockController.instance.crazy = PlayerPrefs.HasKey("crazyUnlocked") ? PlayerPrefs.GetInt("crazyUnlocked") : ModeUnlockController.instance.crazy;
        ModeUnlockController.instance.timeAttackCrazy = PlayerPrefs.HasKey("timeAttackCrazyUnlocked") ? PlayerPrefs.GetInt("timeAttackCrazyUnlocked") : ModeUnlockController.instance.timeAttackCrazy;
    }

    public void ResetData()
    {
        PlayerPrefs.SetInt("highscoreClassic", 0);
        PlayerPrefs.SetInt("highscoreTimeAttack", 0);
        PlayerPrefs.SetInt("highscoreCrazy", 0);
        PlayerPrefs.SetInt("highscoreCrazyTimeAttack", 0);
        PlayerPrefs.SetInt("coins", 0);

        PlayerPrefs.SetInt("day", 0);
        PlayerPrefs.SetInt("night", 0);
        PlayerPrefs.SetInt("graveyard", 0);
        PlayerPrefs.SetInt("halloween", 0);
        PlayerPrefs.SetInt("ocean", 0);
        PlayerPrefs.SetInt("candyland", 0);

        PlayerPrefs.SetInt("fly", 0);
        PlayerPrefs.SetInt("bee", 0);
        PlayerPrefs.SetInt("mosquito", 0);
        PlayerPrefs.SetInt("rock", 0);
        PlayerPrefs.SetInt("flar", 0);
        PlayerPrefs.SetInt("girl", 0);

        PlayerPrefs.SetInt("timeAttackUnlocked", 0);
        PlayerPrefs.SetInt("crazyUnlocked", 0);
        PlayerPrefs.SetInt("timeAttackCrazyUnlocked", 0);

        PlayerPrefs.Save();
    }
}
