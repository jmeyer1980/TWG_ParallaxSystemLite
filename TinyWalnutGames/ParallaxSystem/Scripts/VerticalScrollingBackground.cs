using System.Collections.Generic;
using UnityEngine;

namespace TinyWalnutGames.Parallax
{
	public class VerticalScrollingBackground : MonoBehaviour
	{
		[Tooltip("The prefab of the background that will be scrolled")]
		public GameObject BackgroundPrefab;

		[Tooltip("The speed at which the background scrolls")]
		public float ScrollSpeed = 1f;

		[Tooltip("The number of background instances to create")]
		public int PoolSize = 5;

		[Tooltip("The size of the gap between each background instance")]
		public float GapSize = 1f;

		[Tooltip("The offset to apply to the position of the background instances")]
		public Vector3 Offset = new Vector3(0, 0, 0);

		[Tooltip("The chance for a background instance to be transparent")]
		public float AlphaChance = 0.5f;

		// A queue to hold the background instances
		private Queue<GameObject> _backgrounds;

		// The height of the background instances
		private float _backgroundHeight;

		void Start()
		{
			// Initialize the queue
			_backgrounds = new Queue<GameObject>();

			// Get the height of the background prefab
			_backgroundHeight = BackgroundPrefab.GetComponent<SpriteRenderer>().bounds.size.y;

			// Create the background instances and add them to the queue
			for (int i = 0; i < PoolSize; i++)
			{
				GameObject background = Instantiate(BackgroundPrefab, new Vector3(BackgroundPrefab.transform.position.x, i * (_backgroundHeight + GapSize) + Offset.y, 0), Quaternion.identity, transform);
				_backgrounds.Enqueue(background);

				// Randomly make some of the backgrounds transparent
				var spriteRenderer = background.GetComponent<SpriteRenderer>();
				if (spriteRenderer != null)
				{
					spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Random.value > AlphaChance ? 1 : 0);
				}
			}

			// Hide the original background prefab
			var originalSpriteRenderer = BackgroundPrefab.GetComponent<SpriteRenderer>();
			if (originalSpriteRenderer != null)
			{
				originalSpriteRenderer.enabled = false;
			}
		}

		void Update()
		{
			// Get the position to reset the backgrounds to
			GameObject lastBackground = _backgrounds.Peek();
			Vector3 resetPosition = lastBackground.transform.position + Vector3.up * (_backgrounds.Count - 1) * (_backgroundHeight + GapSize);

			// Scroll the backgrounds
			Queue<GameObject> _backgroundsCopy = new Queue<GameObject>(_backgrounds);
			foreach (var background in _backgroundsCopy)
			{
				// Move the background
				background.transform.Translate(Vector3.down * ScrollSpeed * Time.deltaTime);

				// If the background has moved off the screen, reposition it to the reset position
				if (background.transform.position.y < -Camera.main.orthographicSize - _backgroundHeight - GapSize)
				{
					background.transform.position = resetPosition;
					_backgrounds.Enqueue(_backgrounds.Dequeue());
				}
			}
		}
	}	
}
