using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures
{
    class GameState
    {
        string _name;
        string _path;
        Game _gCtx;

        //level / theme en cours a sauvegarder
        //sauvegarde entre chaque niveau

        /// <summary>
        /// Initializes a new instance of the <see cref="GameState"/> class.
        /// </summary>
        /// <param name="gCtx">The g CTX.</param>
        /// <param name="name">The name.</param>
        public GameState(Game gCtx, string name)
        {
            _gCtx = gCtx;
            _name = name;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
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
