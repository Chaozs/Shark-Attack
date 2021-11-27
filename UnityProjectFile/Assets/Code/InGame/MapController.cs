using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private float defaultPosition = 18587f;
    public GameObject[] fishes;
    private float zSpawnRange = 18000f;
    private float xLeftMax = -420f;
    private float xRightMax = 420f;
    private List<GameObject> spawnedFishes = new List<GameObject>();

    // Start is called before the first frame update
    public void startMap()
    {
        InvokeRepeating("updatePosition", 0f, 1 / 120f); //updates map movement
        spawnRandomFish(200);
    }

    //map moves 1, 120 times per second
    void updatePosition()
    {
        Vector3 currentPosition = transform.localPosition;
        transform.localPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z -1);
    }

    private void checkReachedEnd(float distance)
    {
        if(distance >= 36000)
        {
            SendMessageUpwards("EndGame");
        }
    }

    public void resetPosition()
    {
        Vector3 currentPosition = transform.localPosition;
        transform.localPosition = new Vector3(currentPosition.x, currentPosition.y, 18587f);
        deleteAllFishes();
    }

    private void spawnRandomFish(int maxFish)
    {
        for(int i = 0; i < maxFish; i++)
        {

            GameObject currentFish = Instantiate(fishes[Random.Range(0, 3)]);
            currentFish.transform.SetParent(transform);
            currentFish.transform.localScale = new Vector3(100, 100, 100);
            currentFish.transform.localPosition = new Vector3(Random.Range(xLeftMax, xRightMax), 130, Random.Range(-zSpawnRange, zSpawnRange));

            Debug.Log("Adding fish" + i + "," + maxFish);
            spawnedFishes.Add(currentFish);
        }
    }
    private void deleteAllFishes()
    {
        foreach(GameObject fish in spawnedFishes)
        {
            Destroy(fish);
        }
    }


}
