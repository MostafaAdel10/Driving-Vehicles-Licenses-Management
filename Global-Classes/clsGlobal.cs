using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DVLD_DrivingLicenseManagement.Global_Classes
{
    internal class clsGlobal
    {
        public static clsUsersBusiness CurrentUser;

        // Specify the Registry key and path
        private static string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
        private static string valueNameUser = "UserName";
        private static string valueNamePasswrd = "Password";

        public static bool RememperUserNameAndPassword(string Username, string Password)
        {
            try
            {
                //this will get the current project directory folder.
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                // Define the path to the text file where you want to save the data
                string filePath = currentDirectory + "\\data.txt";

                //incase the username is empty, delete the file
                if (Username == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;

                }

                // concatonate username and passwrod withe seperator.
                string dataToSave = Username + "#//#" + Password;

                // Create a StreamWriter to write to the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write the data to the file
                    writer.WriteLine(dataToSave);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            try
            {
                //gets the current project's directory
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                // Path for the file that contains the credential.
                string filePath = currentDirectory + "\\data.txt";

                // Check if the file exists before attempting to read it
                if (File.Exists(filePath))
                {
                    // Create a StreamReader to read from the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // Read data line by line until the end of the file
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line); // Output each line of data to the console
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];
                            Password = result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        public static bool RememperUserNameAndPasswordToRegistry(string Username, string Password)
        {
            try
            {
                string ValueUData = Username;
                string ValuePassData = Password;
                Registry.SetValue(keyPath, valueNameUser, ValueUData, RegistryValueKind.String);
                Registry.SetValue(keyPath, valueNamePasswrd, ValuePassData, RegistryValueKind.String);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public static bool GetStoredCredentialFromRegistry(ref string Username, ref string Password)
        {
            try
            {
                //bool IsRememper = false;
                // Read the value from the Registry
                string _UserName = Registry.GetValue(keyPath, valueNameUser, null) as string;
                string _Password = Registry.GetValue(keyPath, valueNamePasswrd, null) as string;

                if (_UserName != null && _Password != null)
                {
                    Username = _UserName.Trim();
                    Password = _Password.Trim();
                    return true;
                }
                else
                {
                    try
                    {
                        // Open the registry key in read/write mode with explicit registry view
                        using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                        {
                            using (RegistryKey key = baseKey.OpenSubKey(keyPath, true))
                            {
                                if (key != null)
                                {
                                    // Delete the specified value
                                    key.DeleteValue(valueNameUser);
                                    key.DeleteValue(valueNamePasswrd);
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        return false ;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
