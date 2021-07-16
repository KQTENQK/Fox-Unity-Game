using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class PlayerContext
{
    public List<string> BuyedHeroesName = new List<string>();
    public string SelectedHero;
    public int Balance;
    public int BestScore;
}

public abstract class Data : MonoBehaviour
{
    [NonSerialized] public PlayerContext ctx;

    protected string PathToJson;

    private string _key = "bfweSFEFfBfFDVD.VDSFFFEsfrefre.egGGRGFDFEKMLLOFEWss.hFhrg";

    protected void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        PathToJson = Path.Combine(Application.persistentDataPath, "Progress.json");
#else
        PathToJson = Path.Combine(Application.dataPath, "Progress.json");
#endif
        if (!File.Exists(PathToJson))
        {
            string initialHero = "Fox";

            PlayerContext initialPlayerContext = new PlayerContext()
            {
                Balance = 0,
                BuyedHeroesName = new List<string>(),
                SelectedHero = initialHero,
                BestScore = 0
            };

            initialPlayerContext.BuyedHeroesName.Add(initialHero);
            ctx = initialPlayerContext;

            Write(initialPlayerContext);
        }
        else
        {
            ctx = new PlayerContext();
            ctx = JsonUtility.FromJson<PlayerContext>(Read());
        }
    }

    protected void Write(PlayerContext context)
    {
        string gamma = _key;
        string data = Transcriptor.Encode(JsonUtility.ToJson(context), gamma);
        File.WriteAllText(PathToJson, data);
    }

    protected string Read()
    {
        string gamma = _key;
        string data = Transcriptor.Decode(File.ReadAllText(PathToJson), gamma);
        return data;
    }

    protected void OnApplicationPause(bool pause)
    {
        Write(ctx);
    }
}
