using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Valve.VR;

public class Surface_1 : MonoBehaviour
{
    public Tilemap tilemap;
    const Tile cleanTile = null;
    public GameObject TRIGER_object;
    public GameObject MopPalka;
    public GameObject[] mop;
    Vector3[] mop_position_world = new Vector3[4];
    Vector3Int[] mop_position_cell = new Vector3Int[4];

   
    //14 1      48 31

         //31
   // 4
    //8
    private static Quaternion MopStartRotation;
    private static Vector3 MopStartPosition;

    public Rigidbody MopPalkaRb;

    public bool in_troger = false;

    public bool[,] cleanedTiles;

    void Start()
    {
        MopPalkaRb = MopPalka.GetComponent<Rigidbody>();
        cleanedTiles = new bool[tilemap.cellBounds.size.x, tilemap.cellBounds.size.y];
        MopStartRotation = MopPalka.transform.rotation;
        MopStartPosition = MopPalka.transform.position;

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "mop")
        {
           // print("---");
            TRIGER_object = null;
            in_troger = false; //разрешаем ложить в корзину
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "mop")
        {
            //print("!!!!!!!HISTKA");
            TRIGER_object = other.gameObject;
            in_troger = true; //разрешаем ложить в корзину
        }

    }
    void Update()
    {
        for (int i = 0; i < 4; i++)
        {

            // Получаем позицию объекта "швабры" и конвертируему в грид
            mop_position_world[i] = mop[i].transform.position;
            mop_position_cell[i] = tilemap.WorldToCell(mop_position_world[i]);
            
            //print(mop_position_world + "   --->    " + mop_position_cell);
            // Проверяем тип тайла на Tilemap
            if (tilemap.GetTile(mop_position_cell[i]) == !cleanTile && in_troger == true && TRIGER_object.gameObject.tag == "mop")
            {
                print("----!HISTKA");
                // Изменяем тип тайла на "чистый"
                tilemap.SetTile(mop_position_cell[i], cleanTile);

                // Обновляем массив cleanedTiles, чтобы сохранить прогресс мытья пола
                Config.mopChisti.Add(new Vector3Int( mop_position_cell[i].x, mop_position_cell[i].y,0));
            }
        }
        string vectorString = "";
        for (int i = 0; i < Config.mopChisti.Count; i++)
        {
            vectorString += Config.mopChisti[i].ToString();
            if (i < Config.mopChisti.Count - 1)
            {
                vectorString += ",";
            }
        }
        Debug.Log("GBGBGBGB " + vectorString);
    }

    public void NaMestoShvabra() 
    {
        MopPalkaRb.isKinematic = true;
        MopPalka.transform.position = MopStartPosition;
        MopPalka.transform.rotation = MopStartRotation;
        MopPalkaRb.isKinematic = false;
    }
}
