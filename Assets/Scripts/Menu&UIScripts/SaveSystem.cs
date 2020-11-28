using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem{

    public static void SavePlayer(PlayerHealth playerHealth)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.dat";
        FileStream stream = new FileStream(path, FileMode.Create);
        Debug.Log("Salvo com sucesso");

        PlayerData data = new PlayerData(playerHealth);
        

        formatter.Serialize(stream, data);
        stream.Close();

    }
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/save.dat";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
             Debug.Log("Carregado com sucesso");

           PlayerData data = formatter.Deserialize(stream) as PlayerData;
           stream.Close();

           return data;
        }else
        {
            Debug.LogError("Arquivo nao encontrado" + path);
            return null;
        }
    }
   
}
