using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Reflection;

namespace EncryptFile
{
    public partial class Form1 : Form
    {
        private static byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        private static int BlockSize = 128;
        public Form1()
        {
            InitializeComponent();
            //MessageBox.Show("" + pnlA.Location.X + ":" + pnlA.Location.Y);
            pnlAES.Location = new Point(19, 30);
            pnlDES.Location = new Point(19, 30);
            pnlMD5.Location = new Point(19, 30);
            pnlRSA.Location = new Point(19, 30);
            this.Size = new Size(550, 300);
        }

        private void BtnLink_Click(object sender, EventArgs e)
        {
            if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbxFilePathAES.Text = ofd.FileName;
            }
        }

        private void BtnMaHoa_Click(object sender, EventArgs e)
        {
            if (tbxPasswordAES.Text.Length != 0)
            {
                //byte password = byte.Parse(txtPassword.Text);
                if (File.Exists(tbxFilePathAES.Text))
                {
                    String inputFileName = tbxFilePathAES.Text;
                    String outputFileName = Path.GetDirectoryName(tbxFilePathAES.Text);
                    outputFileName += "\\" + Path.GetFileNameWithoutExtension(tbxFilePathAES.Text);
                    outputFileName += "_AES_Encrypted" + Path.GetExtension(tbxFilePathAES.Text);
                    //AES_Encrypt(inputFileName, outputFileName, txtPassword.Text);
                    AES_Encrypt(inputFileName, outputFileName, tbxPasswordAES.Text);
                    MessageBox.Show("AES_Encrypt Successfully!");
                }
                else
                {
                    MessageBox.Show("This path is not found!");
                }
            }
            else
            {
                MessageBox.Show("Please type password!");
                
            }
        }

        private void BtnDecrypt_Click(object sender, EventArgs e)
        {
            if (tbxPasswordAES.Text.Length != 0)
            {
                //byte password = byte.Parse(txtPassword.Text);
                if (File.Exists(tbxFilePathAES.Text))
                {
                    String inputFileName = tbxFilePathAES.Text;
                    String outputFileName = Path.GetDirectoryName(tbxFilePathAES.Text);
                    outputFileName += "\\" + Path.GetFileNameWithoutExtension(tbxFilePathAES.Text);
                    outputFileName += "_AES_Decrypted" + Path.GetExtension(tbxFilePathAES.Text);
                    try
                    {
                        AES_Decrypt(inputFileName, outputFileName, tbxPasswordAES.Text);
                        //Check Intergrity
                        String outputFileName2 = Path.GetDirectoryName(outputFileName);
                        outputFileName2 += "\\" + Path.GetFileNameWithoutExtension(outputFileName);
                        outputFileName2 += "2" + Path.GetExtension(outputFileName);
                        AES_Encrypt(outputFileName, outputFileName2, tbxPasswordAES.Text);
                        string hashValueA = CheckMD5(inputFileName);
                        string hashValueB = CheckMD5(outputFileName2);
                        File.Delete(outputFileName2);
                        if (hashValueA.Equals(hashValueB))
                        {
                            MessageBox.Show("AES_Decrypt Successfully!");
                        } else
                        {
                            MessageBox.Show("AES_Decrypt Failed!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Can not AES_decrypt\n");
                        //MessageBox.Show(ex.ToString());
                    }
                    
                    
                }
                else
                {
                    MessageBox.Show("This path is not found!");
                }
            }
            else
            {
                MessageBox.Show("{Please type password!");

            }
        }

        private void BtnCryp_Click(object sender, EventArgs e)
        {
            string input = "" + tbxInput.Text;
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            tbxOutput.Text = sb.ToString();
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlAES.Visible = true;
            pnlDES.Visible = false;
            pnlMD5.Visible = false;
            pnlRSA.Visible = false;
        }

        private void MD5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlAES.Visible = false;
            pnlDES.Visible = false;
            pnlMD5.Visible = true;
            pnlRSA.Visible = false;
            if (pnlMD5.Visible == false)
            {
                pnlMD5.Visible = true;
                MessageBox.Show("Error");
            }
        }

        private void DESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlAES.Visible = false;
            pnlDES.Visible = true;
            pnlMD5.Visible = false;
            pnlRSA.Visible = false;
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
        public static void DES_Encrypt(string iFile, string oFile, string password)
        {
            FileStream fsInput = new FileStream(iFile, FileMode.Open, FileAccess.Read);
            FileStream fsOutput = new FileStream(oFile, FileMode.Create, FileAccess.Write);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            DES des = DES.Create();
            des.Key = pdb.GetBytes(8);
            des.IV = pdb.GetBytes(8);
            CryptoStream cs = new CryptoStream(fsOutput, des.CreateEncryptor(), CryptoStreamMode.Write);
            int bufferLenght = 4096;
            byte[] buffer = new byte[bufferLenght];
            int bytesRead;
            do
            {
                bytesRead = fsInput.Read(buffer, 0, bufferLenght);
                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead !=0);

            cs.Close();
            fsInput.Close();
            fsOutput.Close();
        }
        public static void DES_Decrypt(string iFile, string oFile, string password)
        {
            FileStream fsInput = new FileStream(iFile, FileMode.Open, FileAccess.Read);
            FileStream fsOutput = new FileStream(oFile, FileMode.OpenOrCreate, FileAccess.Write);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            DES des = DES.Create();
            des.Key = pdb.GetBytes(8);
            des.IV = pdb.GetBytes(8);
            CryptoStream cs = new CryptoStream(fsOutput, des.CreateDecryptor(), CryptoStreamMode.Write);
            int bufferLenght = 4096;
            byte[] buffer = new byte[bufferLenght];
            int bytesRead;
            do
            {
                bytesRead = fsInput.Read(buffer, 0, bufferLenght);
                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);

            cs.Close();
            fsOutput.Close();
            fsInput.Close();
        }
        public static void AES_Encrypt(string iFile, string oFile, string password)
        {
            FileStream fsInput = new FileStream(iFile, FileMode.Open, FileAccess.Read);
            FileStream fsOutput = new FileStream(oFile, FileMode.Create, FileAccess.Write);
            SymmetricAlgorithm crypt = Aes.Create();
            HashAlgorithm hash = MD5.Create();
            crypt.BlockSize = BlockSize;
            crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(password));
            crypt.IV = IV;

            using (CryptoStream cryptoStream =
                   new CryptoStream(fsOutput, crypt.CreateEncryptor(), CryptoStreamMode.Write))
            {
                int bufferLenght = 4096;
                byte[] buffer = new byte[bufferLenght];
                int bytesRead;
                do
                {
                    bytesRead = fsInput.Read(buffer, 0, bufferLenght);
                    cryptoStream.Write(buffer, 0, bytesRead);
                } while (bytesRead != 0);
            }
            //end
            return;
        }
        public static void AES_Decrypt(string iFile, string oFile, string password)
        {
            FileStream fsInput = new FileStream(iFile, FileMode.Open, FileAccess.Read);
            FileStream fsOutput = new FileStream(oFile, FileMode.Create, FileAccess.Write);
            SymmetricAlgorithm crypt = Aes.Create();
            HashAlgorithm hash = MD5.Create();
            crypt.BlockSize = BlockSize;
            crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(password));
            crypt.IV = IV;
            using (CryptoStream cryptoStream =
                   new CryptoStream(fsOutput, crypt.CreateDecryptor(), CryptoStreamMode.Write))
            {
                int bufferLenght = 4096;
                byte[] buffer = new byte[bufferLenght];
                int bytesRead;
                do
                {
                    bytesRead = fsInput.Read(buffer, 0, bufferLenght);
                    cryptoStream.Write(buffer, 0, bytesRead);
                } while (bytesRead != 0);
            }
            
        }

        private void BtnLinkDES_Click(object sender, EventArgs e)
        {
            if (ofdDES.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbxFilePathDES.Text = ofdDES.FileName;
            }
        }

        private void BtnEncryptDES_Click(object sender, EventArgs e)
        {
            if (tbxPasswordDES.Text.Length != 0)
            {
                string password = tbxPasswordDES.Text;
                if (File.Exists(tbxFilePathDES.Text))
                {
                    
                    string inputFileName = tbxFilePathDES.Text;
                    string outputFileName = Path.GetDirectoryName(inputFileName);
                    outputFileName += "\\" + Path.GetFileNameWithoutExtension(inputFileName);
                    outputFileName += "_DES_Encrypted" + Path.GetExtension(inputFileName);
                    DES_Encrypt(inputFileName, outputFileName, password);
                    MessageBox.Show("DES_Encrypt Successfully!");
                }
                else
                {
                    MessageBox.Show("This Path is not found!");
                }
            }
            else
            {
                MessageBox.Show("Please type password!");

            }
        }

        private void BtnDecryptDES_Click(object sender, EventArgs e)
        {
            if (tbxPasswordDES.Text.Length != 0)
            {
                string password = tbxPasswordDES.Text;
                if (File.Exists(tbxFilePathDES.Text))
                {
                    string inputFileName = tbxFilePathDES.Text;
                    string outputFileName = Path.GetDirectoryName(inputFileName);
                    outputFileName += "\\" + Path.GetFileNameWithoutExtension(inputFileName);
                    outputFileName += "_DES_Decrypted" + Path.GetExtension(inputFileName);
                    
                    try
                    {
                        DES_Decrypt(inputFileName, outputFileName, password);
                        String outputFileName2 = Path.GetDirectoryName(outputFileName);
                        outputFileName2 += "\\" + Path.GetFileNameWithoutExtension(outputFileName);
                        outputFileName2 += "2" + Path.GetExtension(outputFileName);
                        DES_Encrypt(outputFileName, outputFileName2, tbxPasswordDES.Text);
                        string hashValueA = CheckMD5(inputFileName);
                        string hashValueB = CheckMD5(outputFileName2);
                        File.Delete(outputFileName2);
                        if (hashValueA.Equals(hashValueB))
                        {
                            MessageBox.Show("DES_Decrypt Successfully!");
                        }
                        else
                        {
                            MessageBox.Show("DES_Decrypt Failed!");
                        }
                    } catch(Exception ex)
                    {
                        MessageBox.Show("Can not DES_Decrypt!\n" + ex.ToString());
                    }
                    //string hashValueI = CheckMD5(inputFileName);
                    //string hashValueO = CheckMD5(outputFileName);
                    //if (hashValueI.Equals(hashValueO))
                    //{
                    //    MessageBox.Show("Successfully!");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Failed!");
                    //}
                }
                else
                {
                    MessageBox.Show("This Path is not found!");
                }
            }
            else
            {
                MessageBox.Show("Please type password!");

            }
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }
        static string CheckMD5(string fileName)
        {
            using (var md = MD5.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    return Encoding.Default.GetString(md.ComputeHash(stream));
                }
            }
        }
        public static String GetHash<T>(Stream stream) where T : HashAlgorithm
        {
            StringBuilder sb = new StringBuilder();

            MethodInfo create = typeof(T).GetMethod("Create", new Type[] { });
            using (T crypt = (T)create.Invoke(null, null))
            {
                byte[] hashBytes = crypt.ComputeHash(stream);
                foreach (byte bt in hashBytes)
                {
                    sb.Append(bt.ToString("x2"));
                }
            }
            return sb.ToString();
        }
        public static string HashByMD5(byte[] input)
        {
            MD5 md5 = MD5.Create();
            byte[] hashBytes = md5.ComputeHash(input);
            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
        //UnicodeEncoding ByteConverter = new UnicodeEncoding();
        //RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        //byte[] plaintext;
        //byte[] encryptedtext;
        byte[] encrypted, decrypted;
        string cipher;
        private void BtnEncryptRSA_Click(object sender, EventArgs e)
        {
            if (File.Exists(tbxFilePathRSA.Text))
            {
                string plaintext, ciphertext;
                using (StreamReader sr = new StreamReader(tbxFilePathRSA.Text))
                {
                    plaintext = sr.ReadLine();
                }
                encrypted = RSAEncrypt(Encoding.UTF8.GetBytes(plaintext));
                decrypted = RSADecrypt(encrypted);
                ciphertext = BitConverter.ToString(encrypted);
                string outputFileName = Path.GetDirectoryName(tbxFilePathRSA.Text);
                outputFileName += "\\" + Path.GetFileNameWithoutExtension(tbxFilePathRSA.Text);
                outputFileName += "_RSA_Encrypt" + Path.GetExtension(tbxFilePathRSA.Text);
                tbxTemp.Text = ciphertext;
                string path = @"D:\BKU\HK192\Mat ma an ninh mang\ass1\KeyEncode.txt";
                //using (StreamWriter sw = new StreamWriter(path))
                //{
                //    sw.WriteLine(Encoding.UTF8.GetString(decrypted));
                //}
                //using (StreamWriter sw = new StreamWriter(outputFileName))
                //{
                //    cipher = Encoding.UTF8.GetString(encrypted);
                //    sw.Write(cipher);
                //}
                FileStream fs = File.OpenWrite(outputFileName);
                fs.Write(encrypted, 0, encrypted.Length);
                fs.Close();
                MessageBox.Show("RSA_Encrypte Successfully!");
            }
            else
            {
                MessageBox.Show("Not Found!");
            }
        }
        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }

        }
        private void BtnDecryptRSA_Click(object sender, EventArgs e)
        {
            if (File.Exists(tbxFilePathRSA.Text))
            {
                string plaintext, ciphertext;
                FileStream fs;
                fs = File.OpenRead(tbxFilePathRSA.Text);
                fs.Read(encrypted, 0, encrypted.Length);
                using (StreamReader sr = new StreamReader(tbxFilePathRSA.Text))
                {
                    ciphertext = sr.ReadLine();
                }
                try
                {
                    decrypted = RSADecrypt(encrypted);
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                plaintext = Encoding.UTF8.GetString(decrypted);
                tbxTemp2.Text = plaintext;
                string outputFileName = Path.GetDirectoryName(tbxFilePathRSA.Text);
                outputFileName += "\\" + Path.GetFileNameWithoutExtension(tbxFilePathRSA.Text);
                outputFileName += "_RSA_Decrypt" + Path.GetExtension(tbxFilePathRSA.Text);
                using (StreamWriter sw = new StreamWriter(outputFileName))
                {
                    sw.WriteLine(plaintext);
                }
                MessageBox.Show("RSA_Decrypte Successfully!");
            }
        }
        static public byte[] Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }

        }
        private void RSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlAES.Visible = false;
            pnlDES.Visible = false;
            pnlMD5.Visible = false;
            pnlRSA.Visible = true;
            lblPassRSA.Visible = false;
            tbxPasswordRSA.Visible = false;
            tbxTemp.Visible = false;
            tbxTemp2.Visible = false;
            generateRSAKey();
        }

        private void BtnLinkRSA_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbxFilePathRSA.Text = ofd.FileName;
            }
        }
        static void RSA_Encrypt(string iFile, string oFile, int e, int m)
        {
            FileStream fsInput = new FileStream(iFile, FileMode.Open, FileAccess.Read);
            FileStream fsOutput = new FileStream(oFile, FileMode.Create, FileAccess.Write);
        }
        static int moduleRSA(int factor, int exponent, int module)
        {
            if (exponent == 0) return 1;
            int temp = moduleRSA(factor, exponent/2, module);
            if (exponent % 2 == 0) return temp * temp % module;
            return temp * temp % module * factor % module;
        }
        static string StringToInt(string str)
        {
            string temp = "";
            for (int i = 0; i < str.Length; i++)
            {
                temp += "-" + ((int)str[i]).ToString();
            }
            return temp;
        }
        private static RSAParameters publicKey, privateKey;
        static string CONTAINER_NAME = "MyContainer";
        static void generateRSAKey()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                publicKey = rsa.ExportParameters(false);
                privateKey = rsa.ExportParameters(true);
            }
        }
        static byte[] RSAEncrypt(byte[] input)
        {
            byte[] encrypted;
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(publicKey);
                encrypted = rsa.Encrypt(input, true);
            }
            return encrypted;
        }
        static byte[] RSADecrypt(byte[] input)
        {
            byte[] decrypted;
            using(var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(privateKey);
                decrypted = rsa.Decrypt(input, true);
            }
            return decrypted;
        }
    }
}
