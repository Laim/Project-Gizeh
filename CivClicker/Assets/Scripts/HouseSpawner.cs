using System.Linq;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{

    public AvailableHouses AVAILABLE_HOUSES;

    public static HouseSpawner Instance;

    public HouseSpawner()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void SpawnNewHouse()
    {
        // House spawn positions
        // Start: -10f;
        // End:    10f;

        int count = 0;
        foreach (IPurchaseItems house in FindObjectsOfType<MonoBehaviour>().OfType<IPurchaseItems>())
        {
            if (house.PurchaseTypes == PurchaseTypes.HOUSE)
            {
                count += 1;
            }
        }

        Vector3 spawnLocation = new(0f, 0f, 0f);

        // There is definitely a better way of doing this lol
        switch (count)
        {
            case 0:
                spawnLocation = new(-8f, -3.3f, 0f);
                break;
            case 1:
                spawnLocation = new(-6f, -3.3f, 0f);
                break;
            case 2:
                spawnLocation = new(-4f, -3.3f, 0f);
                break;
            case 3:
                spawnLocation = new(-2f, -3.3f, 0f);
                break;
            case 4:
                spawnLocation = new(0f, -3.3f, 0f);
                break;
            case 5:
                spawnLocation = new(2, -3.3f, 0f);
                break;
            case 6:
                spawnLocation = new(4f, -3.3f, 0f);
                break;
            case 7:
                spawnLocation = new(6f, -3.3f, 0f);
                break;
            case 8:
                spawnLocation = new(8f, -3.3f, 0f);
                break;
            case 9: // front line below
                spawnLocation = new(-9f, -3.7f, 0f);
                break;
            case 10: 
                spawnLocation = new(-7f, -3.7f, 0f);
                break;
            case 11:
                spawnLocation = new(-5f, -3.7f, 0f);
                break;
            case 12:
                spawnLocation = new(-3f, -3.7f, 0f);
                break;
            case 13:
                spawnLocation = new(-1f, -3.7f, 0f);
                break;
            case 14:
                spawnLocation = new(1f, -3.7f, 0f);
                break;
            case 15:
                spawnLocation = new(3f, -3.7f, 0f);
                break;
            case 16:
                spawnLocation = new(5f, -3.7f, 0f);
                break;
            case 17:
                spawnLocation = new(7f, -3.7f, 0f);
                break;
            case 18:
                spawnLocation = new(9f, -3.7f, 0f);
                break;
            default:
                break;
        }

        Instantiate(AVAILABLE_HOUSES.BASE_HOUSE, position: spawnLocation, rotation: Quaternion.identity);

        Debug.Log($"House Count: {count}");
    }
}
