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
        SoundPlayer _audio;
        string _levelName;
        bool _playMusic = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sound"/> class.
        /// </summary>
        public Sound()
        {
            _audio = new SoundPlayer(Resources.menu);
        }

        /// <summary>
        /// Plays the correct sound according to the level in loop
        /// </summary>
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
                if (GetLevel == "2_1")
                {
                    _audio = new SoundPlayer(Resources.T2_1);
                }
                if (GetLevel == "2_2")
                {
                    _audio = new SoundPlayer(Resources.T2_2);
                }
                if (GetLevel == "2_3")
                {
                    _audio = new SoundPlayer(Resources.T2_3);
                }
                _audio.PlayLooping();
            }

        }

        /// <summary>
        /// Stop the current playing sound
        /// </summary>
        public void Stop()
        {
            _audio.Stop();
        }

        /// <summary>
        /// Mute the sound if set to false
        /// </summary>
        public bool PlayMusic
        {
            get { return _playMusic; }
            set { _playMusic = value; }
        }

        /// <summary>
        /// Return the name of the current level
        /// </summary>
        public string GetLevel
        {
            get { return _levelName; }
            set { _levelName = value; }
        }
    }
}
