using System.IO;
using UnityEngine;

namespace EndlessRunner.Utils
{
    public sealed class SaveGame
    {
        private static string gameStatsJsonName = "GameStatsData.json";

        public static void Save(GameStatsData data)
        {
            string dataPath = Path.Combine(Application.dataPath, gameStatsJsonName);
            string statsJson = JsonUtility.ToJson(data);
            File.WriteAllText(dataPath, statsJson);
        }

        public static GameStatsData Load()
        {
            string dataPath = Path.Combine(Application.dataPath, gameStatsJsonName);

            if(File.Exists(dataPath))
            {
                string save = File.ReadAllText(dataPath);
                GameStatsData statsData = JsonUtility.FromJson<GameStatsData>(save);
                return statsData;
            }

            return new GameStatsData();
        }
    }
}