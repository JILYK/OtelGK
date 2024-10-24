using MySql.Data.MySqlClient;
using UnityEngine;

public class BD_sql : MonoBehaviour
{
    private MySqlConnection con;

    private void Start()
    {
        con = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=mydb;Uid=root;Pwd=root;");
        try
        {
            con.Open();
        }
        catch (MySqlException ex) { print(ex.Message); }

        string strCmd = "INSERT INTO `users`(`name`, `surname`, `phone`,`email`,`login`,`password`,`roles`)" +
            "values ('3','32','3982','9832','2','2',2);";
        MySqlCommand cmd = new MySqlCommand(strCmd, con);
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (MySqlException ex) { print(ex.Message); }
    }

    private void OnApplicationQuit()
    {
        con.Dispose();
    }
}
