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
            pnlA.Location = new Point(19, 30);
            pnlDES.Location = new Point(19, 30);
            pnlMD5.Location = new Point(19, 30);
        }

        private void BtnLink_Click(object sender, EventArgs e)
        {
            if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
            }
        }

        private void BtnMaHoa_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length != 0)
            {
                //byte password = byte.Parse(txtPassword.Text);
                if (File.Exists(txtFilePath.Text))
                {
                    String inputFileName = txtFilePath.Text;
                    String outputFileName = Path.GetDirectoryName(txtFilePath.Text);
                    outputFileName += "\\" + Path.GetFileNameWithoutExtension(txtFilePath.Text);
                    outputFileName += "_AES_Encrypted" + Path.GetExtension(txtFilePath.Text);
                    //AES_Encrypt(inputFileName, outputFileName, txtPassword.Text);
                    AES_Encrypt(inputFileName, outputFileName, txtPassword.Text);
                    
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
            if (txtPassword.Text.Length != 0)
            {
                //byte password = byte.Parse(txtPassword.Text);
                if (File.Exists(txtFilePath.Text))
                {
                    String inputFileName = txtFilePath.Text;
                    String outputFileName = Path.GetDirectoryName(txtFilePath.Text);
                    outputFileName += "\\" + Path.GetFileNameWithoutExtension(txtFilePath.Text);
                    outputFileName += "_AES_Decrypted" + Path.GetExtension(txtFilePath.Text);
                    try
                    {
                        AES_Decrypt(inputFileName, outputFileName, txtPassword.Text);
                        MessageBox.Show(outputFileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Can not decrypt\n");
                        MessageBox.Show(ex.ToString());
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
            pnlA.Visible = true;
            pnlDES.Visible = false;
            pnlMD5.Visible = false;
        }

        private void MD5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlA.Visible = false;
            pnlDES.Visible = false;
            pnlMD5.Visible = true;
            if (pnlMD5.Visible == false)
            {
                pnlMD5.Visible = true;
                MessageBox.Show("Error");
            }
        }

        private void DESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlA.Visible = false;
            pnlDES.Visible = true;
            pnlMD5.Visible = false;
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
                tbxFilePath.Text = ofdDES.FileName;
            }
        }

        private void BtnEncryptDES_Click(object sender, EventArgs e)
        {
            if (tbxPassword.Text.Length != 0)
            {
                string password = tbxPassword.Text;
                if (File.Exists(tbxFilePath.Text))
                {
                    
                    string inputFileName = tbxFilePath.Text;
                    string outputFileName = Path.GetDirectoryName(inputFileName);
                    outputFileName += "\\" + Path.GetFileNameWithoutExtension(inputFileName);
                    outputFileName += "_DES_Encrypted" + Path.GetExtension(inputFileName);
                    MessageBox.Show(outputFileName);
                    DES_Encrypt(inputFileName, outputFileName, password);
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
            if (tbxPassword.Text.Length != 0)
            {
                string password = tbxPassword.Text;
                if (File.Exists(tbxFilePath.Text))
                {
                    string inputFileName = tbxFilePath.Text;
                    string outputFileName = Path.GetDirectoryName(inputFileName);
                    outputFileName += "\\" + Path.GetFileNameWithoutExtension(inputFileName);
                    outputFileName += "_DES_Decrypted" + Path.GetExtension(inputFileName);
                    
                    try
                    {
                        DES_Decrypt(inputFileName, outputFileName, password);
                        MessageBox.Show(outputFileName);
                    } catch(Exception ex)
                    {
                        MessageBox.Show("Can not decrypt\n");
                        MessageBox.Show(ex.ToString());
                    }
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
        public static void HashByMD5(byte[] input, string output)
        {
            MD5 md5 = MD5.Create();
            byte[] hashBytes = md5.ComputeHash(input);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            output = sb.ToString();
        }
        
    }
}
