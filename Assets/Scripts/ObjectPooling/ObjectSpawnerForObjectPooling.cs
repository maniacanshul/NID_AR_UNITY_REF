using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerForObjectPooling : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private int numberOfObjectsToSpawn;
    [SerializeField] private int numberOfObjectsToUse;

    private List<GameObject> objectsBeingUsed = new List<GameObject>();
    private List<GameObject> unusedObjects = new List<GameObject>();
    private void Start()
    {
        SpawnEntities();
    }

    private void SpawnEntities()
    {
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            GameObject temp = Instantiate(prefabToSpawn, Vector3.zero, Quaternion.identity) as GameObject;
            temp.name = i.ToString();
            temp.SetActive(false);
            unusedObjects.Add(temp);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObjects();
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DespawnObjects();
        }
    }

    private void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjectsToUse; i++)
        {
            if (unusedObjects.Count <= 0)
            {
                SpawnEntities();
            }

            GameObject temp = unusedObjects[0];

            temp.SetActive(true);
            unusedObjects.RemoveAt(0);
            objectsBeingUsed.Add(temp);
        }
    }

    private void DespawnObjects()
    {
        for (int i = objectsBeingUsed.Count - 1; i >= 0; i--)
        {
            GameObject temp = objectsBeingUsed[i];
            temp.SetActive(false);
            objectsBeingUsed.RemoveAt(i);
            unusedObjects.Add(temp);
        }
    }
}
