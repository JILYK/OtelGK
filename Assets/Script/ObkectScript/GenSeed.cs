using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenSeed : MonoBehaviour
{
    public GameObject Banks;
    public GameObject Bumaga;
    public GameObject Sumka;
    
    private System.Random rand = new System.Random();

    private List<GameObject> TrashList = new List<GameObject>();
    private void Start()
    {
        GameObject[] mass = new GameObject[3] { Banks, Bumaga, Sumka };
        int counterObject = rand.Next(3,7);
        print(counterObject + " counterObject");
        
        while (counterObject > TrashList.Count)
        {
            int random = rand.Next(3);
            GameObject clone = Instantiate( mass[random]);
            clone.transform.localScale = mass[random].gameObject.transform.localScale;
            clone.transform.position = new Vector3(Random.Range(6.12f, 10.26f), 7.78f, Random.Range(3.07f, 5.22f));
            print(clone.transform.position + " clone.transform.position");

            TrashList.Add(clone);


        }
            print(TrashList.Count + "WSEFWEGWSEGWERHG ");

        
    }
}
