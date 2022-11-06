using System;
using System.Linq;
using System.Numerics;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    public void Load()
    {
        ClearExistingScene();

        LoadScore();

        LoadAutoClicker();

        LoadHouses();

        LoadPeople();

        ShopManager.instance.RefreshWindow();

        Debug.Log("loaded");
    }

    private void LoadHouses()
    {
        if(PlayerPrefs.HasKey("HouseCount"))
        {
            ShopManager.instance.CLICKER_HOUSE_COST = PlayerPrefs.GetFloat("HouseCost");
            ShopManager.instance.CLICKER_HOUSE_COUNT = PlayerPrefs.GetFloat("HouseCount");

            float c = PlayerPrefs.GetFloat("HouseCount", 0);

            if(c > 0)
            {
                for (float i = 0; i < c; i++)
                {
                    HouseSpawner.Instance.SpawnHouseSaveLoad(PlayerPrefs.GetString($"House_{i}"));
                }
            }
        }
    }

    private void LoadScore()
    {
        ScoreManager.instance.PLAYER_SCORE_VALUE = BigInteger.Parse(PlayerPrefs.GetString("PlayerScore"));
        //ScoreManager.instance.PLAYER_RATE_VALUE = float.Parse(PlayerPrefs.GetString("PlayerRate"));
    }

    private void LoadAutoClicker()
    {
        if (PlayerPrefs.HasKey("AutoClicker"))
        {
            ShopManager.instance.SHOP_OBJECTS.AUTOCLICKER.SetActive(true);

            ShopManager.instance.CLICKER_AUTO_COUNT = PlayerPrefs.GetFloat("AutoClickerCount", 0);
            ShopManager.instance.CLICKER_AUTO_COST = PlayerPrefs.GetFloat("AutoClickerCost", 0);
            ShopManager.instance.CLICKER_AUTO_VALUE = PlayerPrefs.GetFloat("AutoClickerValue", 0);

            ScoreManager.instance.IncreasePlayerRate(ShopManager.instance.CLICKER_AUTO_VALUE * ShopManager.instance.CLICKER_AUTO_COUNT, this);
        }
    }

    private void LoadPeople()
    {
        if (PlayerPrefs.HasKey("PeopleCount"))
        {
            // Get the saved people count
            float c = PlayerPrefs.GetFloat("PeopleCount", 0);

            // If we have more than 0 people, start spawning them back to where they last where
            if (c > 0)
            {
                for (float i = 0; i < c; i++)
                {
                    ITEPeopleSpawner.instance.Spawn(PlayerPrefs.GetString($"Person_{i}"));
                }
            }
        }
    }

    private void ClearExistingScene()
    {
        ScoreManager.instance.PLAYER_RATE_VALUE = 0;

        // Destroy any people already out there
        foreach (ITEPeople p in FindObjectsOfType<MonoBehaviour>().OfType<ITEPeople>())
        {
            Destroy(p.gameObject);
        }

        // Destroy any houses already out there
        foreach(ITEHouse h in FindObjectsOfType<MonoBehaviour>().OfType<ITEHouse>())
        {
            Destroy(h.gameObject);
        }
    }
}
