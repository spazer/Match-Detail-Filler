using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match_Detail_Filler
{
    class DoublesBoxAssociation
    {
        public ComboBox player;
        public List<TextBox> charList;
        public List<TextBox> scoreList;

        public DoublesBoxAssociation()
        {
            charList = new List<TextBox>();
            scoreList = new List<TextBox>();
        }
    }
}
