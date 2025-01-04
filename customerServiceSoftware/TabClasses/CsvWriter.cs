using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customerServiceSoftware.TabClasses
{
    public class CsvWriter
    {

        /// <summary>
        /// Writes a row of columns to the current CSV file.
        /// </summary>
        /// <param name="columns">The list of columns to write</param>
        public static string ReadFile(string path,string filename)
        {

            try
            {

                using (StreamReader sr = new StreamReader(path + "\\" + filename))
                {
                    string line;

                    // Read and display lines from the file until 
                    // the end of the file is reached. 
                    while ((line = sr.ReadLine()) != null)
                    {
                        return line;
                    }
                }

                return "";
            }
            catch (Exception e)
            {
                string x = e.Message.ToString();
                return x;

            }
        }


        public static void WriteFile(string path, string row, string filename)
        {
            try
            {
               using (StreamWriter sr = new StreamWriter(path + "\\" + filename))
                {
                    sr.Write(row);
                }
            }
            catch (Exception e)
            {
                string x = e.Message.ToString();
            }
        }

        public static string[] SavedProfiles(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.csv"); //Getting Text files
            string [] str= new string [Files.Length];
            for (int i= 0; i<Files.Length ; i++)
            {
                str[i] = Files[i].Name.ToString();
            }
           return str;
        }


        public static bool DeleteFile(string path)
        {
            bool check = false;
            try
            {
                File.Delete(path);
                return check = true;
            }
            catch(Exception ex)
            {
                string x = ex.Message.ToString();
                return check;
            }
        }

   }
}
