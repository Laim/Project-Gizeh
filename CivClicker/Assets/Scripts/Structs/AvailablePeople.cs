using UnityEngine;
using System;

[Serializable]
public struct AvailablePeople
{
    public GameObject PERSON_01;
    public GameObject PERSON_02;
    public GameObject PERSON_03;
    public GameObject PERSON_04;
    public GameObject PERSON_05;

    private GameObject[] people;

    /// <summary>
    /// Returns a random prefab so its not the same person spawning constantly lol
    /// </summary>
    public GameObject Random
    {
        get
        {
            // lazy initialization of array
            if (people == null) people = new[] { PERSON_01, PERSON_02, PERSON_03, PERSON_04, PERSON_05 };

            // pick random
            return people[UnityEngine.Random.Range(0, people.Length)];
        }
    }
}
