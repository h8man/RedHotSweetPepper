using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class AudioManager: Singleton<AudioManager>
    {
        public AudioSource source;
        public void SetLevel(float sliderValue) {
            source.volume = sliderValue;
        }
    }
}
