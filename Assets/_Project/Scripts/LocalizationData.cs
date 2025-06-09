using System.Collections.Generic;
using UnityEngine;

namespace TestClicker
{
    [CreateAssetMenu(fileName = "LocalizationData", menuName = "Scriptable Objects/LocalizationData")]
    public class LocalizationData : ScriptableObject
    {
        [SerializeField]
        private Sprite flagSprite;
        
        [SerializeField]
        private string englishLanguageName;
        
        [SerializeField]
        private string nativeLanguageName;

        [SerializeField]
        private List<LocalizationEntry> entries = new List<LocalizationEntry>();
        
        private Dictionary<string, string> _localizationDictionary = new Dictionary<string, string>();
        
        public string EnglishLanguageName => englishLanguageName;
        public string NativeLanguageName => nativeLanguageName;
        public Sprite FlagSprite => flagSprite;

        public void Setup()
        {
            _localizationDictionary.Clear();
            foreach (var entry in entries)
                if (!string.IsNullOrEmpty(entry.key) && !string.IsNullOrEmpty(entry.value))
                    _localizationDictionary.Add(entry.key, entry.value);
                else
                    Debug.LogError("Localization entry not found!");
        }
        
        public string GetLocalizedText(string key)
        {
            if (_localizationDictionary.TryGetValue(key, out string value))
                return value;
            
            Debug.LogError($"Key '{key}' not found in {englishLanguageName} localization data.");
            return key;
        }
    }

    [System.Serializable]
    public struct LocalizationEntry
    {
        public string key;
        public string value;
    }
    
}