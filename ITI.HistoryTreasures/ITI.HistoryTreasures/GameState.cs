﻿using System;
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
        XElement gamestate;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameState"/> class.
        /// </summary>
        public GameState(Game gctx)
        {
            _gCtx = gctx;
        }

        /// <summary>
        /// Saves the current game.
        /// </summary>
        public void SaveGame()
        {
            LCtx = GCtx.Check();
            TCtx = LCtx.Theme;

            gamestate = new XElement("GameState",
                new XElement("Theme", TCtx.Name),
                new XElement("Level", LCtx.Name)
                );
            gamestate.Save("./GameState.xml");

            Load();
        }

        /// <summary>
        /// Loads the previous party.
        /// </summary>
        /// <returns></returns>
        public string Load()
        {
            XmlTextReader xml = new XmlTextReader("GameState.xml");
            xml.Read();

            while (xml.Read())
            {
                if (xml.Name == "Level")
                {
                    xml.Read();
                    return xml.Value;
                }
            }

            return "";
        }

        /// <summary>
        /// Checks the current level.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">Not possible</exception>
        public List<Theme> Check()
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
                        return GCtx.Themes;
                    }
                }
            }
            throw new InvalidOperationException("Not possible");
        }

        /// <summary>
        /// </summary>
        /// <value>
        /// The game CTX.
        /// </value>
        public Game GCtx
        {
            get { return _gCtx; }
        }

        /// <summary>
        /// </summary>
        /// <value>
        /// The theme CTX.
        /// </value>
        public Theme TCtx
        {
            get { return _tCtx; }
            set { _tCtx = value; }
        }

        /// <summary>
        /// </summary>
        /// <value>
        /// The l CTX.
        /// </value>
        public Level LCtx
        {
            get { return _lCtx; }
            set { _lCtx = value; }
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

        public Game Game
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}
