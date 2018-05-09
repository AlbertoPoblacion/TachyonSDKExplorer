using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace SdkHarness
{
    public partial class ucParameter : UserControl
    {
        private ParameterInfo parameterInfo;
        public ParameterInfo ParameterInfo
        {
            get { return this.parameterInfo;  }
            set
            {
                this.parameterInfo = value;
                lblName.Text = parameterInfo.Name;
                cmdExpand.Visible = (this.ParameterInfo.ParameterType.FullName.Contains("Tachyon."));
                txtValue.Visible = !cmdExpand.Visible;
            }
        }

        private object receivedValue;
        public object Value
        {
            get
            {
                if (this.ParameterInfo.ParameterType.FullName.Contains("Tachyon."))
                {
                    return receivedValue;
                }

                return ParseTextValue(txtValue.Text);
            }

            set
            {
                receivedValue = value;
                txtValue.Text = value.ToString();
            }
        }

        public ucParameter()
        {
            InitializeComponent();
        }

        public ucParameter(ParameterInfo pi) : this()
        {
            this.ParameterInfo = pi;
        }

        private object ParseTextValue(string text)
        {
            if (this.ParameterInfo.ParameterType.IsAssignableFrom(typeof(int)))
            {
                return int.Parse(text);
            }
            else if (this.ParameterInfo.ParameterType.IsAssignableFrom(typeof(string)))
            {
                return text;
            }
            else if (this.ParameterInfo.ParameterType.IsAssignableFrom(typeof(double)))
            {
                return double.Parse(text);
            }
            else if (this.ParameterInfo.ParameterType.IsAssignableFrom(typeof(bool)))
            {
                return bool.Parse(text);
            }
            else if (this.ParameterInfo.ParameterType.IsAssignableFrom(typeof(DateTime)))
            {
                return DateTime.Parse(text);
            }

            MessageBox.Show(string.Format("Unsupported parameter type {0} for parameter '{1}'", this.ParameterInfo.ParameterType.Name, this.ParameterInfo.Name));

            return null;
        }

        private void cmdExpand_Click(object sender, EventArgs e)
        {
            Type t = this.ParameterInfo.ParameterType;
            object obj = Activator.CreateInstance(t);
            FormShowObject frm = new FormShowObject(obj);
            DialogResult res = frm.ShowDialog();
            if (res != DialogResult.Cancel)
            {
                this.Value = frm.SelectedObject;
            }

            frm.Dispose();
        }
    }
}
