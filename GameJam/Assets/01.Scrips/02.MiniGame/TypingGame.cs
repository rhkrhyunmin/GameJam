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
    public TextMeshProUGUI[] selectedWordsTexts; // ������ �ܾ ��Ÿ�� UI Text �迭

    private List<string> selectedWords = new List<string>();
    private int currentIndex = 0;

    void Start()
    {
        // EnglishWord ��ũ��Ʈ���� �������� �ܾ� 8���� ������
        selectedWords = englishWord.GetRandomWords(15);

        // ������ �ܾ� ����Ʈ�� ����Ͽ� Ȯ��
        UpdateSelectedWordsText();
    }

    void UpdateSelectedWordsText()
    {
        // ��� �ؽ�Ʈ�� ��Ȱ��ȭ
        foreach (TextMeshProUGUI text in selectedWordsTexts)
        {
            text.gameObject.SetActive(false);
        }

        // ���õ� �ܾ���� UI Text �迭�� �Ҵ��Ͽ� ǥ��
        if (currentIndex < selectedWordsTexts.Length)
        {
            selectedWordsTexts[currentIndex].gameObject.SetActive(true); // ���� �ܾ Ȱ��ȭ
            selectedWordsTexts[currentIndex].text = selectedWords[currentIndex];
        }
    }

    void Update()
    {
        // ����ڰ� Ű�� ���� ������ ȣ��Ǵ� �޼���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string inputText = inputField.text;
            char keyPressed = inputText.Length > 0 ? inputText[0] : ' ';
            Debug.Log(keyPressed);
            CheckWord(keyPressed);
        }
    }

    // �Էµ� �ܾ �ùٸ��� ���ϴ� �޼���
    void CheckWord(char keyPressed)
    {
        // ���� ���� �ܾ�� ����ڰ� �Է��� �ܾ ��
        if (keyPressed == selectedWords[currentIndex][0])
        {
            Debug.Log("Matched: " + selectedWords[currentIndex]);
            inputField.text = ""; // �Է� �ʵ� �ʱ�ȭ
            currentIndex++; // ���� �ܾ�� �̵�

            // ���õ� �ܾ���� �ٽ� ǥ��
            UpdateSelectedWordsText();

            // ��� �ܾ ������ ��
            if (currentIndex == selectedWords.Count)
            {
                Debug.Log("All words matched!");
                SceneManager.LoadScene(3);
            }
        }
        else
        {
            Debug.Log("Mismatched: " + keyPressed);
            // ���� ���� �ܾ��� �ε����� ǥ��
            Debug.Log("Current Index: " + currentIndex);
        }
    }
}
