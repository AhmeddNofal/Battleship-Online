using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class Player
    {
        public List<string> Ships = new List<string>();
        public int Score { get; set; }

        public bool turn { get; set; }
        
    }
}
