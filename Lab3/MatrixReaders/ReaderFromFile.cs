using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace Lab3
{
    internal class ReaderFromFile : IReader
    {
        double[,] IReader.Read()
        {
            double[,] matrix;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            string projectFolderPath = Application.StartupPath;
            openFileDialog.InitialDirectory = projectFolderPath;
            openFileDialog.Filter = "Text Files|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;
                using (StreamReader sr = new StreamReader(selectedFileName))
                {
                    string[] rows = sr.ReadToEnd().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    int countRows = rows.Length;
                    int countColumn = rows[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
                    matrix = new double[countRows, countColumn];

                    for (int i = 0; i < countRows; i++)
                    {
                        string[] row = rows[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < countColumn; j++)
                            matrix[i, j] = double.Parse(row[j], CultureInfo.InvariantCulture);
                    }
                }
                return matrix;
            }
            else
            {
                Console.WriteLine("User canceled the file chooser dialog");
                return null;
            }
        }
    }
}
