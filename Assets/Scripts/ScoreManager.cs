using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int B_Points;
    private void Awake() {
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class SaveData{
        public int B_Points;
    }

    public void SaveScore(){
        SaveData score = new SaveData();
        score.B_Points = B_Points;
        string json = JsonUtility.ToJson(score);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore(){
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData score = JsonUtility.FromJson<SaveData>(json);
            B_Points = score.B_Points;
        }        
    }    
}
