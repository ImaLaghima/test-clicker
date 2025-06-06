using System.Collections.Generic;
using UnityEngine;

namespace TestClicker
{
    [DisallowMultipleComponent]
    public class LocalizationManager : MonoBehaviour
    {
        public static LocalizationManager Instance { get; private set; }

        [SerializeField]
        private string defaultLanguage = "English"; 

        [SerializeField]
        private List<LocalizationData> localizationList;
        
        private Dictionary<string, LocalizationData> _localizationDictionary;
        
        private LocalizationData _englishLanguageData;
        private LocalizationData _currentLanguageData;

        void Awake()
        {
            if (Instance && Instance != this)
            {
                Destroy(gameObject);
                return;                
            }
            Instance = this;
            
            SetupLocalizations();
            SetLanguage(defaultLanguage);
        }

        public void SetLanguage(string languageName)
        {
            if (_localizationDictionary.TryGetValue(languageName, out var value))
                _currentLanguageData = value;
            else
            {
                Debug.LogError($"Language {languageName} Not Found");
                _currentLanguageData = null;
            }
        }

        public string GetLocalizedText(string key)
        {
            if (_currentLanguageData)
            {
                string result = _currentLanguageData.GetLocalizedText(key);
                if (result != key)
                    return result;
            }
            
            return _englishLanguageData.GetLocalizedText(key);
        }

        private void SetupLocalizations()
        {
            _localizationDictionary = new Dictionary<string, LocalizationData>();
            foreach (LocalizationData data in localizationList)
                if (data)
                {
                    data.Setup();
                    _localizationDictionary[data.EnglishLanguageName] = data;
                    if (data.EnglishLanguageName.ToLower() == "english")
                        _englishLanguageData = data;
                }
        }
    }
}
