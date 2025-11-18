using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Mtps
{
    
    internal class Logger
    {
        #region DONNÉES MEMBRES
        private string m_message;
        #endregion
        #region CONSTRUCTEURS
        public Logger()
        {
            m_message = string.Empty;
        }
        public Logger(string lemessage, string cheminEXE)
        {
            m_message = lemessage;
            Log(lemessage, cheminEXE);
        }
        #endregion
        #region MÉTHODES PRIVÉES
        private void Log(string message, string cheminEXE)
        {
            try
            {
                string logFile = Path.Combine(cheminEXE, "application.log");
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
                File.AppendAllText(logFile, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // En cas d'erreur de journalisation, on peut ignorer ou afficher un message
                Debug.WriteLine($"Erreur lors de l'écriture du log : {ex.Message}");
            }
        }
        #endregion

    }
}
