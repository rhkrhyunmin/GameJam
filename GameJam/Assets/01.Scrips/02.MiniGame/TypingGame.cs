using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypingGame : MonoBehaviour
{
    public EnglishWord englishWord;
    public TMP_InputField inputField;
    public TextMeshProUGUI[] selectedWordsTexts; // 각각의 단어를 나타낼 UI Text 배열

    private List<string> selectedWords = new List<string>();
    private int currentIndex = 0;

    void Start()
    {
        // EnglishWord 스크립트에서 무작위로 단어 8개를 가져옴
        selectedWords = englishWord.GetRandomWords(15);

        // 가져온 단어 리스트를 출력하여 확인
        UpdateSelectedWordsText();
    }

    void UpdateSelectedWordsText()
    {
        // 모든 텍스트를 비활성화
        foreach (TextMeshProUGUI text in selectedWordsTexts)
        {
            text.gameObject.SetActive(false);
        }

        // 선택된 단어들을 UI Text 배열에 할당하여 표시
        if (currentIndex < selectedWordsTexts.Length)
        {
            selectedWordsTexts[currentIndex].gameObject.SetActive(true); // 현재 단어를 활성화
            selectedWordsTexts[currentIndex].text = selectedWords[currentIndex];
        }
    }

    void Update()
    {
        // 사용자가 키를 누를 때마다 호출되는 메서드
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string inputText = inputField.text;
            char keyPressed = inputText.Length > 0 ? inputText[0] : ' ';
            Debug.Log(keyPressed);
            CheckWord(keyPressed);
        }
    }

    // 입력된 단어가 올바른지 비교하는 메서드
    void CheckWord(char keyPressed)
    {
        // 현재 비교한 단어와 사용자가 입력한 단어를 비교
        if (keyPressed == selectedWords[currentIndex][0])
        {
            Debug.Log("Matched: " + selectedWords[currentIndex]);
            inputField.text = ""; // 입력 필드 초기화
            currentIndex++; // 다음 단어로 이동

            // 선택된 단어들을 다시 표시
            UpdateSelectedWordsText();

            // 모든 단어를 맞췄을 때
            if (currentIndex == selectedWords.Count)
            {
                Debug.Log("All words matched!");
                SceneManager.LoadScene(3);
            }
        }
        else
        {
            Debug.Log("Mismatched: " + keyPressed);
            // 현재 비교한 단어의 인덱스를 표시
            Debug.Log("Current Index: " + currentIndex);
        }
    }
}
