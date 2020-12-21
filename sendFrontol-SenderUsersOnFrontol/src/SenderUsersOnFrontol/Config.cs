using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SenderUsersOnFrontol
{
    public class Config
    {
        public static Procedures hCntMain { get; set; } //осн. коннект K21 dbase1
        public static Procedures hCntSecond { get; set; } //доп. коннект X14 dbase1
        public static Procedures hCntMainKassRealiz { get; set; } // K21 KassRealiz
        public static Procedures hCntSecondKassRealiz { get; set; }
        public static string[] RunArguments = null;

        public static TransactionProcedures trCntK21dbase1 { get; set; }
        public static TransactionProcedures trCntX14dbase1 { get; set; }
        public static TransactionProcedures trCntK21KassRealiz { get; set; }
        public static TransactionProcedures trCntX14KassRealiz { get; set; }
        public static string centralText(string str)
        {
            int[] arra = new int[255];
            int count = 0;
            int maxLength = 0;
            int indexF = -1;
            arra[count] = 0;
            count++;
            indexF = str.IndexOf("\n");
            arra[count] = indexF;
            while (indexF != -1)
            {
                count++;
                indexF = str.IndexOf("\n", indexF + 1);
                arra[count] = indexF;
            }
            maxLength = arra[1] - arra[0];
            for (int i = 1; i < count; i++)
            {
                if (maxLength < (arra[i] - arra[i - 1]))
                {

                    maxLength = arra[i] - arra[i - 1];
                    if (i >= 2)
                    {
                        maxLength = maxLength - 1;
                    }
                }
            }
            string newString = "";
            string buffString = "";
            for (int i = 1; i < count; i++)
            {
                if (i >= 2)
                {

                    buffString = str.Substring(arra[i - 1] + 1, (arra[i] - arra[i - 1] - 1));
                    buffString = buffString.PadLeft(Convert.ToInt32(buffString.Length + ((maxLength - (arra[i] - arra[i - 1] - 1)) / 2) * 1.8));
                    //    buffString = buffString.PadRight(buffString.Length + ((maxLength - (arra[i] - arra[i - 1] - 1)) / 2)*2);
                    newString += buffString + "\n";
                }
                else
                {
                    buffString = str.Substring(arra[i - 1], arra[i]);
                    buffString = buffString.PadLeft(Convert.ToInt32(buffString.Length + ((maxLength - (arra[i] - arra[i - 1] - 1)) / 2) * 1.8));
                    // buffString = buffString.PadRight(buffString.Length + ((maxLength - (arra[i] - arra[i - 1])) / 2)*2);
                    newString = buffString + "\n";
                }

            }

            return newString;
        }

        public static string userName = "";
        public static string statusCode = "";
        public static string IP = "";
        public static string Login = "";
        public static string Password = "";
        public static string Folder = "";
        public static int Time = 0;

        public static void SendUserToTerminal()
        {
            if (DialogResult.Yes == MessageBox.Show(centralText("Список пользователей был изменён.\nОтправить список пользователей\nна кассы?\n"), "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            { 
            
            }
        }
    }
}
