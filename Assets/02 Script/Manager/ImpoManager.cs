using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EzDite
{
	public class ImpoManager : Singleton<ImpoManager>
    {
        public int age = 0;
        public float height;
        public float weight;
        public float bmi;
        public (int, float) goal;

        private void Start()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

