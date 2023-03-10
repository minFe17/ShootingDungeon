using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class WaveEnemyData : MonoBehaviour
{
    public List<stEnemyData> lstEnemyData = new List<stEnemyData>();

    void Start()
    {
        ReadEnemyData();
    }

    void ReadEnemyData()
    {
        string path = Application.dataPath + "/Resources/Datas/EnemyData.csv";
        if (File.Exists(path))
        {
            string source;
            using (StreamReader sr = new StreamReader(path))
            {
                string[] lines;
                source = sr.ReadToEnd();
                lines = Regex.Split(source, @"\r\n|\n\r|\n|\r");
                string[] header = Regex.Split(lines[0], ",");
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = Regex.Split(lines[i], ",");
                    if (values.Length == 0 || string.IsNullOrEmpty(values[0]))
                        continue;
                    stEnemyData temp = new stEnemyData();
                    temp.INDEX = int.Parse(values[0]);
                    temp.WAVE = int.Parse(values[1]);
                    temp.ZOMBIE = int.Parse(values[2]);
                    temp.RAPTOR = int.Parse(values[3]);
                    temp.PACHY = int.Parse(values[4]);
                    temp.TOTALENEMY = int.Parse(values[5]);

                    lstEnemyData.Add(temp);
                }
            }
        }
    }
}

public struct stEnemyData
{
    public int INDEX;
    public int WAVE;
    public int ZOMBIE;
    public int RAPTOR;
    public int PACHY;
    public int TOTALENEMY;
}