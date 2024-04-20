using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnglishWord", menuName = "SO/EnglishWord")]
public class EnglishWord : ScriptableObject
{
    public List<string> _englishWord;

    public List<string> GetRandomWords(int count)
    {
        // HashSet을 사용하여 중복된 단어를 방지
        HashSet<string> selectedWordsSet = new HashSet<string>();

        // 단어 리스트에서 중복되지 않는 단어들을 무작위로 선택
        while (selectedWordsSet.Count < count)
        {
            int randomIndex = Random.Range(0, _englishWord.Count);
            selectedWordsSet.Add(_englishWord[randomIndex]);
        }

        // HashSet을 List로 변환하여 반환
        return new List<string>(selectedWordsSet);
    }
}
