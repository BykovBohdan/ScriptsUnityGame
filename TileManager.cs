//класс для дублирования корридора
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs; // массив коридоров
    private Transform playerTransform; // положение игрока 
    private float spawnZ = -6.0f; // начальная координата
    
    
    private float tileLength = 5.38f; //длина блока 382
    public int amnTileOnScreen = 1; // количество блоков
    private float safeZone = 4.0f; // дабы не убирался сектор по которому бежим
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles; // 
    // Use this for initialization
  private  void Start () {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // найти подключенный положение игрока
        for (int i =0; i < amnTileOnScreen; i++ ) {  //генерируем начальное количество коридоров
           
            if (i < 3)
            {
                SpawnTile(0); //что бы в начале бежать по пустому отсеку
            } else
            {
                SpawnTile();
            }
        } 
        
    }
	
	// Update is called once per frame
    private	void Update () {
        //каждый раз проверять, где находится игрок и если его положение приближается к последнему 
       
	if (playerTransform.position.z - safeZone > (spawnZ - amnTileOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }  //end if
    }

    private void SpawnTile (int prefabIndex = -1) // на будущее
    {
        GameObject go; //создали обьект
        if (prefabIndex == -1)
        {
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject; //клоны обьекта
        } else
        {
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        }
      //  go = Instantiate (tilePrefabs[RandomPrefabIndex()]) as GameObject; //создать клон блока
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ; //устанавливать блок в данной координате зет
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1 )
        {
            return 0;
        } //end if

        int randomIndex = lastPrefabIndex;

        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }  //end while

        lastPrefabIndex = randomIndex;

        return randomIndex;
    }

}
