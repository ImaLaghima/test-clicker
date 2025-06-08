using UnityEngine;

namespace TestClicker
{
	[DisallowMultipleComponent]
	public class DestroyAfterDelay : MonoBehaviour
	{
		[SerializeField]
		private float delay;

		void Start()
		{
			Destroy(gameObject, delay);
		}
	}
}
    