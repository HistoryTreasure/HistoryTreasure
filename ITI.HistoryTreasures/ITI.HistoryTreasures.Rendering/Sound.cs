using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using ITI.HistoryTreasures.Rendering.Properties;

namespace ITI.HistoryTreasures.Rendering
{
    public class Sound : Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sound"/> class.
        /// </summary>
        /// 
        SoundPlayer _audio;
        string _levelName;
        bool _playMusic = false;

        public Sound()
        {
            _audio = new SoundPlayer(Resources.menu);
        }

        public void Play()
        {
            if (PlayMusic)
            {
                if (GetLevel == "1_1")
                {
                    _audio = new SoundPlayer(Resources.T1_1);
                }
                if (GetLevel == "1_2")
                {
                    _audio = new SoundPlayer(Resources.T1_2);
                }
                if (GetLevel == "1_3")
                {
                    _audio = new SoundPlayer(Resources.T1_3);
                }
                _audio.PlayLooping();
            }

        }

        public void Stop()
        {
            _audio.Stop();
        }

        public bool PlayMusic
        {
            get { return _playMusic; }
            set { _playMusic = value; }
        }

        public string GetLevel
        {
            get { return _levelName; }
            set { _levelName = value; }
        }
    }
}
