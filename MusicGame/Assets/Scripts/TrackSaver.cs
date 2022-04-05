using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class TrackSaver
{
    public static void SaveTracks(Track track, int trackNumber) // trigger automatically on scene switch
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/track_" + trackNumber + ".txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        TrackData data = new TrackData(track);

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Tracks saved");
    }

    public static TrackData LoadTracks(int trackNumber) // have to clear the scene before loading so there are no duplicates, trigger automatically when opening tracks scene
    {
        string path = Application.persistentDataPath + "/track_" + trackNumber + ".txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            TrackData data = formatter.Deserialize(stream) as TrackData;
            stream.Close();

            Debug.Log("Tracks loaded");

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
