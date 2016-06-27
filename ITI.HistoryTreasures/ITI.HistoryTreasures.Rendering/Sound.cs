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
        public Sound()
        {
            SoundPlayer audio = new SoundPlayer(Resources.audio);
            //audio.Play();
        }
    }
}
