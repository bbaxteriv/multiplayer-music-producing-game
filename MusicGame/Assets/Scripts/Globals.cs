using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Globals
{
    public static int clickNumber;
    public static bool recordingsDeleted = false;
    public static List<TrackData> TrackList = new List<TrackData>();
    public static List<int> deletedTracks = new List<int>();
    public static float timer = 130f;
    public static string gameID;
    public static string playerID;
}
