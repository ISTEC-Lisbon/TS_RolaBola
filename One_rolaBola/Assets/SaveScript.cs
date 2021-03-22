using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class Record
{
    public string Nomejogador;
    public float tempo;

    public Record(float _tempo, string nomejogador)
    {
        this.tempo = _tempo;
        this.Nomejogador = nomejogador;
    }
}
public static class SaveScript
{
    static void SaveRecod(Record rec)
    {
        FileStream fileStream = null;
        try
        {
            string path = Application.persistentDataPath + "/record.rec";
            Debug.Log(path);
            fileStream = new FileStream(path, FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(fileStream, rec);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            throw;
        }
        finally
        {
            if (fileStream != null)
            {
                fileStream.Close();
            }
        }
    }

    static Record loadRecord()
    {
        Record rec = null;
        string path = Application.persistentDataPath + "/record.rec";
        FileStream fs = null;

        try
        {
            if (File.Exists(path))
            {
                fs = new FileStream(path, FileMode.Open);
                BinaryFormatter binary = new BinaryFormatter();
                rec = binary.Deserialize(fs) as Record;
            }
            else
            {
                rec = new Record(Mathf.Infinity, "Le Bot (˵ ͡° ͜ʖ ͡°˵)");
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            throw;
        }
        finally
        {
            fs?.Close(); //É o mesmo que fazer if(fs!=nul) fs.close()

        }
        return rec;
    }

    static void DeleteRecord()
    {
        string path = Application.persistentDataPath + "/record.rec";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
