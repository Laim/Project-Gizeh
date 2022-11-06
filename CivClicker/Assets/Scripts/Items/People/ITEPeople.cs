using UnityEngine;

public class ITEPeople : MonoBehaviour
{
    private Vector3 END_LOCATION = new(9.14f, -4.03f, 0);

    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, END_LOCATION, 1.0f * Time.deltaTime);

        if(gameObject.transform.position == END_LOCATION)
        {
            // we use .DEFAULT_SPAWN so that when the game is loaded from a save
            // the person doesn't set their respawn to their saved last position
            // we instead push them back to the start where the people spawner is
            gameObject.transform.position = ITEPeopleSpawner.instance.DEFAULT_SPAWN;
        }
    }
}
