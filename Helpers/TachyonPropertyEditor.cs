namespace SdkHarness
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    internal class TachyonPropertyEditor : System.Drawing.Design.UITypeEditor
    {
        private System.Windows.Forms.Design.IWindowsFormsEditorService _service = null;

        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (null != context && null != context.Instance)
            {
                return System.Drawing.Design.UITypeEditorEditStyle.Modal;
            }

            return base.GetEditStyle(context);
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (null != context && null != context.Instance && null != provider)
            {
                this._service = (System.Windows.Forms.Design.IWindowsFormsEditorService)provider.GetService(typeof(System.Windows.Forms.Design.IWindowsFormsEditorService));
                if (null != this._service)
                {
                    FormShowObject frm = new FormShowObject(value);
                    switch (this._service.ShowDialog(frm))
                    {
                        case DialogResult.OK:
                            value = frm.SelectedObject;
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                }
            }

            return value;
        }

        public static void AddCustomEditors(object obj)
        {
            if (obj == null)
            {
                return;
            }

            Type t = obj.GetType();
            System.Reflection.PropertyInfo[] pia = t.GetProperties();
            foreach (var pi in pia)
            {
                if (pi.PropertyType.FullName.StartsWith("Tachyon."))
                {
                    // Use this trick to add a custom UI Editor
                    Attribute attributeToAdd = new EditorAttribute(typeof(TachyonPropertyEditor), typeof(System.Drawing.Design.UITypeEditor));
                    if (!TypeDescriptor.GetAttributes(pi.PropertyType).Contains(attributeToAdd))
                    {
                        TypeDescriptor.AddAttributes(pi.PropertyType, attributeToAdd);
                    }
                }
            }
        }
    }
}
