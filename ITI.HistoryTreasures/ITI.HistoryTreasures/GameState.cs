using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ITI.HistoryTreasures
{
    public class GameState
    {
        string _name;
        string _path;
        Game _gCtx;
        Theme _tCtx;
        Level _lCtx;

        //level / theme en cours a sauvegarder
        //sauvegarde entre chaque niveau

        /// <summary>
        /// Initializes a new instance of the <see cref="GameState"/> class.
        /// </summary>
        /// <param name="gCtx">The g CTX.</param>
        /// <param name="name">The name.</param>
        public GameState(Game gCtx, Theme tCtx, Level lCtx, string name)
        {
            _gCtx = gCtx;
            _tCtx = tCtx;
            _lCtx = lCtx;
            _name = name;
        }

        public void Save()
        {
            XElement game = new XElement("GameState",
                new XElement("Game", GCtx),
                new XElement("Theme", TCtx),
                new XElement("Level", LCtx)
                );
            game.Save("./GameState.xml");

            Load();
        }

        public string Load()
        {
            string save;
            XmlTextReader reader = new XmlTextReader("GameState.xml");
            reader.Read();

            while (reader.Read())
            {
                if (reader.Name == "Level")
                {
                    reader.Read();
                    return reader.Value;
                }
            }

            return "";
        }

        public Level Check()
        {
            foreach (Theme t in GCtx.Themes)
            {
                foreach (Level l in t.Levels)
                {
                    if (l.Name != Load())
                    {
                        l.IsFinish = true;
                    }
                    else
                    {
                        return l
                    }
                }
            }
            throw new InvalidOperationException("Not possible");
        }

        /// <summary>
        /// </summary>
        /// <value>
        /// The g CTX.
        /// </value>
        public Game GCtx
        {
            get { return _gCtx; }
        }

        /// <summary>
        /// </summary>
        /// <value>
        /// The t CTX.
        /// </value>
        public Theme TCtx
        {
            get { return _tCtx; }
        }

        /// <summary>
        /// </summary>
        /// <value>
        /// The l CTX.
        /// </value>
        public Level LCtx
        {
            get { return _lCtx; }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path
        {
            get { return _path; }
        }
    }
}
