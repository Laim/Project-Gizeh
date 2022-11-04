using UnityEngine;

public class ITEPeople : MonoBehaviour
{
    private Vector3 START_LOCATION;
    private Vector3 END_LOCATION = new(9.14f, -4.03f, 0);

    private void Start()
    {
        START_LOCATION = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, END_LOCATION, 1.0f * Time.deltaTime);

        if(gameObject.transform.position == END_LOCATION)
        {
            gameObject.transform.position = START_LOCATION;
        }
    }
}
