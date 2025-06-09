using UnityEngine;
using System.IO;

namespace TestClicker
{
	[DisallowMultipleComponent]
	public class SaveManager : MonoBehaviour
	{
		#region DELETE

		/// <summary>
		/// Сначала описание методов, полей и свойств, потом теги
		/// </summary>

		// [SerializeField]       // +serialization, +inspector
		// [NonSerialized]        // -serialization, -inspector
		// [HideInInspector]      // -inspector
		// [Range(0.0f, 10.0f)]   // Range from 0 to 10
		// [Tooltip("Some Text")] // Adds tooltip on hover
		// [Space(10)]            // Vertical margin of 10px
		// [TextArea(3, 10)]      // TextArea of 3 to 10 rows
		// [ContextMenu("Add 10 to Some Value")] // Makes this method callable from Inspector
		// [Header("CustomHeader")] // Custom Header

		// Static Fields
		// Constants
		// Serialized Fields
		// Private Fields
		// Public Fields
		// Properties
		// Events & Delegates
		//
		// Constructors
		// Unity Lifecycle
		// Public Methods
		// Private Methods
		// Coroutines
		// Enums
		// Classes

		#endregion
		
		public static SaveManager Instance { get; private set; }

		

		[SerializeField]
		private string saveFileName = "savefile.json";

		private string _completePathToSaveFile;
		private bool _isSaveFound = false;
		private SaveData _saveData;

		public bool IsSaveFound
		{
			get => _isSaveFound;
			private set => _isSaveFound = value;
		}

		private void Awake()
		{
			if (Instance && Instance != this)
			{
				Destroy(gameObject);
				return;
			}
			Instance = this;
		}

		private void OnEnable()
		{
			_completePathToSaveFile = Application.persistentDataPath + saveFileName;
			if (File.Exists(_completePathToSaveFile))
			{
				string json = File.ReadAllText(_completePathToSaveFile);
				_saveData = JsonUtility.FromJson<SaveData>(json);
				IsSaveFound = true;
			}
			else
			{
				_saveData = new SaveData(0, 0, 0);
			}
		}

		public SaveData GetSaveData()
		{
			return _saveData;
		}

		public void SaveToFile(double coinBalance, double coinPerClick, double coinPerSecond)
		{
			SaveData dataToSave = new SaveData(coinBalance, coinPerClick, coinPerSecond);
			File.WriteAllText(_completePathToSaveFile, JsonUtility.ToJson(dataToSave));
		}
	}
}
