using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TypingGame : MonoBehaviour
{
    public EnglishWord englishWord;
    public TMP_InputField inputField;
    public TextMeshProUGUI[] selectedWordsTexts; // ������ �ܾ ��Ÿ�� UI Text �迭
    public ObjectManager _objectManager;

    private List<string> selectedWords = new List<string>();
    private int currentIndex = 0;
    private float startTime;
    public TextMeshProUGUI endingTXT;

    void Start()
    {
        // EnglishWord ��ũ��Ʈ���� �������� �ܾ� 8���� ������
        selectedWords = englishWord.GetRandomWords(15);

        // ������ �ܾ� ����Ʈ�� ����Ͽ� Ȯ��
        UpdateSelectedWordsText();

        endingTXT.gameObject.SetActive(false);
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
            _objectManager.MoveToNextObject();

            // ��� �ܾ ������ ��
            float elapsedTime = Time.time - startTime;
            if (currentIndex == selectedWords.Count)
            {
                if (elapsedTime <= 25)
                {
                    endingTXT.gameObject.SetActive(true);
                    endingTXT.text = "�� ���߾��!";
                    Invoke("LoadGreatJobScene", 2f);
                    GameManager.Instance.Score += 2;
                }
                else if (elapsedTime <= 45)
                {
                    endingTXT.gameObject.SetActive(true);
                    endingTXT.text = "���";
                    Invoke("LoadPassScene", 2f);
                    GameManager.Instance.Score++;
                }
                else
                {
                    endingTXT.gameObject.SetActive(true);
                    endingTXT.text = "�����";
                    Invoke("LoadRetakeScene", 2f);
                }
            }
        }
        else
        {
            Debug.Log("Mismatched: " + keyPressed);
            // ���� ���� �ܾ��� �ε����� ǥ��
            Debug.Log("Current Index: " + currentIndex);
        }
    }

    void LoadGreatJobScene()
    {
        SceneManager.LoadScene("03.TreeClimbScene");
    }

    void LoadPassScene()
    {
        SceneManager.LoadScene("03.TreeClimbScene");
    }

    void LoadRetakeScene()
    {
        SceneManager.LoadScene("02.TypeingTestScene");
    }
}
