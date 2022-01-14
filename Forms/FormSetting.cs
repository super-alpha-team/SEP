using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.Forms
{
    public abstract class FormSetting
    {
        public String formTitle = "";
        public Size formSize = new Size();
    }

    public class FormSettingDefault : FormSetting
    {
        public FormSettingDefault()
        {
            this.formSize = new Size(200, 300);
            this.formTitle = "SEP Framework";
        }
    }
}
