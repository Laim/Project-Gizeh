using UnityEngine;

public class ITEPeopleSpawner : MonoBehaviour
{
    [SerializeField] private AvailablePeople PERSON;
    [SerializeField] private Transform SPAWN_LOCATION;

    private int PEOPLE_SPAWNED;

    private void Update()
    {
        if (ScoreManager.instance.PLAYER_RATE_VALUE > 99 && PEOPLE_SPAWNED == 0)
        {
            Spawn();
            PEOPLE_SPAWNED++;
        }

        if (ScoreManager.instance.PLAYER_RATE_VALUE > 599 && PEOPLE_SPAWNED == 1)
        {
            Spawn();
            PEOPLE_SPAWNED++;
        }
    }

    void Spawn()
    {
        GameObject proj = Instantiate(PERSON.Random, SPAWN_LOCATION.position, new Quaternion(0, 0, 0f, 0));
        proj.transform.position = SPAWN_LOCATION.position;
    }
}
