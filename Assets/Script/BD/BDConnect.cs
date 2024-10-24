using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BDConnect 
{
    public static MySqlConnection conn;
    public static MySqlCommand cmd;
    public static void PuskConect()
    {
        conn = new MySqlConnection($"Server={Config.Server};" +
                                   $"Port={Config.Port};" +
                                   $"Database={Config.Database};" +
                                   $"Uid={Config.Uid};" +
                                   $"Pwd={Config.Pwd};");
        cmd = new MySqlCommand();
    }
}
