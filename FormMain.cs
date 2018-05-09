using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using SdkHarness.Models;

namespace SdkHarness
{
    public partial class FormMain : Form
    {
        Tachyon.SDK.Consumer.TachyonConnector connector = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Helpers.WindowState.RestoreWindowLocation(this);

            Type apiBaseType = typeof(Tachyon.SDK.Consumer.Api.ApiBase);
            Assembly assembly = apiBaseType.Assembly;
            Type[] listOfTypes = assembly.GetTypes();
            var apiTypes = listOfTypes.Where(t => t.IsSubclassOf(apiBaseType)).OrderBy(t => t.Name).Select(t => new ApiType { Type = t });

            cmbAPI.DataSource = apiTypes.ToList();
        }

        private void cmbAPI_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type apiType = ((ApiType)cmbAPI.SelectedItem).Type;

            MethodInfo[] mia = apiType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            var apiMethods = mia.Where(m => m.ReturnType.Name.Contains("ApiCallResponse")).OrderBy(m => m.Name).Select(m => new ApiMethod { MethodInfo = m });
            cmbMethod.DataSource = apiMethods.ToList();
        }

        private void cmbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            MethodInfo mi = ((ApiMethod)cmbMethod.SelectedItem).MethodInfo;

            ParameterInfo[] parameters = mi.GetParameters();

            pnlParameters.Controls.Clear();
            foreach (ParameterInfo parameter in parameters)
            {
                ucParameter control = new ucParameter(parameter);
                pnlParameters.Controls.Add(control);
                control.Dock = DockStyle.Top;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            Type apiType = ((ApiType)cmbAPI.SelectedItem).Type;

            MethodInfo mi = ((ApiMethod)cmbMethod.SelectedItem).MethodInfo;
            ParameterInfo[] parameters = mi.GetParameters();

            object[] values = new object[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                ucParameter control = (ucParameter)pnlParameters.Controls[i];
                values[i] = control.Value;
            }

            InitConnector();
            Type connectorType = connector.GetType();
            string propertyName = apiType.Name;
            PropertyInfo connectorProperty = connectorType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            object connectorApi = connectorProperty.GetValue(connector);

            dynamic result = mi.Invoke(connectorApi, values); // result is actually ApiCallResponse<T>, but the "T" is reflected, not fixed. 
            if (result == null)
            {
                MessageBox.Show("Null result.");
                return;
            }

            if (result.Success)
            {
                DisplaySuccess(result.ReceivedObject);
            }
            else
            {
                DisplayErrors(result.Errors);
            }
        }

        private void DisplaySuccess(object receivedObject)
        {
            if (receivedObject is IEnumerable)
            {
                DisplayMultipleObjects((IEnumerable)receivedObject);
            }
            else
            {
                DisplaySingleObject(receivedObject);
            }
        }

        private void DisplaySingleObject(object obj)
        {
            FormShowObject frm = new FormShowObject(obj);
            frm.ShowDialog();
        }

        private void DisplayMultipleObjects(IEnumerable ien)
        {
            FormShowObjects frm = new FormShowObjects(ien);
            frm.ShowDialog();
        }

        private void DisplayErrors(IEnumerable<Tachyon.SDK.Consumer.Models.Api.Error> errors)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Tachyon.SDK.Consumer.Models.Api.Error error in errors)
            {
                string text = string.Format("ErrorType={0}\nErrorCode={1}\nMessage={2}", error.ErrorType, error.ErrorCode, error.Message);
                sb.AppendLine(text);
            }

            MessageBox.Show(sb.ToString(), "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void InitConnector()
        {
            if (connector == null)
            {
                connector = new Tachyon.SDK.Consumer.TachyonConnector(txtTachyonUrl.Text, txtConsumerName.Text);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Helpers.WindowState.SaveWindowLocation(this);
        }
    }
}
