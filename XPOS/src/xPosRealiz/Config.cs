using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xPosRealiz_sprav_shues
{
    class Config
    {
        public static readonly string PathFile = Application.StartupPath;

        public static Settings ProgSettngs;

    }

    public class Settings
    {
        public List<int> IdTerminal { set; get; }
    }
}
