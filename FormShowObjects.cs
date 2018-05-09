using System;
using System.Collections;
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
    public partial class FormShowObjects : Form
    {
        public List<object> Collection { get; set; }
        private int currentItem = 0;
        public int CurrentItem
        {
            get { return currentItem; }
            set
            {
                currentItem = value;
                txtPositionItem.Text = currentItem.ToString();

                TachyonPropertyEditor.AddCustomEditors(Collection[currentItem - 1]);

                this.propertyGrid1.SelectedObject = Collection[currentItem - 1];
            }
        }

        public FormShowObjects()
        {
            InitializeComponent();
        }

        public FormShowObjects(IEnumerable ien) : this()
        {
            Collection = new List<object>();
            foreach (object item in ien)
            {
                Collection.Add(item);
            }

            lblCountItem.Text = string.Format("of {0}", Collection.Count);

            //this.propertyGrid1.SelectedObject = obj;
            if (Collection.Count > 0)
            {
                CurrentItem = 1;
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (CurrentItem < Collection.Count)
            {
                ++CurrentItem;
            }
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (CurrentItem > 1)
            {
                --CurrentItem;
            }
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (Collection.Count > 0)
            {
                CurrentItem = 1;
            }
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (Collection.Count > 0)
            {
                CurrentItem = Collection.Count;
            }
        }

        private void FormShowObjects_Load(object sender, EventArgs e)
        {
            Helpers.WindowState.RestoreWindowLocation(this);
        }

        private void FormShowObjects_FormClosing(object sender, FormClosingEventArgs e)
        {
            Helpers.WindowState.SaveWindowLocation(this);
        }
    }
}
