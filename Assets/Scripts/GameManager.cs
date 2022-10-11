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
    [SerializeField] RectTransform rectTransform;

    List<string> newWordList = new List<string>();
    List<string> meanWordList = new List<string>();
    List<string> wordNumberList = new List<string>();

    string inputNewWord, inputMeanWord;

    int wordListNumber;

    float rectLastHeight;

    float rectMultiply = 40.0f;
    float rectDefault = 1064.0f;
    // Start is called before the first frame update
    void Start()
    {
        
        LoadWords();
        DynamicRecTransform((newWordList.Count * rectMultiply) + 1064.0f);
        ClearListsText();
        ShowList();
        SaveWords();

    }
    // Update is called once per frame
    void Update()
    { 
    }

    public void ShowDemo()
    {
        MostUsing100();
        DynamicRecTransform((newWordList.Count * rectMultiply) + rectDefault);
        for (int i = 0; i < 99; i++)
        {
            AddingWordListNumber();

        }
        ClearListsText();
        ShowList();
        SaveWords();
    }
    public void MostUsing100()
    {
        newWordList.Add("A"); meanWordList.Add("herhangi bir");
        newWordList.Add("About"); meanWordList.Add("hakkında, dair, üzere");
        newWordList.Add("After"); meanWordList.Add("sonra, ertesi");
        newWordList.Add("All"); meanWordList.Add("Tüm, bütün, hepsi");
        newWordList.Add("Also"); meanWordList.Add("ayrıca, da");
        newWordList.Add("An"); meanWordList.Add("herhangi bir (sesli harf");
        newWordList.Add("And"); meanWordList.Add("ve");
        newWordList.Add("Any"); meanWordList.Add("hiç, herhangi");
        newWordList.Add("As"); meanWordList.Add("olarak, gibi, kadar");
        newWordList.Add("At"); meanWordList.Add("üzere, nezdinde, saatinde");
        newWordList.Add("Because"); meanWordList.Add("çünkü");
        newWordList.Add("Back"); meanWordList.Add("arka, geri");
        newWordList.Add("Be"); meanWordList.Add("olmak, varolmak");
        newWordList.Add("But"); meanWordList.Add("ama, fakat");
        newWordList.Add("By"); meanWordList.Add("tarafından, itibarıyla");
        newWordList.Add("Can"); meanWordList.Add("olabilmek, yapabilmek");
        newWordList.Add("Come"); meanWordList.Add("gelmek");
        newWordList.Add("Could"); meanWordList.Add("yapabilmek, geçmişte");
        newWordList.Add("Day"); meanWordList.Add("gün");
        newWordList.Add("Do"); meanWordList.Add("yapmak, etmek");
        newWordList.Add("Even"); meanWordList.Add("bile, hatta, çift");
        newWordList.Add("First"); meanWordList.Add("birinci, ilk, başlangıç");
        newWordList.Add("For"); meanWordList.Add("için, dair, yönünden");
        newWordList.Add("From"); meanWordList.Add("istinaden, beri, -den, -dan");
        newWordList.Add("Get"); meanWordList.Add("almak, edinmek, kazanmak");
        newWordList.Add("Give"); meanWordList.Add("vermek, getimek");
        newWordList.Add("Go"); meanWordList.Add("gitmek, çıkmak, başlamak");
        newWordList.Add("Good"); meanWordList.Add("iyi, güzel, fayda");
        newWordList.Add("Have"); meanWordList.Add("sahip olmak");
        newWordList.Add("He"); meanWordList.Add("O(erkekler için)");
        newWordList.Add("Her"); meanWordList.Add("onun, ona");
        newWordList.Add("Him"); meanWordList.Add("Ona, onu");
        newWordList.Add("His"); meanWordList.Add("onun, ona ait");
        newWordList.Add("How"); meanWordList.Add("nasıl");
        newWordList.Add("I"); meanWordList.Add("ben");
        newWordList.Add("If"); meanWordList.Add("eğer, rağmen, sözde");
        newWordList.Add("In"); meanWordList.Add("içeri, iç, içinde");
        newWordList.Add("Into"); meanWordList.Add("içine, içeriye,-in içine");
        newWordList.Add("It"); meanWordList.Add("O, ona");
        newWordList.Add("Its"); meanWordList.Add("onun");
        newWordList.Add("Just"); meanWordList.Add("şimdi, sadece, az önce");
        newWordList.Add("Know"); meanWordList.Add("bilmek, öğrenmek, tanımak");
        newWordList.Add("Like"); meanWordList.Add("sevmek, beğenmek, benzemek");
        newWordList.Add("Look"); meanWordList.Add("bakmak, görünmek, gürünüş");
        newWordList.Add("Make"); meanWordList.Add("yapmak, etmek, sağlamak");
        newWordList.Add("Me"); meanWordList.Add("bende, bana, benim");
        newWordList.Add("Most"); meanWordList.Add("en, en çok, çoğu");
        newWordList.Add("My"); meanWordList.Add("benim");
        newWordList.Add("New"); meanWordList.Add("yeni");
        newWordList.Add("No"); meanWordList.Add("hayır, yok, ret, hiç");
        newWordList.Add("Not"); meanWordList.Add("yuok, değil, asla");
        newWordList.Add("Now"); meanWordList.Add("şimdi, şu an, şimdiye ait");
        newWordList.Add("Of"); meanWordList.Add("-li, ilişkili, bağlantılı");
        newWordList.Add("On"); meanWordList.Add("üzerinde, çalışır, hazır");
        newWordList.Add("One"); meanWordList.Add("bir, tek, biri");
        newWordList.Add("Only"); meanWordList.Add("sadece, tek, sırf, yalnızca");
        newWordList.Add("Or"); meanWordList.Add("ya da, veya");
        newWordList.Add("Other"); meanWordList.Add("diğer, başka, öteki");
        newWordList.Add("Our"); meanWordList.Add("bizim");
        newWordList.Add("Out"); meanWordList.Add("çıkış, dışarıda, dış,");
        newWordList.Add("Over"); meanWordList.Add("fazla, bitmiş, üzerine,");
        newWordList.Add("Part"); meanWordList.Add("kısım, bölüm");
        newWordList.Add("People"); meanWordList.Add("insanlar, halk, millet");
        newWordList.Add("Say"); meanWordList.Add("söylemek, demek");
        newWordList.Add("See"); meanWordList.Add("görmek, anlamak");
        newWordList.Add("So"); meanWordList.Add("böylece, bu yüzden, demek ki");
        newWordList.Add("Some"); meanWordList.Add("biraz, bazı, birkaç");
        newWordList.Add("Take"); meanWordList.Add("almak, foto çekmek, götürmek");
        newWordList.Add("Than"); meanWordList.Add("-dan, -e göre, hariç, nazaran");
        newWordList.Add("Then"); meanWordList.Add("o halde, öyleyse, o zamanlar");
        newWordList.Add("That"); meanWordList.Add("Şu");
        newWordList.Add("The"); meanWordList.Add("bilindik, bilinen");
        newWordList.Add("Their"); meanWordList.Add("onların");
        newWordList.Add("There"); meanWordList.Add("Ora, orada, şura, şuradaki");
        newWordList.Add("These"); meanWordList.Add("bunlar");
        newWordList.Add("Them"); meanWordList.Add("onlara, onları");
        newWordList.Add("They"); meanWordList.Add("Onlar");
        newWordList.Add("Think"); meanWordList.Add("düşünmek, sanmak");
        newWordList.Add("This"); meanWordList.Add("bu, buradaki");
        newWordList.Add("Time"); meanWordList.Add("zaman, süre, kere");
        newWordList.Add("To"); meanWordList.Add("ismin yönelme hali");
        newWordList.Add("Two"); meanWordList.Add("iki");
        newWordList.Add("Up"); meanWordList.Add("yukarı, artış, çıkış, yüksekte");
        newWordList.Add("Use"); meanWordList.Add("kullanmak, fayadalanmak");
        newWordList.Add("Want"); meanWordList.Add("istemek, arzulamak");
        newWordList.Add("Way"); meanWordList.Add("yol");
        newWordList.Add("Well"); meanWordList.Add("iyi, kaynak(su vb.), kuyu");
        newWordList.Add("What"); meanWordList.Add("ne, neyi, cisim, şey");
        newWordList.Add("When"); meanWordList.Add("ne zaman");
        newWordList.Add("Which"); meanWordList.Add("hangi, hangisi");
        newWordList.Add("Who"); meanWordList.Add("kim");
        newWordList.Add("With"); meanWordList.Add("ile, birlikte, nedeniyle");
        newWordList.Add("Will"); meanWordList.Add("Gelecek zaman kipi, irade");
        newWordList.Add("We"); meanWordList.Add("Biz");
        newWordList.Add("Work"); meanWordList.Add("çalışmak, iş, eser");
        newWordList.Add("Would"); meanWordList.Add("Koşullu dilek, -ecekti");
        newWordList.Add("Year"); meanWordList.Add("yıl, sene, yaş");
        newWordList.Add("You"); meanWordList.Add("Sen, siz, sana, size");
        newWordList.Add("Your"); meanWordList.Add("senin, sizin");
    }
    public void ClearListsText()
    {
        newWordListText.text = "";
        meanWordListText.text = "";
        wordListNumberText.text = "";
    }
    public void ShowList()
    {
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
        ClearListsText();
        ShowList();
        
    }
    public void ShowListButton()
    {
        ClearListsText();
        ShowList();
    }
    public void AddingWordListNumber()
    {
        wordListNumber++;
        wordNumberList.Add(wordListNumber.ToString());
    }
    public void DynamicRecTransform(float recNewCalc)
    {
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, recNewCalc);
    }
    public void AddingNewWord()
    {
        if(newWordInputField.text != "" && meanWordInputField.text != "")
        {   
            ShowNewwordText();
            AddListNewWord();
            AddingWordListNumber();
            DynamicRecTransform(rectTransform.rect.height + rectMultiply);
            SaveWords();
        }

        else
        {
            BlankWarning();
        }
        
        ClearInputField();
        
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
        DynamicRecTransform(rectDefault);
        SaveWords();
        LoadWords();
        ClearListsText();
        ShowList();
        
    }
    public void ClearListLastButton()
    {
        if(newWordList.Count != 0 || meanWordList.Count != 0)
        {
            newWordList.RemoveAt(newWordList.Count -1);
            meanWordList.RemoveAt(meanWordList.Count -1);
            wordNumberList.RemoveAt(wordNumberList.Count -1);
            wordListNumber--;
            DynamicRecTransform(rectTransform.rect.height - rectMultiply);
            SaveWords();
            LoadWords();
            ClearListsText();
            ShowList();
        }
        else
        {
            BlankWarning();
        }
        
    }
    //data save sytem Json format
    [System.Serializable]
    class SaveData
    {
        public List<string> newWordDataList;
        public List<string> meanWordDataList;
        public List<string> numberWordDataList;
        public float rectHeightData;
        public int wordListNumberData;
    }
    public void SaveWords()
    {
        SaveData data = new SaveData();
        data.newWordDataList = newWordList;
        data.meanWordDataList = meanWordList;
        data.numberWordDataList = wordNumberList;
        data.rectHeightData = rectLastHeight;
        data.wordListNumberData = wordListNumber;

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
            rectLastHeight = data.rectHeightData;
            wordListNumber = data.wordListNumberData;
        }
    }
}
