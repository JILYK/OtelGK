using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Config 
{

    public static GameObject BoxGarbage;
    public static GameObject BoxForgeting;

    public static  List<Vector3Int> mopChisti = new List<Vector3Int>();


    public static int[,] arraySurface = new int[31, 48];

    public static string Server = "127.0.0.1";
    public static string Port = "3306";
    public static string Database = "mydb";
    public static string Uid = "root";
    public static string Pwd = "root";


    public static string UserRole = "";
    public static string UserId = "";

}
