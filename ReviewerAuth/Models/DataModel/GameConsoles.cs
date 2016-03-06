using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewerAuth.Models
{
    public class GameConsoles
    {
        private int _id;
        private Game _gameid;
        private GameSystem _currentGameSystem;

        [Key]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int RefID { get; set; }

        [ForeignKey("RefID")]
        public virtual Game GameID
        {
            get { return _gameid; }
            set { _gameid = value; }
        }

        public GameSystem CurrentGameSystem
        {
            get { return _currentGameSystem; }
            set { _currentGameSystem = value; }
        }
    }
}
