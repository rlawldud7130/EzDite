using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EzDite
{
	public class Singleton<T> : MonoBehaviour where T : Component
	{
		private static T _instance;

		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					T[] objs = Object.FindObjectsOfType(typeof(T)) as T[];

					if (objs.Length >= 1)
					{
						_instance = objs[0];

						for (int i = 1; i < objs.Length; ++i)
						{
							Debug.LogError("Singleton over " + typeof(T).Name);
							Destroy(objs[i].gameObject);
						}
					}
					else
					{
						var go = new GameObject(typeof(T).Name, typeof(T));
						_instance = go.GetComponent<T>();
					}

					_instance.SendMessage("OnInstance", null, SendMessageOptions.DontRequireReceiver);
				}

				return _instance;
			}

			protected set
			{
				if (!Application.isPlaying)
					return;

				_instance = value as T;
			}
		}
	}
}
