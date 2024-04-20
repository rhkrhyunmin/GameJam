using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnglishWord", menuName = "SO/EnglishWord")]
public class EnglishWord : ScriptableObject
{
    public List<string> _englishWord;

    public List<string> GetRandomWords(int count)
    {
        // HashSet�� ����Ͽ� �ߺ��� �ܾ ����
        HashSet<string> selectedWordsSet = new HashSet<string>();

        // �ܾ� ����Ʈ���� �ߺ����� �ʴ� �ܾ���� �������� ����
        while (selectedWordsSet.Count < count)
        {
            int randomIndex = Random.Range(0, _englishWord.Count);
            selectedWordsSet.Add(_englishWord[randomIndex]);
        }

        // HashSet�� List�� ��ȯ�Ͽ� ��ȯ
        return new List<string>(selectedWordsSet);
    }
}
