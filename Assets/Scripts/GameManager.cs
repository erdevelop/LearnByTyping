using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Button addButton, showButton, clearAllButton, clearLastButton;
    [SerializeField] InputField newWordInputField, meanWordInputField;
    [SerializeField] Text newWordText, meanWordText, newWordListTextT, meanWordListTextT, wordListNumberTextT;
    [SerializeField] TMP_Text newWordListText, meanWordListText, wordListNumberText;

    List<string> newWordList = new List<string>();
    List<string> meanWordList = new List<string>();
    List<string> wordNumberList = new List<string>();

    string inputNewWord, inputMeanWord;

    int wordListNumber;

    [SerializeField] RectTransform rectTransform;
    float rectNewHeight;

    // Start is called before the first frame update
    void Start()
    {
        float currentRectHeight = rectTransform.rect.height;
        currentRectHeight = rectNewHeight;
        //rectTransform = GameObject.FindGameObjectWithTag("Content").GetComponent<RectTransform>();

        LoadWords();
        ShowList();
        DynamicRecTransform(currentRectHeight);
    }
    // Update is called once per frame
    void Update()
    { 
    }
    public void ShowDemo()
    {
        for (int i = 0; i < 100; i++)
        {
            int demo = 777333;
            demo++;
            newWordList.Add(demo.ToString());
            demo--;
            meanWordList.Add(demo.ToString());
            AddingWordListNumber();
        }
        for (int i = 0; i < 100; i++)
        {
            int demo = 33333;
            demo++;
            meanWordList.Add(demo.ToString());
        }
    }
    public void ShowList()
    {
        newWordListText.text = "";
        meanWordListText.text = "";
        wordListNumberText.text = "";

        foreach (string newword in newWordList)
        {
            newWordListText.text += $"\n{newword}";
        }
        foreach (string meanword in meanWordList)
        {
            meanWordListText.text += $"\n{meanword}";
        }
        foreach (string numberword in wordNumberList)
        {
            wordListNumberText.text += $"\n{numberword}";
        }
    }
    public void AddNewWordField()
    {
        inputNewWord = newWordInputField.text;
    }
    public void AddNewMeanField()
    {
        inputMeanWord = meanWordInputField.text;
    }
    public void AddingNewWordButton()
    {
        AddingNewWord();
        ShowList();
    }
    public void ShowListButton()
    {
        ShowList();
    }
    public void AddingWordListNumber()
    {
        wordListNumber++;
        wordNumberList.Add(wordListNumber.ToString());
    }
    public void DynamicRecTransform(float rectNewHeight)
    {
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rectNewHeight);
    }
    public void AddingNewWord()
    {
        if(newWordInputField.text != "" && meanWordInputField.text != "")
        {   
            //Debug.Log(rectTransform.rect.height);
            
            ShowNewwordText();
            AddListNewWord();
            AddingWordListNumber();

            DynamicRecTransform(rectNewHeight + 36.0f);

        }

        else
        {
            BlankWarning();
        }
        
        ClearInputField();
        SaveWords();
    }
    public void AddListNewWord()
    {
        newWordList.Add(inputNewWord);
        meanWordList.Add(inputMeanWord);

    }
    public void ShowNewwordText()
    {
        newWordText.text = inputNewWord;
        meanWordText.text = inputMeanWord;
    }
    public void ClearInputField()
    {
        newWordInputField.text = "";
        meanWordInputField.text = "";
    }
    public void BlankWarning()
    {
        newWordText.text = "Please enter new word...";
        meanWordText.text = "Please enter mean...";
    }
    public void ClearListAllButton()
    {
        newWordList.Clear();
        meanWordList.Clear();
        wordNumberList.Clear();
        wordListNumber = 0;
        SaveWords();
        LoadWords();
        ShowList();
        DynamicRecTransform(1064.0f);
    }
    public void ClearListLastButton()
    {
        newWordList.RemoveAt(newWordList.Count -1);
        meanWordList.RemoveAt(meanWordList.Count -1);
        wordNumberList.RemoveAt(wordNumberList.Count -1);
        wordListNumber--;
        SaveWords();
        LoadWords();
        ShowList();
        DynamicRecTransform(rectNewHeight - 36.0f);
    }
    //data save sytem Json format
    [System.Serializable]
    class SaveData
    {
        public List<string> newWordDataList;
        public List<string> meanWordDataList;
        public List<string> numberWordDataList;
        public float rectHeightData;
    }
    public void SaveWords()
    {
        SaveData data = new SaveData();
        data.newWordDataList = newWordList;
        data.meanWordDataList = meanWordList;
        data.numberWordDataList = wordNumberList;
        data.rectHeightData = rectNewHeight;

        string jsone = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsone);
    }
    public void LoadWords()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            newWordList = data.newWordDataList;
            meanWordList = data.meanWordDataList;
            wordNumberList = data.numberWordDataList;
            rectNewHeight = data.rectHeightData;
        }
    }
}
