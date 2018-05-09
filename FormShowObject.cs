using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SdkHarness
{
    public partial class FormShowObject : Form
    {
        public object SelectedObject { get; set; }

        public FormShowObject()
        {
            InitializeComponent();
        }

        public FormShowObject(object obj) : this()
        {
            TachyonPropertyEditor.AddCustomEditors(obj);

            this.SelectedObject = obj;
            this.propertyGrid1.SelectedObject = obj;

            this.Text = obj.GetType().Name;
        }

        private void FormShowObject_Load(object sender, EventArgs e)
        {
            Helpers.WindowState.RestoreWindowLocation(this);
        }

        private void FormShowObject_FormClosing(object sender, FormClosingEventArgs e)
        {
            Helpers.WindowState.SaveWindowLocation(this);
        }
    }
}
