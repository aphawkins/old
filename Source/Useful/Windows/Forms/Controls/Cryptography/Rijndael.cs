using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Useful.Windows.Security.Cryptography
{
	/// <summary>
	/// A Windows form that handles the Rijndael cipher.
	/// </summary>
	public class Rijndael : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Initializes a new instance of this class.
		/// </summary>
		public Rijndael()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rijndael));
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Rijndael
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.button1);
			this.Name = "Rijndael";
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
            string original = "This is a much longer string of data than a public/private key algorithm will accept.";
            string roundtrip;
            ASCIIEncoding textConverter = new ASCIIEncoding();
            RijndaelManaged myRijndael = new RijndaelManaged();
            byte[] fromEncrypt;
            byte[] encrypted;
            byte[] toEncrypt;
            byte[] key;
            byte[] IV;

            //Create a new key and initialization vector.
            myRijndael.GenerateKey();
            myRijndael.GenerateIV();

            //Get the key and IV.
            key = myRijndael.Key;
            IV = myRijndael.IV;

            //Get an encryptor.
            ICryptoTransform encryptor = myRijndael.CreateEncryptor(key, IV);
            
            //Encrypt the data.
            MemoryStream msEncrypt = new MemoryStream();
            CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

            //Convert the data to a byte array.
            toEncrypt = textConverter.GetBytes(original);

            //Write all data to the crypto stream and flush it.
            csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
            csEncrypt.FlushFinalBlock();

            //Get encrypted array of bytes.
            encrypted = msEncrypt.ToArray();

            //This is where the message would be transmitted to a recipient
            // who already knows your secret key. Optionally, you can
            // also encrypt your secret key using a public key algorithm
            // and pass it to the mesage recipient along with the RijnDael
            // encrypted message.            

            //Get a decryptor that uses the same key and IV as the encryptor.
            ICryptoTransform decryptor = myRijndael.CreateDecryptor(key, IV);

            //Now decrypt the previously encrypted message using the decryptor
            // obtained in the above step.
            MemoryStream msDecrypt = new MemoryStream(encrypted);
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

            fromEncrypt = new byte[encrypted.Length];

            //Read the data out of the crypto stream.
            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

            //Convert the byte array back into a string.
            roundtrip = textConverter.GetString(fromEncrypt);

            //Display the original data and the decrypted data.
            Console.WriteLine("Original:   {0}", original);
            Console.WriteLine("Round Trip: {0}", roundtrip);
		}
	}
}
