namespace SdkHarness.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Contains helper functions for saving and restoring the state of open windows
    /// </summary>
    /// <remarks>
    /// Requires a property to be created in Setting.Settings.
    /// Should be named FormLocations, type=FormLocationsCollection.
    /// </remarks>
    public class WindowState
    {
        /// <summary>
        /// Save the current size, state and location of a form
        /// </summary>
        /// <param name="form">The form whose properties are to be saved</param>
        public static void SaveWindowLocation(Form form)
        {
            try
            {
                int currentScreenSizeCode = GetScreenSizeSummaryCode();

                FormLocationsCollection flc = Properties.Settings.Default.FormLocations ?? new FormLocationsCollection();
                FormLocation fl = new FormLocation();
                fl.ScreenSizeCode = currentScreenSizeCode;
                fl.IsMaximized = form.WindowState == FormWindowState.Maximized;
                if (!fl.IsMaximized)
                {
                    fl.Size = form.Size;
                    fl.Location = form.Location;
                }

                string name = GetWindowName(form);
                fl.Name = name;

                // Get all locations which are *not* the current one
                FormLocationsCollection flcNew = new FormLocationsCollection(from f in flc where f.Name != name || f.ScreenSizeCode != currentScreenSizeCode select f);

                // Add current location to the collections
                flcNew.Add(fl);

                // Save back the newly formed collection
                Properties.Settings.Default.FormLocations = flcNew;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SaveWindowLocation: " + ex.Message);
            }
        }

        /// <summary>
        /// Restore the size, state and location that were saved for a form
        /// </summary>
        /// <param name="form">The form whose properties are to be restored</param>
        public static void RestoreWindowLocation(Form form)
        {
            try
            {
                int currentScreenSizeCode = GetScreenSizeSummaryCode();

                FormLocationsCollection flc = Properties.Settings.Default.FormLocations;
                if (flc != null)
                {
                    string name = GetWindowName(form);
                    FormLocation fl = (from f in flc where f.Name == name && f.ScreenSizeCode == currentScreenSizeCode select f).FirstOrDefault();
                    if (fl != null)
                    {
                        if (fl.IsMaximized)
                        {
                            form.WindowState = FormWindowState.Maximized;
                        }
                        else
                        {
                            form.Size = fl.Size;
                            form.Location = fl.Location;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("RestoreWindowLocation: " + ex.Message);
            }
        }

        private static string GetWindowName(Form form)
        {
            return form.GetType().Name;
        }

        private static int GetScreenSizeSummaryCode()
        {
            Screen[] screens = Screen.AllScreens;
            LocalBoundsCollection lbc = new LocalBoundsCollection();
            for (int i = 0; i < screens.Length; i++)
            {
                LocalBounds lb = new LocalBounds(i, screens[i].WorkingArea.Width, screens[i].WorkingArea.Height);
                lbc.Add(lb);
            }

            return lbc.GetSummaryCode();
        }

        [Serializable]
        public class FormLocation
        {
            public string Name { get; set; }

            public bool IsMaximized { get; set; }

            public System.Drawing.Size Size { get; set; }

            public System.Drawing.Point Location { get; set; }

            public int ScreenSizeCode { get; set; }
        }

        [Serializable]
        public class FormLocationsCollection : List<FormLocation>
        {
            public FormLocationsCollection()
                : base()
            {
            }

            public FormLocationsCollection(IEnumerable<FormLocation> lfl)
                : this()
            {
                foreach (FormLocation fl in lfl)
                {
                    this.Add(fl);
                }
            }
        }

        private class LocalBounds
        {
            public LocalBounds(int number, int width, int height)
            {
                this.Number = number;
                this.Width = width;
                this.Height = height;
            }

            public int Number { get; set; }

            public int Width { get; set; }

            public int Height { get; set; }

            public int GetSummaryCode()
            {
                return (Width << Number) ^ (Height << (Number + 16));
            }
        }

        private class LocalBoundsCollection : List<LocalBounds>
        {
            public int GetSummaryCode()
            {
                int hash = 0;
                foreach (LocalBounds lb in this)
                {
                    hash ^= lb.GetSummaryCode();
                }

                return hash;
            }
        }
    }

}
