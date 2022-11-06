using System;
using System.Linq;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public void Save()
    {
        PlayerPrefs.DeleteAll();

        SaveScore();

        SaveAutoClicker();

        SaveHouses();

        SavePeople();

        PlayerPrefs.Save();

        Debug.Log("Saved");
    }

    private void SaveHouses()
    {
        // Loop through all Houses that exist in the project and save their location
        int c = 0;
        foreach(ITEHouse h in FindObjectsOfType<MonoBehaviour>().OfType<ITEHouse>())
        {
            PlayerPrefs.SetString($"House_{c}", h.transform.position.ToString());
            PlayerPrefs.SetInt($"House_{c}_UpgradeLevel", h.UPGRADE_LEVEL);
            c++;
        }

        PlayerPrefs.SetFloat("HouseCount", ShopManager.instance.CLICKER_HOUSE_COUNT);
        PlayerPrefs.SetFloat("HouseCost", ShopManager.instance.CLICKER_HOUSE_COST);
    }

    private void SaveScore()
    {
        PlayerPrefs.SetString("PlayerScore", ScoreManager.instance.PLAYER_SCORE_VALUE.ToString());
        PlayerPrefs.SetString("PlayerRate", ScoreManager.instance.PLAYER_RATE_VALUE.ToString());
    }

    private void SaveAutoClicker()
    {
        if (ShopManager.instance.CLICKER_AUTO_COUNT > 0)
        {
            PlayerPrefs.SetInt("AutoClicker", 1);
            PlayerPrefs.SetFloat("AutoClickerCount", ShopManager.instance.CLICKER_AUTO_COUNT);
            PlayerPrefs.SetFloat("AutoClickerCost", ShopManager.instance.CLICKER_AUTO_COST);
            PlayerPrefs.SetFloat("AutoClickerValue", ShopManager.instance.CLICKER_AUTO_VALUE);
        }
    }

    private void SavePeople()
    {
        float c = 0;
        foreach (ITEPeople p in FindObjectsOfType<MonoBehaviour>().OfType<ITEPeople>())
        {
            PlayerPrefs.SetString($"Person_{c}", p.transform.position.ToString());
            c++;
        }

        PlayerPrefs.SetFloat("PeopleCount", c);
    }
}
