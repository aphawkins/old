//using System;
//using System.Windows.Forms;
//using System.IO;
////using PSe.Importers;
//
//namespace APH.DataServices
//{
//	/// <summary>
//	/// Summary description for DataImport.
//	/// </summary>
//	public class Import
//	{
//		public Import()
//		{
//		}
//
//		public static bool MoveFile(string OldFilePath, string NewFilePath, bool AskConfirmation)
//		{
//			string sNewPath = "";
//			DialogResult dr = DialogResult.Yes;
//			bool bNewFileExists = System.IO.File.Exists(NewFilePath);
//
//			if (bNewFileExists & AskConfirmation)
//			{
//				dr = MessageBox.Show("The file " + NewFilePath + " already exists.  Do you wish to overwrite it?", "File move",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
//			}
//			if (dr == DialogResult.Yes)
//			{						
//				if (bNewFileExists)
//				{
//					System.IO.File.Delete(NewFilePath);
//				}
//
//				sNewPath = System.IO.Path.GetDirectoryName(NewFilePath);
//				if (!System.IO.Directory.Exists(sNewPath))
//				{
//					System.IO.Directory.CreateDirectory(sNewPath);
//				}
//				System.IO.File.Move(OldFilePath, NewFilePath);
//				return true;
//			}
//			else
//			{
//				return false;
//			}
//		}
//
//		public static void Process(string CID, string ProcessFilePath)
//		{
//			int iCID = 0;
//			//Test for valid CID
//			try
//			{
//				iCID = int.Parse(CID);
//			}
//			catch(FormatException fe)
//			{
//				throw(fe);
//			}
//
////			PSe.Importers.HROnlineImport hroImport = null;
////			PSe.Importers.FBImport oFBImport = null;
//
//			StreamReader sr = new StreamReader(ProcessFilePath);
//			string sText =  sr.ReadToEnd();
//			sr.Close();
//
////			if (sText.IndexOf("<HROnlineImport>") > 0)
////			{
////				if (hroImport == null)
////				{
////					hroImport = new PSe.Importers.HROnlineImport(sText, iCID);
////				}
////			}
////			else if (sText.IndexOf("<APHBenefitCarrier>") > 0)
////			{
////				if (oFBImport == null)
////				{
////					oFBImport = new FBImport(iCID);
////				}
////				oFBImport.ImportCarrier(sText);
////			}
////			else if (sText.IndexOf("<APHBenefitElection>") > 0)
////			{
////				if (oFBImport == null)
////				{
////					oFBImport = new FBImport(iCID);
////				}
////				oFBImport.ImportElection(sText);
////			}
////			else if (sText.IndexOf("<APHBenefitOption>") > 0)
////			{
////				if (oFBImport == null)
////				{
////					oFBImport = new FBImport(iCID);
////				}
////				oFBImport.ImportOption(sText);
////			}
//		}
//	}
//}
