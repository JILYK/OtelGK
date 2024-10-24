using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using UnityEngine.Tilemaps;

public class SurfaceChistka : MonoBehaviour
{
    private string connectionString = "Server=localhost;Database=mydb;Uid=root;Pwd=root;"; // Строка подключения к базе данных MySQL

    private int[,] array = new int[,] { { 1, 2 }, { 3, 4 } }; // Ваш двумерный массив

    public void SaveDataToMySQL()
    {
        MySqlConnection connection = new MySqlConnection(connectionString);

        try
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO surfaces (pol_surfaces) VALUES (@data)";
            command.Parameters.AddWithValue("@data", array);

            command.ExecuteNonQuery();

            Debug.Log("Данные успешно сохранены в MySQL");
        }
        catch (MySqlException ex)
        {
            Debug.Log("Ошибка при сохранении данных: " + ex.Message);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
    public void Test()
    {
        string vectorString = "";
        for (int i = 0; i < Config.mopChisti.Count; i++)
        {
            vectorString += Config.mopChisti[i].x.ToString()+","+ Config.mopChisti[i].y.ToString() +"," + "0";
            if (i < Config.mopChisti.Count - 1)
            {
                vectorString += ";";
            }
        }
        

        BDConnect.conn.Open();
        //cmd = new MySqlCommand("SELECT * FROM users", conn);
        BDConnect.cmd = new MySqlCommand($"INSERT INTO surfaces (pol_surfaces) VALUES ('{vectorString}');", BDConnect.conn);
        BDConnect.cmd.ExecuteNonQuery();
        //print("!!!!!!!!!");
        print("Занесли");

            print("Не совсем занесли");
        
        
        
        BDConnect.conn.Close();
    }

    public Tile RedAdminTile;
    public Tile GreenAdminTile;

    public void TestAdmin()
    {
        string valueBdSurface = "27,10,0;28,10,0;29,10,0;30,10,0;27,9,0;28,9,0;29,9,0;30,9,0;27,8,0;28,8,0;29,8,0;30,8,0;27,7,0;28,7,0;29,7,0;30,7,0;27,6,0;28,6,0;29,6,0;30,6,0;27,5,0;28,5,0;29,5,0;30,5,0;27,4,0;28,4,0;29,4,0;30,4,0;27,3,0;28,3,0;29,3,0;30,3,0;27,2,0;28,2,0;29,2,0;30,2,0;31,2,0;32,2,0;33,2,0;34,2,0;31,3,0;32,3,0;33,3,0;34,3,0;31,4,0;32,4,0;33,4,0;34,4,0;31,5,0;32,5,0;33,5,0;34,5,0;31,6,0;32,6,0;33,6,0;34,6,0;31,7,0;32,7,0;33,7,0;34,7,0;31,8,0;32,8,0;33,8,0;34,8,0;31,9,0;32,9,0;33,9,0;34,9,0;31,10,0;32,10,0;33,10,0;34,10,0;31,11,0;32,11,0;33,11,0;34,11,0;31,12,0;32,12,0;33,12,0;34,12,0;31,13,0;32,13,0;33,13,0;34,13,0;31,14,0;32,14,0;33,14,0;34,14,0;31,15,0;32,15,0;33,15,0;34,15,0;31,16,0;32,16,0;33,16,0;34,16,0;31,17,0;32,17,0;33,17,0;34,17,0;31,18,0;32,18,0;33,18,0;34,18,0;31,19,0;32,19,0;33,19,0;34,19,0;31,20,0;32,20,0;33,20,0;34,20,0;31,21,0;32,21,0;33,21,0;34,21,0;31,22,0;32,22,0;33,22,0;34,22,0;31,23,0;32,23,0;33,23,0;34,23,0;31,24,0;32,24,0;33,24,0;34,24,0;31,25,0;32,25,0;33,25,0;34,25,0;33,26,0;34,26,0;32,26,0;31,26,0;26,8,0;25,8,0;26,9,0;24,8,0;25,9,0;23,8,0;24,9,0;22,8,0;23,9,0;21,8,0;22,9,0;20,8,0;21,9,0;19,8,0;20,9,0;19,7,0;20,7,0;21,7,0;22,7,0;19,6,0;20,6,0;21,6,0;22,6,0;19,5,0;20,5,0;21,5,0;22,5,0;19,4,0;20,4,0;21,4,0;22,4,0;19,3,0;20,3,0;21,3,0;22,3,0;19,2,0;20,2,0";
        string[] vectorStrings = valueBdSurface.Split(';');

        // Создаем HashSet, чтобы быстро проверять, содержится ли определенная позиция в строке ValueBdSurface
        HashSet<Vector3Int> surfacePositions = new HashSet<Vector3Int>();
        foreach (string vectorString in vectorStrings)
        {
            string[] values = vectorString.Split(',');
            int x = int.Parse(values[0]);
            int y = int.Parse(values[1]);
            int z = int.Parse(values[2]);
            surfacePositions.Add(new Vector3Int(x, y, z));
        }
        Tilemap tilemap = this.GetComponent<Tilemap>();

        foreach (Vector3Int position in tilemap.cellBounds.allPositionsWithin)
        {
            if (!surfacePositions.Contains(position))
            {
                tilemap.SetTileFlags(position, TileFlags.None);
                tilemap.SetTile(position, RedAdminTile);
            }
            else
            {
                tilemap.SetTileFlags(position, TileFlags.None);
                tilemap.SetTile(position, GreenAdminTile);
            }
        }
    }
}

