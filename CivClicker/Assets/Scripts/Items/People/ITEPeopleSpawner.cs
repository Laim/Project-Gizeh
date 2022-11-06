using UnityEngine;

public class ITEPeopleSpawner : MonoBehaviour
{
    [SerializeField] private AvailablePeople PERSON;
    
    public Vector3 DEFAULT_SPAWN;
    public static ITEPeopleSpawner instance;

    public ITEPeopleSpawner()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Awake()
    {
        // not allowed to call gameObject in the constructor
        // have to call it in Awake or Start instead
        DEFAULT_SPAWN = gameObject.transform.position;
    }

    public void Spawn(string pos = null)
    {
        Vector3 spawnPos;

        if(pos == null)
        {
            spawnPos = new Vector3(-10.23f, -4.03f, 0f);
        } else
        {
            spawnPos = pos.StringToVector3();
        }

        Instantiate(PERSON.Random, position: spawnPos, new Quaternion(0, 0, 0f, 0));

        ScoreManager.instance.IncreasePlayerRate(1, this);
    }
}
