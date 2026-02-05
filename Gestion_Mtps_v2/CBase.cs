using Gestion_Mtps_v2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Application = System.Windows.Forms.Application;

namespace Gestion_Mtps
{
    public class CBase
    {
        #region DONNEES MEMBRES
        private string m_CheminBD;
        private string m_cheminLog;
        private string m_maconnetionstring;
        private OleDbConnection m_cnADONetConnection;
        private OleDbDataAdapter m_dataAdatper;
        private DataTable m_DataTable;

        private Logger lg;

        private bool m_estConnectee;
        #endregion

        #region PROPRIÉTÉS
        public bool BdConnecte { get { return m_estConnectee; } }
        #endregion
        #region CONSRUCTEURS
        //public CBase(string CheminBD, string table)//, string table
        //{
        //    m_LaBase = CheminBD;
        
        //    //InitCBase();
        //    //Connection();
        //    //lg = new Logger();
        //}
        public CBase(string CheminBD, string chlog)//, string table
        {
            m_CheminBD = CheminBD;
            m_cheminLog = chlog;

            bool initbase = InitCBase();
            //Connection();
            //lg = new Logger();
        }
        public CBase()
        {
            m_CheminBD = string.Empty;
            //m_TableChoisie = "";
            //InitCBase();
        }

        

        #endregion

        #region METHODES PUBLIQUES
        public void TestJointures()
        {
            int i = 0;
            string szSelect;
            int idusager = 2;

            szSelect = "SELECT tblCategories.NomCatego FROM tblCategories "
                       + "LEFT JOIN jctUsagerCatgo ON tblCategories.IdCategorie = jctUsagerCatgorie.IdCategorie "
                       + "WHERE jctUsagerCatgo.IdUsager = " + idusager
                       + " ORDER BY tblCategories.NomCategorie";

            try
            {

                m_DataTable = new DataTable();
                m_DataTable.Clear();
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                i = m_DataTable.Rows.Count;

                //if (i > 0)
                //{
                //    lstSousCategories.Add("Ajouter une catégorie");
                //}
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
            }
        }

        internal bool ModifierUnFiltre(ref Usager_v2 m_Usager,string filtre, string nouveauNom)
        {
            try
            {
                // Vérifier si la valeur à modifier est utilisée par plus de 1 usager
                Int32 nUsers = NbUsagersPourFiltre(ref m_Usager, filtre);

                // Déterminer quelle table est visée, quel enregistrement, selon le filtre
                string leupdate = ConstruireUpdateFiltre(ref m_Usager, filtre, nouveauNom);
                bool success = UpdateFiltre(leupdate);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool UpdateFiltre(string leupdate)
        {
            bool ok = false;
            string szUpdate = leupdate;
            try
            {
                OleDbCommand command = new OleDbCommand(szUpdate, m_cnADONetConnection);
                command.ExecuteNonQuery();
                return ok;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private Int32 NbUsagersPourFiltre(ref Usager_v2 U, string filtre)
        {
            string table = string.Empty;
            string nomId = string.Empty;
            string szSelect = string.Empty;

            switch (filtre)
            {
                case "Site":
                    table = "jctSousCategorieSite";
                    nomId = "IdSite";
                    break;
            }

            try
            {
                szSelect = "SELECT COUNT(IdUsager) FROM " + table + " WHERE " + nomId + " = " + U.IdSite;
                Int32 nUser = ObtenirNbUtilisateurs(szSelect);

                //nUser = ObtenirNbUtilisateurs(szSelect);
                return 0;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        private string ConstruireSelect(ref Usager_v2 U, string filtre, string nouveaunom)
        {
            string latable = string.Empty;
            latable = "tbl" + filtre + "s";
            string szSelect = "";
            szSelect = "SELECT IdUsager FROM " + latable + " WHERE Id" + filtre + " = " + U.IdSite;
            return szSelect;
        }

        private string ConstruireUpdateFiltre(ref Usager_v2 U,string filtre,string nouveaunom)
        {
            string latable = string.Empty;
            string nomfiltre = string.Empty;
            string szupdate = "";
                        
            latable = "tbl" + filtre + "s";
            nomfiltre = "nom" + filtre;
            
            szupdate = "UPDATE " +  latable + " SET " + nomfiltre + " = '" + nouveaunom + "'" + " WHERE Id" + filtre + " = " + U.IdSite;
            return szupdate;
        }
        //internal bool ModifierUneCategorie(ref Usager m_Usager, string nouveauNom)
        //{
        //    bool success = false;
        //    string szUpdate = string.Empty;

        //    szUpdate = "UPDATE tblCategories SET NomCatego = '" + nouveauNom + "'";
        //    string szWhere = " WHERE NoCatego = " + m_Usager.m_IdCategorie;
        //    szUpdate += szWhere;

        //    try
        //    {
        //        OleDbCommand command = new OleDbCommand(szUpdate, m_cnADONetConnection);
        //        command.ExecuteNonQuery();
        //        success = true;
        //    }
        //    catch (Exception e)
        //    {
        //        string err = string.Empty;
        //        err = e.ToString();
        //    }
        //    return success;
        //}
        //internal bool ModifierUneSousCategorie(ref Usager m_Usager, string nouveauNom)
        //{
        //    bool success = false;
        //    string szUpdate = string.Empty;

        //    szUpdate = "UPDATE tblSousCatego SET NomSousCatego = '" + nouveauNom + "'";
        //    //string szWhere = " WHERE IdCategorie = " + m_Usager.m_IdCategorie;
        //    string szWhere = " WHERE IdSousCatego = " + m_Usager.m_idSousCategorie;
        //    //string szAnd = " AND IdSousCatego = " + m_Usager .m_idSousCategorie ;
        //    szUpdate += szWhere;// + szAnd ;

        //    try
        //    {
        //        OleDbCommand command = new OleDbCommand(szUpdate, m_cnADONetConnection);
        //        command.ExecuteNonQuery();
        //        success = true;
        //    }
        //    catch (Exception e)
        //    {
        //        string err = string.Empty;
        //        err = e.ToString();
        //    }
        //    return success;
        //}

        //internal bool ModifierUnUsager(ref Usager m_Usager, string nouveauNom)
        //{
        //    bool success = false;
        //    string szUpdate = string.Empty;
        //    szUpdate = "UPDATE tblUsagers SET NomUsager = '" + nouveauNom + "'";
        //    string szWhere = " WHERE IdUsager = " + m_Usager.m_IdUsager;
        //    szUpdate += szWhere;
        //    try
        //    {
        //        OleDbCommand command = new OleDbCommand(szUpdate, m_cnADONetConnection);
        //        command.ExecuteNonQuery();
        //        success = true;
        //    }
        //    catch (Exception e)
        //    {
        //        string err = string.Empty;
        //        err = e.ToString();
        //    }
        //    return success;
        //}
        internal void AjouterCombinaisonSecret(int usager, int categorie, int souscategorie, int site, string addrs, string identifiant, string mtps, string infoscompl)
        {
            //bool success = false;
            string szInsert = string.Empty;
            szInsert = " INSERT INTO tblSecrets VALUES (" + usager + ", " + categorie + ", " + souscategorie + ", " + site + ", '" + addrs + "', '" + identifiant + "', '" + mtps + "', '" + infoscompl + "')";

                try
                {
                    OleDbCommand command = new OleDbCommand(szInsert, m_cnADONetConnection);
                    command.ExecuteNonQuery();
                    //success = true;
                }
                catch (Exception ex)
                {
                    string err = string.Empty;
                    err = ex.ToString();
                }
            //throw new NotImplementedException();
        }
        internal bool AjouterNouveauSite(string nouveauNom, int idsouscatego)
        {
            bool success = false;
            try
            {
                Int32 num = ProchainNoSite();
                //Int32 idparent = ObtenirIdSite(categorieParent);//
                string szInsert = "INSERT INTO tblSites VALUES (" + num + ", '" + nouveauNom + "', " + idsouscatego + ")";
                OleDbCommand command = new OleDbCommand(szInsert, m_cnADONetConnection);
                command.ExecuteNonQuery();
                success = true;
                return success;
            }
            catch (Exception ex)
            {
                success = false;
                {
                    success = false;
                    string err = string.Empty;
                    err = ex.ToString();
                    return success;
                }
            //return success;
            }
        }

        //internal bool SiteExiste(string nomsite, ref Usager usager)
        //{
        //    string sql;
        //    bool resultat = false;
        //    sql = " SELECT COUNT(IdCatego) FROM tblSites WHERE IdUsager = " + usager.m_IdUsager + " AND IdCatego = " + usager.m_IdCategorie
        //                           + " AND IdSousCatego = " + usager.m_idSousCategorie + " AND NomSite = '" + nomsite + "'";

        //    try
        //    {
        //        m_DataTable = new DataTable();
        //        m_DataTable.Clear();
        //        m_dataAdatper = new OleDbDataAdapter(sql, m_cnADONetConnection);
        //        OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
        //        m_dataAdatper.Fill(m_DataTable);
        //        int i = Convert.ToInt32(m_DataTable.Rows[0][0]);
        //        //si trouvé, obtenir le idsite et le mettre dans usager.IdSite
        //        if(i == 1)
        //        {
        //            //Int32 idsite = ObtenirIdSite(nomsite);
        //            usager .m_idSite = ObtenirIdSite(nomsite);
        //        }
        //        return i >= 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        string mess = ex.ToString();
        //        return resultat;
        //    }

        //    throw new NotImplementedException();
        //}

        //internal bool AjouterNouveauSite(string nouveauNom, ref Usager Usager)
        //{
        //    bool success = false;
        //    try
        //    {
        //        Int32 num = ProchainNoSite();
        //        //Int32 idparent = ObtenirIdSite(categorieParent);//
        //        string szInsert = "INSERT INTO tblSites VALUES (" + num + ", '" + nouveauNom + "', " +Usager.m_IdCategorie + ", " +Usager.m_idSousCategorie + ", " + Usager .m_IdUsager  + ")";
        //        OleDbCommand command = new OleDbCommand(szInsert, m_cnADONetConnection);
        //        command.ExecuteNonQuery();
        //        success = true;
        //        Usager.m_idSite = num;
        //    }
        //    catch (Exception ex)
        //    {
        //        success = false;
        //        string err = string.Empty;
        //        err = ex.ToString();
        //    }
        //    return success;
        //}
        //internal bool AjouterNouveauSite(string nouveauNom, int idcatego, int idsouscatego, int idUsager)//, ref int NouveauIdSite
        //{
        //    bool success = false;
        //    try
        //    {
        //        Int32 num = ProchainNoSite();
        //        //Int32 idparent = ObtenirIdSite(categorieParent);//
        //        string szInsert = "INSERT INTO tblSites VALUES (" + num + ", '" + nouveauNom + "', " + idcatego + ", " + idsouscatego + ", " + idUsager + ")";
        //        OleDbCommand command = new OleDbCommand(szInsert, m_cnADONetConnection);
        //        command.ExecuteNonQuery();
        //        success = true;
        //        //intNouveauIdSite = num;
        //    }
        //    catch (Exception ex)
        //    {
        //        success = false;
        //        string err = string.Empty;
        //        err = ex.ToString();
        //    }
        //    return success;
        //}
        /// <summary>
        /// Ajoute une nouvellesous catégorie pour une catégorie qui est déjà associée à un usager
        /// </summary>
        /// <param name="nouveauNom"></param>
        /// <param name="usager"></param>
        /// <returns></returns>
        //public bool AjouterNouvelleSousCategorie(string nouveauNom, ref Usager usager)
        //{
        //    bool succes = false;
        //    // faire comme les catégories
        //    // Ajouter dans jctSousCatego aussi, dans une transaction
        //    // A) vérifier si la sous catégorie exist pour cette catégorie et cet usager
        //    #region VerificationExistanceSousCategorie       
        //    bool existe = NomExiste("tblSousCatego", "NomSousCatego", nouveauNom);

        //    #endregion
        //    #region ExistePourUsagerCatego
        //    if (existe)// on vérifie si l'usager a la sous catégorie pour la catégorie
        //    {
        //        int idSousCatego = ObtenirIdSousCategorie(nouveauNom);
        //        existe = ExisteUsagerSousCategoCatego(usager, idSousCatego);// Si existe déjà on informe et on ne fait rien
        //        // sinon on ajoute dans la table jctSousCatego
        //    }
        //    else
        //    {
        //        // on ajoute dans les 2 tables
        //        try
        //        {
        //            string szInsert = string.Empty;
        //            Int32 nouveauIDSousC = 0;
        //            nouveauIDSousC = ProchainNoSousCategorie();
        //            szInsert = "INSERT INTO tblSousCatego VALUES (" + usager.m_IdCategorie + ", " + nouveauIDSousC + ", '" + usager .m_IdUsager  + "')";

        //            OleDbCommand command = new OleDbCommand(szInsert, m_cnADONetConnection);
        //            command.ExecuteNonQuery();
        //            succes = true;
        //            usager.m_idSousCategorie = nouveauIDSousC;
        //        }
        //        catch (Exception ex)
        //        {
        //            string err = ex.ToString();
        //            succes = false;
        //        }
        //    }

        //    //bool succes = false;
        //    //// Ajouter IdCategorie, IdSousCategorie, NomSousCategorie
        //    //string szInsert = string.Empty;
        //    //Int32 nouveauIDSousC = 0;
        //    //try
        //    //{
        //    //    nouveauIDSousC = ProchainNoSousCategorie();
        //    //    szInsert = "INSERT INTO tblSousCatego VALUES (" + usager.m_IdCategorie + ", " + nouveauIDSousC + ", '" + nouveauNom + "')";

        //    //    OleDbCommand command = new OleDbCommand(szInsert, m_cnADONetConnection);
        //    //    command.ExecuteNonQuery();
        //    //    succes = true;
        //    //    usager.m_idSousCategorie = nouveauIDSousC;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    string err = ex.ToString();
        //    //    succes = false;
        //    //}
        //    return succes;
        //}
        //#endregion


        //public bool AjouterUsager_A_Categorie(string categorie, int usager)
        //{
        //    bool retour = false;
        //    // obtenir l'Id de la catégorie
        //    int id = ObtenirIdCategorie(categorie);
        //    // faire le insert pour l'usager
        //    string szInsert = "INSERT INTO jctUsagerCatgo VALUES(" + usager + "," + id + ")";
        //    OleDbCommand command = new OleDbCommand(szInsert, m_cnADONetConnection);
        //    command.ExecuteNonQuery();
        //    retour = true;
        //    return retour;
        //}
        //public bool AjouterSousCategorie(string nouveauNom,ref Usager usager, int idexiste = 0)
        //{
        //    bool retour = false;
        //    bool souscatego = false;
        //    bool jctPresent = false;
        //    int num = 0;
        //    try
        //    {
        //        #region VerifExistanceSousCategorie
        //        int idsouscatego = ObtenirIdSousCategorie(nouveauNom);
        //        if (idsouscatego > 0)
        //        {
        //            souscatego = true;
        //            // On vérifie alors dans jctSousCatego pour voir si usager et catégorie ont cette sous catégorie
        //            int idcategorie = ObtenirIdCategorieDansJct(ref usager, idsouscatego);
        //            // On garde un flag
        //            if (idcategorie > 0)
        //            {
        //                jctPresent = true;
        //            }
        //            else
        //            {
        //                jctPresent = false;
        //                num = idsouscatego;
        //            }
        //        }
        //        else
        //        {
        //            // On créé une nouvelle sous catégorie
        //            num = ProchainNoSousCategorie();
        //            //num = idsouscatego + 1;
        //        }
        //        #endregion
                
        //        using (OleDbConnection connection = new OleDbConnection(m_maconnetionstring))
        //        {
        //            OleDbCommand command = new OleDbCommand();
        //            OleDbTransaction transaction = null;

        //            // Set the Connection to the new OleDbConnection.
        //            command.Connection = connection;
        //            try
        //            {
        //                // Open the connection and start the transaction.
        //                connection.Open();
        //                transaction = connection.BeginTransaction();
        //                // Assign transaction object for a pending local transaction.
        //                command.Transaction = transaction;

        //                if (idexiste == 0)
        //                {
        //                    // Execute the commands.
        //                    command.CommandText = "INSERT INTO tblSousCatego VALUES (" + num   + ",'" + nouveauNom + "')";
        //                    command.ExecuteNonQuery();
        //                }

        //                // Assign transaction object for a pending local transaction.
        //                command.CommandText = "INSERT INTO jctSousCatego VALUES ("+ usager.m_IdCategorie + "," + num +"," + usager.m_IdUsager + ")";
        //                command.ExecuteNonQuery();

        //                // Commit the transaction.
        //                transaction.Commit();
        //                retour = true;
        //            }
        //            catch (Exception transEx)
        //            {
        //                string err = string.Empty;
        //                err = transEx.ToString();
        //                try
        //                {
        //                    // Attempt to roll back the transaction.
        //                    transaction?.Rollback();
        //                }
        //                catch
        //                {
        //                    // Handle any errors that may have occurred during the rollback.
        //                    return false;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string mess = ex.ToString();
        //    }
        //    return retour ;
        //}

        //private int ObtenirIdCategorieDansJct(ref Usager usager, int idsouscatego)
        //{
        //    string sql;
        //    bool resultat = false;
        //    sql = " SELECT IdSousCatego FROM jctSousCatego WHERE IdUsager = " + usager.m_IdUsager + " AND IdCatego = " + usager.m_IdCategorie;
        //    try
        //    {
        //        m_DataTable = new DataTable();
        //        m_DataTable.Clear();
        //        m_dataAdatper = new OleDbDataAdapter(sql, m_cnADONetConnection);
        //        OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
        //        m_dataAdatper.Fill(m_DataTable);
        //        int nbrec = m_DataTable.Rows.Count;
        //        if (nbrec == 0)
        //        {
        //            // ajouter la sous catégorie pour cet usager-catégorie dans la table de jonction
        //            nbrec = 100;
        //            return 0;
        //        }
        //        int i = Convert.ToInt32(m_DataTable.Rows[0][0]);
        //        return Convert.ToInt32(m_DataTable.Rows[0][0]);
        //    }
        //    catch (Exception ex)
        //    {
        //        string mess = ex.ToString();
        //        return 0;
        //    }
        //    //return resultat;
        //    //throw new NotImplementedException();
        //}

        public bool AjouterCategorie_v2(string nouveauNom, int idusager, int idexiste = 0)
        {
            bool retour = false;
            int idCategorie = 0;
            try
            {//vérifier si la valeur existe déjà
                bool present = VerifierPresenceCombinaison(idusager, nouveauNom);
                if (present)
                {
                    // Obtenir l'Id de la catégorie en question
                    Int32 unid = ObtenirIdCategorie(nouveauNom);
                    idCategorie = unid;
                }
                else
                {
                    idCategorie = ProchainNoCategorie();
                }
                using (OleDbConnection connection = new OleDbConnection(m_maconnetionstring))
                {
                    OleDbCommand command = new OleDbCommand();
                    OleDbTransaction transaction = null;
                    // Set the Connection to the new OleDbConnection.
                    command.Connection = connection;
                    try
                    {
                        // Open the connection and start the transaction.
                        connection.Open();
                        transaction = connection.BeginTransaction();
                        // Assign transaction object for a pending local transaction.
                        command.Transaction = transaction;

                        if (!present)
                        {
                            // Execute the commands.
                            //command.CommandText = "INSERT INTO tblCategories VALUES ('" + nouveauNom + "', " + num + ", " + idusager + ")";
                            command.CommandText = "INSERT INTO tblCategories VALUES (" + idCategorie +", '" + CorrigeInput(nouveauNom) + "')";
                            command.ExecuteNonQuery();
                        }

                        // Assign transaction object for a pending local transaction.
                        command.CommandText = "INSERT INTO jctUsagerCategorie VALUES (" + idusager + ", " + idCategorie + ")";
                        command.ExecuteNonQuery();

                        // Commit the transaction.
                        transaction.Commit();
                    }
                    catch (Exception transEx)
                    {
                        #region catch
                        string err = string.Empty;
                        err = transEx.ToString();
                        try
                        {
                            // Attempt to roll back the transaction.
                            transaction?.Rollback();
                        }
                        catch
                        {
                            // Handle any errors that may have occurred during the rollback.
                            return false;
                        }
                        
                    }
                }
                retour = true;
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
            }
#endregion
            return retour;
        }
        public bool AjouterSousCategorie_v2(string nouveauNom, ref Usager_v2 U, int idexiste = 0)
        {
            bool retour = false;
            int nb;
            int idSousCategorie = 0;
            try
            {//vérifier si la valeur existe déjà
                nb = ValeurUtiliseeParPlusieurs(U.IdUsager, "SousCategorie", nouveauNom);
                return false;
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                return false;
            }            
        }

        //private bool ModifierUnNomDeSite(Usager m_Usager)
        //{
        //    bool succes = false;
        //    string szUpdate = string.Empty;
        //    string szSet = string.Empty;
        //    string szValues = string.Empty;
        //    string szWhere = string.Empty;
        //    szUpdate = "UPDATE tblSites ";
        //    szSet = "SET NomSite = '" + m_Usager.m_donnees.NomAppli ;
        //    szWhere = "' WHERE IdUsager = " + m_Usager.m_IdUsager + " AND IdCatego = " + m_Usager.m_IdCategorie
        //                           + " AND IdSousCatego = " + m_Usager.m_idSousCategorie + " AND idSite =  " + m_Usager.m_idSite;

        //    try
        //    {
        //        szUpdate += szSet + szWhere;
        //        OleDbCommand command = new OleDbCommand(szUpdate, m_cnADONetConnection);
        //        command.ExecuteNonQuery();
        //        succes = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        string err = string.Empty;
        //        err = ex.ToString();
        //        throw;
        //    }
        //    return succes;
        //}
        //internal bool ModifierCombinaisonSecret(ref Usager m_Usager)
        //{
        //    #region settings
        //    // J'ai besoin d'ajouter une MAJ du nom de site dan la table tblSites
        //    bool success = false;
        //    string szUpdate = string.Empty;
        //    string szSet = string.Empty;
        //    string szValues = string.Empty;
        //    string szWhere = string.Empty;
        //    szUpdate = "UPDATE tblSecrets ";
        //    szSet = "SET AdresseSite = '" + m_Usager.m_donnees.AdresseSite + "', Identifiant = '" + m_Usager.m_donnees.Identifiant + "', MotPass = '" + m_Usager.m_donnees.Motpass + "', InfoCompl = '" + m_Usager.m_donnees.InfosCompl + "' ";
        //    szWhere = "WHERE IdUsager = " + m_Usager.m_IdUsager + " AND IdCategorie = " + m_Usager.m_IdCategorie
        //                           + " AND IdSousCategorie = " + m_Usager.m_idSousCategorie + " AND idSite =  " + m_Usager.m_idSite;
        //    #endregion
        //    // Mettre dans une transaction
        //    using (OleDbConnection connection = new OleDbConnection(m_maconnetionstring))
        //    {
        //        OleDbCommand command = new OleDbCommand();
        //        OleDbTransaction transaction = null;
        //        // Set the Connection to the new OleDbConnection.
        //        command.Connection = connection;
        //        try
        //        {
        //            // Open the connection and start the transaction.
        //            connection.Open();
        //            transaction = connection.BeginTransaction();
        //            // Assign transaction object for a pending local transaction.
        //            command.Transaction = transaction;

        //            // Execute the commands.
        //            command.CommandText = szUpdate + szSet + szWhere ;
        //            command.ExecuteNonQuery();
        //            // 

        //            szUpdate = "UPDATE tblSites ";
        //            szSet = "SET NomSite = '" + m_Usager.m_donnees.NomAppli;
        //            szWhere = "' WHERE IdUsager = " + m_Usager.m_IdUsager + " AND IdCatego = " + m_Usager.m_IdCategorie
        //                                   + " AND IdSousCatego = " + m_Usager.m_idSousCategorie + " AND idSite =  " + m_Usager.m_idSite;

        //            command.CommandText = szUpdate + szSet + szWhere;
        //            command.ExecuteNonQuery();

        //            //success = ModifierUnNomDeSite(m_Usager);
        //            // Commit the transaction.
        //            transaction.Commit();
        //            return true;
        //        }
        //        catch (Exception transEx)
        //        {
        //            string err = string.Empty;
        //            err = transEx.ToString();
        //            try
        //            {
        //                // Attempt to roll back the transaction.
        //                transaction?.Rollback();
        //            }
        //            catch
        //            {
        //                // Handle any errors that may have occurred during the rollback.
        //                return false;
        //            }
        //        }
        //    }

        //    return success;
        //    throw new NotImplementedException();
        //}       

        //private bool ExisteUsagerSousCategoCatego(Usager usager, int idSousCatego)
        //{
        //    string sql;
        //    bool resultat = false; 
        //    sql = " SELECT IdSousCatego FROM jctSousCaego WHERE IdUsager = " + usager .m_IdUsager + " AND IdCatego = " + usager .m_IdCategorie ;
        //    try
        //    {
        //        m_DataTable = new DataTable();
        //        m_DataTable.Clear();
        //        m_dataAdatper = new OleDbDataAdapter(sql, m_cnADONetConnection);
        //        OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
        //        m_dataAdatper.Fill(m_DataTable);
        //        int i = Convert.ToInt32(m_DataTable.Rows[0][0]);
        //        return Convert.ToInt32(m_DataTable.Rows[0][0]) == idSousCatego;
        //    }
        //    catch (Exception ex)
        //    {
        //        string mess = ex.ToString();
        //        return resultat;
        //    }
        //    return resultat;
        //}

        private bool NomExiste(string latable, string lechamp, string lenom)
        {
            bool resultat = false;
           string sql;
            sql = " SELECT COUNT (" + lechamp + ") FROM " + latable + " WHERE " + lechamp + " = '" + lenom +"'" ;
            try
            {
                m_DataTable = new DataTable();
                m_DataTable.Clear();
                m_dataAdatper = new OleDbDataAdapter(sql, m_cnADONetConnection);
                OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                int i = Convert .ToInt32 ( m_DataTable.Rows[0][0]);
                return i >= 1;
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                return resultat ;
            }            
        }

        //public bool AjouterNouvelleCategorie(string nouveauNom)
        //{
        //    bool retour = false;
        //    try
        //    {
        //        Int32 num = ProchainNoCategorie();
        //        string szInsert = "INSERT INTO tblCategories VALUES ('" + nouveauNom + "', " + num + ")";
        //        OleDbCommand command = new OleDbCommand(szInsert, m_cnADONetConnection);
        //        command.ExecuteNonQuery();
        //        retour = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        string mess = ex.ToString();
        //    }

        //    return retour;
        //}
        
        //public bool AjouterCategorie(string nouveauNom, Usager usager)
        //{
        //    bool retour = false;
        //    // vérifier la présence de la nouvelle catégorie.  Si pas présente on ajoute une nouvelle
        //    //try
        //    //{
        //    //    Int32 num = ProchainNoCategorie();
        //    //    string szInsert = "INSERT INTO tblCategories VALUES ('" + nouveauNom + "', " + num + ", " + usager + ")";
        //    //    OleDbCommand command = new OleDbCommand(szInsert, m_cnADONetConnection);
        //    //    command.ExecuteNonQuery();
        //    //    retour = true;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    string mess = ex.ToString();
        //    //}
        //    return retour;
        //}

        public bool ModifierUnUsager()
        {
            return false;
        }

        public bool AjouterUsager_v2(string nouveauNom)
        {
            //MessageBox.Show("En développement");
            bool retour = false;
            try
            {
                // Vérifier si l'usager existe
                if (!UsagerExiste(nouveauNom)) // si esiste pas, ajouter
                {
                    // obtenir le prochain numéro unique disponible
                    Int32 num = ProchainIdUsager() + 1;

                    //string szInsert = "INSERT INTO tblUsagers VALUES ('" + nouveauNom + "', " + num + ")";

                    string sql = "INSERT INTO tblUsagers  VALUES (" + num + ", '" + nouveauNom + "'" +  ")";
                    OleDbCommand command = new OleDbCommand(sql, m_cnADONetConnection);
                    command.ExecuteNonQuery();
                    retour = true;
                }
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                retour = false;
            }
            return retour;
        }
                
        private int ObtenirNbUtilisateurs(string select)
        {
            string szSelect = select;
            int i;
            try
            {
                m_DataTable = new DataTable();
                m_DataTable.Clear();
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                i = m_DataTable.Rows.Count;

                i = Convert.ToInt32(m_DataTable.Rows[0][0]);
                return i;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<string> ObtenirUsagers()
        {
            int i = 0;
            string szSelect; //, szWHERE;
            List<string> lstUsagers = new List<string>();
            szSelect = "SELECT distinct NomUsager " + " FROM tblUsagers";// +" ORDER BY " + szChampCbo;
            //Logger lg = new Logger(szSelect, m_cheminLog);
            try
            {
                m_DataTable = new DataTable();
                m_DataTable.Clear();
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                i = m_DataTable.Rows.Count;

                if (i == 0)
                {
                    //lstUsagers.Add("Ajouter un utilisateur");
                }
                else
                {
                    for (i = 0; i < m_DataTable.Rows.Count; i++)
                    {
                        lstUsagers.Add(m_DataTable.Rows[i]["NomUsager"].ToString());// + " " + m_DataTable.Rows[i]["Prenom"].ToString() + Environment.NewLine;
                    }
                }

            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                lg = new Logger(mess, m_cheminLog);
            }
            finally
            {
                m_DataTable.Clear();
                m_DataTable.Dispose();
                m_dataAdatper.Dispose();

            }
            return lstUsagers;

        }
        
        public int ObtenirIdUsager(string nomUsager)
        {
            //int i = 0;
            string szSelect = "SELECT IdUsager FROM tblUsagers   WHERE NomUsager = ?";
            int idUsager = -1;

            try
            {
                using (OleDbCommand cmd = new OleDbCommand(szSelect, m_cnADONetConnection))
                {
                    cmd.Parameters.AddWithValue("?", nomUsager); // Paramètre sécurisé contre l'injection SQL

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        idUsager = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                //MessageBox.Show("Erreur lors de la récupération de l'IdSite : " + ex.Message);
            }
            return idUsager;
        }
        public int ObtenirIdSite(string nomSite)
        {
            int i = 0;
            string szSelect;
            szSelect = "SELECT IdSite " + " FROM tblSites where NomSite = '" + nomSite + "'";

            try
            {
                m_DataTable = new DataTable();
                m_DataTable.Clear();
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                i = m_DataTable.Rows.Count;

                //if (i > 0)
                //{
                //    lstSousCategories.Add("Ajouter une catégorie");
                //}
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
            }

            return (Int32)m_DataTable.Rows[0]["IdSite"];
        }
        internal string ObtenirNomUsager(int idUsager)
        {
            string szSelect;
            string retour = string.Empty;
            szSelect = "SELECT NomUsager " + " FROM tblUsagers where IdUsager = " + idUsager;
            //Logger lg = new Logger(szSelect, m_cheminLog);
            try
            {
                m_DataTable = new DataTable();
                m_DataTable.Clear();
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                //i = m_DataTable.Rows.Count;
                retour = (string)m_DataTable.Rows[0]["NomUsager"];
                return retour;

            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                lg = new Logger(mess, m_cheminLog);
                return "ERREUR";
            }
        }

        internal string ObtenirNomSousCategorie(int id)
        {
            string szSelect;
            string retour = string.Empty;
            szSelect = "SELECT NomSosCategorie " + " FROM tblSousCategories where IdSousCategorie = " + id;

            try
            {
                m_DataTable = new DataTable();
                m_DataTable.Clear();
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                //i = m_DataTable.Rows.Count;
                retour = (string)m_DataTable.Rows[0]["NomSousCategorie"];
                return retour;

            }
            catch (Exception ex)
            {
                //string mess = ex.ToString();
                throw;
            }
        }

        internal string ObtenirNomCategorie(int idcategorie)
        {
            string retour = string.Empty;
            string szSelect;

            szSelect = "SELECT NomCategorie " + " FROM tblCategories where IdCategorie = " + idcategorie;
            try
            {
                m_DataTable = new DataTable();
                m_DataTable.Clear();
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                //i = m_DataTable.Rows.Count;
                retour = (string)m_DataTable.Rows[0]["NomCatego"];
                return retour;

            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                return "ERREUR";
            }
        }
       
        /// <summary>
        /// Retourne le numéro de la sous-catégorie si trouvée dans la table
        /// </summary>
        /// <param name="mSousCategorie"></param>
        /// <returns>Un identifiant</returns>
        internal int ObtenirIdSousCategorie(string mSousCategorie)
        {
            int i = 0;
            string szSelect;
            szSelect = "SELECT IdSousCatgorie " + " FROM tblSousCategories where NomSousCategorie = '" + mSousCategorie + "'";
            try
            {
                m_DataTable = new DataTable();
                m_DataTable.Clear();
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                i = m_DataTable.Rows.Count;

                if (i > 0)
                {
                    return (Int32)m_DataTable.Rows[0]["IdSousCatgorie"];
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                return 0;
            }

            
        }
        internal int ObtenirIdCategorie(string nom_Categorie)
        {
            int i = 0;
            string szSelect;
            if (string.IsNullOrWhiteSpace(nom_Categorie)) return i;

            szSelect = "SELECT IdCategorie" + " FROM tblCategories where NomCategorie = '" + nom_Categorie + "'";

            try
            {
                m_DataTable = new DataTable();
                m_DataTable.Clear();
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                i = m_DataTable.Rows.Count;

                //if (i > 0)
                //{
                //    lstSousCategories.Add("Ajouter une catégorie");
                //}
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
            }

            return (Int32 ) m_DataTable.Rows[0]["IdCategorie"];

            throw new NotImplementedException();
        }
        internal int ObtenirIdCategorie_UsagerSousCatego(Usager_v2 u)
        {
            int i = 0;

            string szSelect, szFROM, szWHERE;

            szSelect = "SELECT jctUsagerCategorie.IdCategorie ";
            szFROM = "FROM jctCategorieSousCategorie INNER JOIN jctUsagerCategorie ON jctCategorieSousCategorie.IdCategorie = jctUsagerCategorie.IdCategorie ";
            szWHERE = "WHERE (((jctUsagerCategorie.IdUsager)=" + u.IdUsager + ") AND ((jctCategorieSousCategorie.IdSousCategorie)=" + u.IdSousCategorie + "))";
            szSelect += szFROM + szWHERE;

            try
            {
                m_DataTable = new DataTable();
                m_DataTable.Clear();
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                i = m_DataTable.Rows.Count;
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
            }

            return (Int32)m_DataTable.Rows[0][0];
        }

        internal int ValeurUtiliseeParPlusieurs(int IdUsager, string filtre, string valeur)
        {
            int nUser = 0;
            string szSelect ,szWhere = string.Empty, szAnd = string.Empty, tblJct = string.Empty;
            string leftjion = string.Empty;
            switch (filtre)
            {
                case "Categorie":
                    break;
                case "SousCategorie":
                    tblJct = "jctCategorieSousCategorie" ;
                    szWhere = " WHERE IdUsager = " + IdUsager;
                    szAnd = " AND IdSousCategorie = " + ObtenirIdSousCategorie(valeur);
                    leftjion = " LEFT JOIN jctUsagerCategorie ON tblCategories.IdCategorie = jctUsagerCategorie.IdCategorie ";
                    break;
            }
            szSelect = "SELECT COUNT(iDUsager) FROM " + tblJct + szWhere ;
            return -1;
        }
        internal bool VerifierPresenceCombinaison(int IdUsager, string nomCatego)
        {
            bool presence = false;
            string szSelect;
            szSelect = "SELECT COUNT(NomCategorie) FROM tblCategories "
                       + "LEFT JOIN jctUsagerCategorie ON tblCategories.IdCategorie = jctUsagerCategorie.IdCategorie "
                       + "WHERE tblCategories.NomCategorie = '" + nomCatego + "'";
            
            m_DataTable = new DataTable();
            m_DataTable.Clear();
            m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
            OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
            m_dataAdatper.Fill(m_DataTable);

            if ((Int32)m_DataTable.Rows[0][0] >= 1)
            {
                presence = true;
            }
            return presence;
        }
        private bool VerifierPresenceSousCategorie(ref Usager_v2 u, string text)
        {
            bool presence = false;
            string szSelect;
            szSelect = "SELECT COUNT(NomSousCategorie) FROM tblSousCategories ";
            szSelect += "WHERE tblSousCategories.NomSousCategorie = '" + text + "'";
            m_DataTable = new DataTable();
            m_DataTable.Clear();
            m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
            OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
            m_dataAdatper.Fill(m_DataTable);

            if ((Int32)m_DataTable.Rows[0][0] >= 1)
            {
                presence = true;
            }
            return presence;
        }
        private bool VerifierPresenceSite(ref Usager_v2 u, string text)
        {
            bool presence = false;
            string szSelect;
            szSelect = "SELECT COUNT(NomSite) FROM tblSites ";
            szSelect += "WHERE tblSites.NomSite = '" + text + "'";
            m_DataTable = new DataTable();
            m_DataTable.Clear();
            m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
            OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
            m_dataAdatper.Fill(m_DataTable);

            if ((Int32)m_DataTable.Rows[0][0] >= 1)
            {
                presence = true;
            }
            return presence;
        }

        internal void ObtenirSitesPourAjouts(ref List<string> lstSites, Usager_v2 U)
        {
            int i;
            string szSelect, szFROM, szFrom2, szWHERE, szWHERE2, szORDERBY;
            #region commenté
            // le select pour obtenir la liste des site disponibles, ceux des autres usagers
            //            SELECT DISTINCT tblSites.NomSite
            //FROM jctUsagerCategorie INNER JOIN(jctCategorieSousCategorie INNER JOIN(tblSites INNER JOIN jctSousCategorieSite ON tblSites.IdSite = jctSousCategorieSite.IdSite) ON(jctCategorieSousCategorie.IdCategorie = jctSousCategorieSite.IdCategorie) AND(jctCategorieSousCategorie.IdSousCategorie = jctSousCategorieSite.IdSousCategorie)) ON(jctUsagerCategorie.IdCategorie = jctCategorieSousCategorie.IdCategorie) AND(jctUsagerCategorie.IdUsager = jctCategorieSousCategorie.IdUsager)
            //WHERE(((tblSites.NomSite)Not In(SELECT DISTINCT tblSites.NomSite
            //FROM jctUsagerCategorie INNER JOIN(jctCategorieSousCategorie INNER JOIN(tblSites INNER JOIN jctSousCategorieSite ON tblSites.IdSite = jctSousCategorieSite.IdSite) ON(jctCategorieSousCategorie.IdCategorie = jctSousCategorieSite.IdCategorie) AND(jctCategorieSousCategorie.IdSousCategorie = jctSousCategorieSite.IdSousCategorie)) ON(jctUsagerCategorie.IdCategorie = jctCategorieSousCategorie.IdCategorie) AND(jctUsagerCategorie.IdUsager = jctCategorieSousCategorie.IdUsager)
            //WHERE(((jctSousCategorieSite.IdUsager) = 2)))));
            #endregion

            szSelect = "SELECT DISTINCT tblSites.NomSite ";
            szFROM = "FROM jctUsagerCategorie INNER JOIN(jctCategorieSousCategorie INNER JOIN(tblSites INNER JOIN jctSousCategorieSite ON tblSites.IdSite = jctSousCategorieSite.IdSite) ON(jctCategorieSousCategorie.IdCategorie = jctSousCategorieSite.IdCategorie) AND(jctCategorieSousCategorie.IdSousCategorie = jctSousCategorieSite.IdSousCategorie)) ON(jctUsagerCategorie.IdCategorie = jctCategorieSousCategorie.IdCategorie) AND(jctUsagerCategorie.IdUsager = jctCategorieSousCategorie.IdUsager) ";
            szWHERE = "WHERE(((tblSites.NomSite)Not In(SELECT DISTINCT tblSites.NomSite ";
            szFrom2 = "FROM jctUsagerCategorie INNER JOIN(jctCategorieSousCategorie INNER JOIN(tblSites INNER JOIN jctSousCategorieSite ON tblSites.IdSite = jctSousCategorieSite.IdSite) ON(jctCategorieSousCategorie.IdCategorie = jctSousCategorieSite.IdCategorie) AND(jctCategorieSousCategorie.IdSousCategorie = jctSousCategorieSite.IdSousCategorie)) ON(jctUsagerCategorie.IdCategorie = jctCategorieSousCategorie.IdCategorie) AND(jctUsagerCategorie.IdUsager = jctCategorieSousCategorie.IdUsager) ";
            szWHERE2 = "WHERE(((jctSousCategorieSite.IdUsager) = " + U.IdUsager + "))))) ";
            szORDERBY = "ORDER BY tblSites.NomSite";

            szSelect += szFROM + szWHERE + szFrom2 + szWHERE2 + szORDERBY;

            try
            {
                m_DataTable = new DataTable();
                m_DataTable.Clear();
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                i = m_DataTable.Rows.Count;
                i = m_DataTable.Rows.Count;
                if (i > 0)
                {
                    for (i = 0; i < m_DataTable.Rows.Count; i++)
                    {
                        lstSites.Add(m_DataTable.Rows[i]["NomSite"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                string szmess = ex.ToString();
                Logger lg = new Logger(szmess, m_cheminLog);
            }
        }


        internal void ObtenirSousCategoriesPourAjouts(ref List<string> lstSousCategories, Usager_v2 U)
        {
            int i;

            string szSelect, szFROM, szFrom2, szWHERE, szWHERE2, szORDERBY;

            szSelect = "SELECT DISTINCT tblSousCategories.NomSousCategorie ";
            szFROM = "FROM tblSousCategories INNER JOIN jctCategorieSousCategorie ON tblSousCategories.IdSousCatgorie = jctCategorieSousCategorie.IdSousCategorie ";
            szWHERE = "WHERE(((tblSousCategories.NomSousCategorie)Not In(SELECT DISTINCT tblSousCategories.NomSousCategorie ";
            szFrom2 = "FROM jctUsagerCategorie INNER JOIN(tblSousCategories INNER JOIN jctCategorieSousCategorie ON tblSousCategories.IdSousCatgorie = jctCategorieSousCategorie.IdSousCategorie) ON jctUsagerCategorie.IdCategorie = jctCategorieSousCategorie.IdCategorie ";
            szWHERE2 = "WHERE(((jctCategorieSousCategorie.IdUsager) = " + U.IdUsager + "))))) ";
            szORDERBY = "ORDER BY tblSousCategories.NomSousCategorie";

            //szSelect += szFROM + szWHERE + szORDERBY;
            szSelect += szFROM + szWHERE + szFrom2 + szWHERE2 + szORDERBY;

            try
            {
                m_DataTable = new DataTable();
                m_DataTable.Clear();
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                i = m_DataTable.Rows.Count;

                if (i > 0)
                {
                    //lstSousCategories.Add("Ajouter une sous catégorie");
                    for (i = 0; i < m_DataTable.Rows.Count; i++)
                    {
                        lstSousCategories.Add(m_DataTable.Rows[i]["NomSousCategorie"].ToString());// + " " + m_DataTable.Rows[i]["Prenom"].ToString() + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                throw;
            }
        }

        internal void ObtenirListeSousCategories(ref List<string> lstSousCategories, Usager_v2 usager, bool luimeme = true)
        {
            int i = 0;
            List<string> lstCategoriesID = new List<string>();
            string szSelect;
            string szFROM = string.Empty;
            string szJOIN1 = string.Empty;
            string szJOIN2 = string.Empty;
            string szWhere = string.Empty;
            string szAND = string.Empty;


            szSelect = " SELECT tblSousCategories.NomSousCategorie ";
            szFROM = "FROM jctUsagerCategorie ";
            
            szJOIN1 = "INNER JOIN(tblSousCategories ";
            szJOIN2 = "INNER JOIN jctCategorieSousCategorie ON tblSousCategories.IdSousCatgorie = jctCategorieSousCategorie.IdSousCategorie) ON(jctUsagerCategorie.IdCategorie = jctCategorieSousCategorie.IdCategorie) AND(jctUsagerCategorie.IdUsager = jctCategorieSousCategorie.IdUsager) ";
            szWhere = "WHERE(((jctCategorieSousCategorie.IdUsager) = " + usager.IdUsager + ")";

            if (usager.IdCategorie > 0)
            {
                szAND = ")";
                szAND = "AND ((jctUsagerCategorie.IdCategorie)= " + usager.IdCategorie + ")";
            }

            szSelect += szFROM + szJOIN1 + szJOIN2 + szWhere + szAND;
            szSelect += ")";

            szSelect += " ORDER BY tblSousCategories.NomSousCategorie";
            #region try
            try
            {
                m_DataTable = new DataTable();
                m_DataTable.Clear();
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                i = m_DataTable.Rows.Count;

                if (i > 0)
                {
                    for (i = 0; i < m_DataTable.Rows.Count; i++)
                    {
                        lstSousCategories.Add(m_DataTable.Rows[i]["NomSousCategorie"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                Logger lg = new Logger(mess, m_cheminLog);
            }
            #endregion 
        }

        /// <summary>
        /// Retourne la liste des catégories associées à un usager en particulier
        /// </summary>
        /// <param name="lstCategories"></param>
        /// <param name="idusager"></param>
        /// <param name="associe"></param>

        internal void ObtenirSites(ref List<string> lstSites, Usager_v2 U, bool moimeme = true)
        {
            int i = 0;
            string szSelect;
            string szANDcatego = string.Empty;
            string szAndSousCatego = string.Empty;
            string szEgal = string.Empty;

            szEgal = " = ";
            if (!moimeme) szEgal = " <> ";

            szSelect = "SELECT DISTINCT tblSites.NomSite "
                + "FROM jctUsagerCategorie INNER JOIN(jctCategorieSousCategorie INNER JOIN(tblSites INNER JOIN jctSousCategorieSite ON tblSites.IdSite = jctSousCategorieSite.IdSite) ON jctCategorieSousCategorie.IdSousCategorie = jctSousCategorieSite.IdSousCategorie) ON jctUsagerCategorie.IdCategorie = jctCategorieSousCategorie.IdCategorie "
                + "WHERE (((jctSousCategorieSite.IdUsager)" + szEgal + U.IdUsager + "))";
            //+"WHERE (((jctSousCategorieSite.IdUsager)=" + U.IdUsager + "))";

            if (U.IdCategorie > 0)
            {
                szANDcatego = ")";
                szANDcatego = "AND ((jctSousCategorieSite.IdCategorie)= " + U.IdCategorie + ")";
            }
            if (U.IdSousCategorie > 0)
            {
                szAndSousCatego = ")";
                szAndSousCatego = "AND ((jctSousCategorieSite.IdSousCategorie)= " + U.IdSousCategorie + ")";
            }
            szSelect += szANDcatego + szAndSousCatego;
            try
            {
                m_DataTable = new DataTable();
                m_DataTable.Clear();
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                i = m_DataTable.Rows.Count;
                if (i > 0)
                {
                    for (i = 0; i < m_DataTable.Rows.Count; i++)
                    {
                        lstSites.Add(m_DataTable.Rows[i]["NomSite"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                string szmess = ex.ToString(); 
                Logger lg = new Logger(szmess, m_cheminLog);
            }
        }
        internal void ObtenirListeIdInfos(ref List<int> lst, Usager_v2 m_usager)
        {
            int i = 0;
            string szSelect =string.Empty;
            string szANDcatego = string.Empty;
            string szAndSousCatego = string.Empty;

            szSelect = "SELECT DISTINCT jctTblInfos.IdInfos FROM jctTblInfos";
            try
            {
                m_DataTable = new DataTable();
                m_DataTable.Clear();
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                i = m_DataTable.Rows.Count;
                if (i > 0)
                {
                    for (i = 0; i < m_DataTable.Rows.Count; i++)
                    {
                        lst.Add(Convert.ToInt32 ( m_DataTable.Rows[i]["IdInfos"]));
                    }
                }
            }
            catch (Exception ex)
            {
                string szmess = ex.ToString();
                Logger lg = new Logger(szmess, m_cheminLog);
            }
        }

        /// <summary>
        /// Retourne la liste des catégories
        ///  Pas associées à un usager si associe = false
        ///  Sinon returne la liste pour l'associé en cours
        /// </summary>
        /// <param name="lstCategories"></param>
        /// <param name="U"></param>
        /// <param name="associe"></param>
        internal void ObtenirCategories(ref List<string> lstCategories, Usager_v2 U, bool associe = true)
        {
            int i = 0;
            string szSelect;
            string szWHERE = string.Empty;
            string szFROM = string.Empty;
            string szAND = string.Empty;
            string egal = " = ";
            if (!associe)                
            { 
                egal = " <> ";
                szAND = " AND tblCategories.NomCategorie not in(SELECT tblCategories.NomCategorie FROM tblUsagers " + 
                    "INNER JOIN (tblCategories INNER JOIN jctUsagerCategorie ON tblCategories.IdCategorie = jctUsagerCategorie.IdCategorie) " + 
                    "ON tblUsagers.IdUsager = jctUsagerCategorie.IdUsager " +
                    "WHERE (((tblUsagers.IdUsager)= " + U.IdUsager + ")))";
            }

            szSelect = "SELECT DISTINCT tblCategories.NomCategorie";
            szFROM = " FROM tblUsagers INNER JOIN(tblCategories INNER JOIN jctUsagerCategorie ON tblCategories.IdCategorie = jctUsagerCategorie.IdCategorie) ON tblUsagers.IdUsager = jctUsagerCategorie.IdUsager";
            szWHERE = " WHERE (((tblUsagers.IdUsager)" + egal + U.IdUsager + "))";

            szSelect += szFROM + szWHERE + szAND;

            try
            {
                m_DataTable = new DataTable();
                m_DataTable.Clear();
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                i = m_DataTable.Rows.Count;
                if (i > 0)
                {
                    for (i = 0; i < m_DataTable.Rows.Count; i++)
                    {
                        lstCategories.Add(m_DataTable.Rows[i]["NomCategorie"].ToString());// + " " + m_DataTable.Rows[i]["Prenom"].ToString() + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                string szmess = ex.ToString();
                Logger lg = new Logger(szmess, m_cheminLog);
            }
        }
        
        #endregion

        #region METHODES PRIVÉE
        private bool InitCBase()
        {
            Logger lg;
            // Récupère le dossier parent
            string parent = AppContext.BaseDirectory;
            //lg = new Logger("Dans InitBase()", m_cheminLog);
            string userName = Environment.UserName;

            m_cheminLog = parent + "application.log";

            string dbPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\Base\G_Mtps.accdb"));
             
            lg = new Logger(userName + " accède à " + dbPath, m_cheminLog);

            try
            {
                m_cnADONetConnection = new OleDbConnection();
                string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={m_CheminBD};Persist Security Info=False;";
                m_cnADONetConnection.ConnectionString = connectionString; // @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + m_LaBase;
                m_maconnetionstring = connectionString;
                m_cnADONetConnection.Open();
                if (m_cnADONetConnection.State ==  System.Data.ConnectionState.Open )
                {
                    m_estConnectee = true;
                }
                
                lg = new Logger("G_Mtps.accdb connecté = " + m_estConnectee.ToString(), m_cheminLog);
                //string cheminexe = connectionString;
                //Console.WriteLine(m_cheminLog);
                // Résultat : D:\Develop\Gestion\Gestion\bin
                
                return m_estConnectee;
            }
            catch (OleDbException err)
            {
                String mesage = err.ToString();
                lg = new Logger(mesage, m_cheminLog);
                return false;
            }            
        }
        private bool UsagerExiste(object nomusager)
        {
            bool ret = false;
            List<string> lstUsagers = new List<string>();
            lstUsagers = ObtenirUsagers();
            
            if(lstUsagers .Contains (nomusager))
            {
                return true;
            }
            return ret;
        }
        private Int32 ProchainIdUsager()
        {
            string szSelect;
            szSelect = "SELECT COUNT(*) FROM tblUsagers where IdUsager > 0";

            m_DataTable = new DataTable();
            m_DataTable.Clear();
            m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
            OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
            m_dataAdatper.Fill(m_DataTable);

            if(m_DataTable.Rows.Count == 1)
            {
                return (Int32)m_DataTable.Rows[0][0];
            }
            return 0;
        }
        /// <summary>
        /// Retourne le porchain numéro de catégorie
        /// </summary>
        /// <returns></returns>
        public  Int32 ProchainNoCategorie()
        {
            string szSelect;
            szSelect = "SELECT IIf(MAX(IdCategorie) Is Null, 0, MAX(IdCategorie)) FROM tblCategories where IdCategorie is not null or IdCategorie > 0";
            m_DataTable = new DataTable();
            m_DataTable.Clear();
            m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
            OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
            m_dataAdatper.Fill(m_DataTable);
            if (m_DataTable.Rows.Count == 1)
            {
                return Convert.ToInt32(m_DataTable.Rows[0][0]) + 1; 
            }
            return 0;
        }
        private int ProchainNoSite()
        {
            string szSelect;

            szSelect = "SELECT COUNT (IdSite) FROM tblSites";
            m_DataTable = new DataTable();
            m_DataTable.Clear();
            m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
            OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
            m_dataAdatper.Fill(m_DataTable);

            if (m_DataTable.Rows.Count == 1)
            {
                Int32 nb = Convert.ToInt32(m_DataTable.Rows[0][0]);
                return Convert.ToInt32(m_DataTable.Rows[0][0]) + 1;
            }
            else
            {
                m_DataTable.Clear();
                szSelect = "SELECT MAX(IdSite) FROM tblSites where IdSite > 0";
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                Int32 nb = Convert.ToInt32(m_DataTable.Rows[0][0]);
                return Convert.ToInt32(m_DataTable.Rows[0][0]) + 1;
                throw new NotImplementedException();
            }
        }
        // retourne le prochain id de sous catégorie associé à une catégorie
        private int ProchainNoSousCategorie()
        {
            string szSelect;

            szSelect = "SELECT COUNT (IdSousCatgorie) FROM tblSousCategories";
            m_DataTable = new DataTable();
            m_DataTable.Clear();
            m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
            OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
            m_dataAdatper.Fill(m_DataTable);

            if (m_DataTable.Rows.Count == 0)
            {                
                return 1;
            }
            else
            {
                m_DataTable.Clear();
                szSelect = "SELECT MAX(IdSousCatgorie) FROM tblSousCategories";// where IdSousCatgorie > 0";
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                object val = m_DataTable.Rows[0][0];
                int nb = val == DBNull.Value ? 0 : Convert.ToInt32(val);

                //Int32 nb = Convert.ToInt32(m_DataTable.Rows[0][0]);
                return Convert.ToInt32(nb) + 1;
            }

            //return 0;

            //int nb;
            //string szSelect = string.Empty;
            //string szWhere = string.Empty;
            //szWhere = " WHERE IdSousCatgorie > 0";
            //szSelect = "SELECT Max(tblSousCategories.IdSousCatgorie) FROM tblSousCategories";
            //m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);

            //OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
            //m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
            //m_dataAdatper.Fill(m_DataTable);
            //nb = Convert.ToInt32(m_DataTable.Rows[0][0]) + 1;
            //nb = Convert.ToInt32(m_DataTable.Rows[0][0]);
            //return Convert.ToInt32(m_DataTable.Rows[0][0]) + 1;

            //szSelect = "SELECT COUNT (IdSousCatgorie) FROM tblSousCategories" + szWhere;
            //m_DataTable = new DataTable();
            //m_DataTable.Clear();
            //m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
            //OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
            //m_dataAdatper.Fill(m_DataTable);
            //if (m_DataTable.Rows.Count == 1)
            //{
            //    Int32 nb = Convert.ToInt32(m_DataTable.Rows[0][0]);
            //    if (nb == 0)
            //    {
            //        return  1;
            //    }
            //    else
            //        //return 0;
            ////}
            ////else
            ////{
            //    m_DataTable.Clear();
            //    //szSelect = "SELECT MAX(IdSousCatego) as N FROM tblSousCatego";// where IdSousCatego > 0";
            //    szSelect = "SELECT IIf(MAX(IdSousCategorie) Is Null, 0, MAX(IdSousCategorie)) FROM tblSousCategories where IdSousCategorie is not null or IdSousCategorie > 0";
            //    m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
            //     m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
            //    m_dataAdatper.Fill(m_DataTable);
            //    nb = Convert.ToInt32(m_DataTable.Rows[0][0]);
            //    return Convert.ToInt32(m_DataTable.Rows[0][0]) + 1;
            //}
            //return 0;
            //throw new NotImplementedException();
        }
        // retourne le prochain id de sous catégorie associé à un ensemble de détails de site
        private int ProchainNoInfos()
        {
            string szSelect;

            szSelect = "SELECT COUNT (IdInfos) FROM tblInfos";
            m_DataTable = new DataTable();
            m_DataTable.Clear();
            m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
            OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
            m_dataAdatper.Fill(m_DataTable);
            if (m_DataTable.Rows.Count == 0)
            {
                return 1;
            }
            else
            {
                m_DataTable.Clear();
                szSelect = "SELECT MAX(IdInfos) FROM tblInfos";// where IdSousCatgorie > 0";
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                object val = m_DataTable.Rows[0][0];
                int nb = val == DBNull.Value ? 0 : Convert.ToInt32(val);

                //Int32 nb = Convert.ToInt32(m_DataTable.Rows[0][0]);
                return Convert.ToInt32(nb) + 1;
            }
            //return 0;
        }
        internal int UnSeulSite(int idsite)
        {
            int i = 0;
            string szSelect;
            szSelect = "Select COUNT(IdSite) FROM tblSites WHERE IdSite = " + idsite;

            try
            {
                m_DataTable = new DataTable();
                m_DataTable.Clear();
                m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
                OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
                m_dataAdatper.Fill(m_DataTable);
                i = m_DataTable.Rows.Count;
                return i = 1;
                //if (i > 0)
                //{
                //    return m_DataTable.Rows.Count == 1;
                //}
            }
            catch (Exception ex)
            {
                string err = string.Empty;
                err = ex.ToString();
                return 100;
            }
        }
        internal void ObtenirListeTables(ref List<string> list)
        {
            try
            {
                using (m_cnADONetConnection)
                {
                    //m_cnADONetConnection.Open(); // ← important si pas déjà ouvert

                    // Obtenir les tables
                    DataTable tables = m_cnADONetConnection.GetSchema("Tables");

                    m_DataTable = tables; // ← si tu veux le garder pour plus tard

                    foreach (DataRow row in tables.Rows) // ← ici le bon DataTable
                    {
                        string tableName = row["TABLE_NAME"].ToString();
                        string tableType = row["TABLE_TYPE"].ToString();

                        if (tableType == "TABLE" && !tableName.StartsWith("MSys"))
                        {
                            list.Add(tableName);
                            Console.WriteLine($"Table: {tableName}");
                        }
                    }
                }

                // Supprime cette ligne, elle déclenche l'exception
                // throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                // Tu peux aussi logger ou afficher le message ici
            }
        }
        internal int Ajouter(string m_Type, string text)
        {
            return 0;
        }

        internal bool ajouterSousCatgorie_v2(string text, ref Usager_v2 u, ref string message)
        {
            //string szSelect;
            bool retour = false;
            int idSousCategorie = 0;
            try
            {//vérifier si la valeur existe déjà
                bool present = VerifierPresenceSousCategorie(ref u, text);
                if (present)
                {
                    // Obtenir l'Id de la sous catégorie en question
                    Int32 unid = ObtenirIdSousCategorie(text);
                    idSousCategorie = unid;  
                    message = "Cette sous catégorie est déjà présente";
                    //return retour;
                }
                else //on ajoute la sous catégorie, et on s'assure des jounctions
                {
                    idSousCategorie = ProchainNoSousCategorie();
                }
                using (OleDbConnection connection = new OleDbConnection(m_maconnetionstring))
                {
                    Logger lg;
                    OleDbCommand command = new OleDbCommand();
                    OleDbTransaction transaction = null;
                    // Set the Connection to the new OleDbConnection.
                    command.Connection = connection;
                    try
                    {
                        // Open the connection and start the transaction.
                        connection.Open();
                        transaction = connection.BeginTransaction();
                        // Assign transaction object for a pending local transaction.
                        command.Transaction = transaction;

                        if (!present)
                        {
                            // Execute the commands.
                            //command.CommandText = "INSERT INTO tblSousCategories VALUES (" + idSousCategorie + ", '" + text + "')";
                            command.CommandText = "INSERT INTO tblSousCategories VALUES (" + idSousCategorie + ", '" + CorrigeInput(text) + "')";
                            command.ExecuteNonQuery();
                        }

                        // Assign transaction object for a pending local transaction.
                        command.CommandText = "INSERT INTO jctCategorieSousCategorie VALUES (" + u.IdUsager + "," + u.IdCategorie + ", " + idSousCategorie + ")";
                        command.ExecuteNonQuery();

                        // Commit the transaction.
                        transaction.Commit();
                        retour = true;
                    }
                    catch (Exception transEx)
                    {
                        #region catch
                        retour = false;
                        string err = string.Empty;
                        err = transEx.ToString();
                        lg = new Logger(err, m_cheminLog);
                        try
                        {
                            // Attempt to roll back the transaction.
                            transaction?.Rollback();
                            return retour;
                        }
                        catch
                        {
                            // Handle any errors that may have occurred during the rollback.
                            string mess = err.ToString();
                            lg = new Logger(err.ToString(), m_cheminLog);
                            return retour;
                        }
                    }
                    return retour;
                }
            }
            catch (Exception ex)
            {
                string mess = ex.ToString() ;
                lg = new Logger(ex.ToString(), m_cheminLog);
                //throw(new Exception(mess));
            }
            return retour;
        }

        private string CorrigeInput(string text)
        {
            return text.Replace("'", "''");
        }

        internal bool ajouterSite_v2(string text, ref Usager_v2 u, ref string messageRetour)
        {
            bool ret = false;
            int idSite = 0;

            try
            {
                //vérifier si la valeur existe déjà
                bool present = VerifierPresenceSite(ref u, text);
                if (present)
                {
                    // Obtenir l'Id de la sous catégorie en question
                    Int32 unid = ObtenirIdSite(text);
                    idSite = unid;
                    messageRetour = "Cette sous catégorie est déjà présente";
                    //return ret;
                }
                else //on ajoute la sous catégorie, et on s'assure des jounctions
                {
                    idSite = ProchainNoSite();
                }
                using (OleDbConnection connection = new OleDbConnection(m_maconnetionstring))
                {
                    OleDbCommand command = new OleDbCommand();
                    OleDbTransaction transaction = null;
                    // Set the Connection to the new OleDbConnection.
                    command.Connection = connection;
                    try
                    {
                        // Open the connection and start the transaction.
                        connection.Open();
                        transaction = connection.BeginTransaction();
                        // Assign transaction object for a pending local transaction.
                        command.Transaction = transaction;

                        if (!present)
                        {
                            // Execute the commands.
                            command.CommandText = "INSERT INTO tblSites VALUES (" + idSite + ", '" + CorrigeInput(text) + "')";
                            command.ExecuteNonQuery();
                        }

                        // Assign transaction object for a pending local transaction.
                        command.CommandText = "INSERT INTO jctSousCategorieSite VALUES("+ u.IdUsager + "," + u.IdCategorie + "," + u.IdSousCategorie + "," + idSite + ")";

                        command.ExecuteNonQuery();

                        // Commit the transaction.
                        transaction.Commit();
                        ret = true;
                    }
                    catch (Exception transEx)
                    {
                        #region catch
                        string err = string.Empty;
                        err = transEx.ToString();
                        Logger lg = new Logger(err, m_cheminLog);
                        try
                        {
                            // Attempt to roll back the transaction.
                            transaction?.Rollback();
                            return ret;
                        }
                        catch
                        {
                            // Handle any errors that may have occurred during the rollback.
                            return ret;
                        }
                        #endregion
                    }
                }
                //        return ret;
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                throw;
            }
            return ret;
        }

        internal bool AjouterCombinaisonSecret(Usager_v2 usager, SiteInfos m_siteInfos)
        {
            string szSelect = string.Empty;
            bool reussite = false;
            int prochainNo = 0;
            try
            {
                // a) Obtenir le prochain Id de tblInfos, conserver localement
                prochainNo = ProchainNoInfos();
                //vérifier si la combinaison existe déjà dans jctTblInfos
                List<int> ids = IdDeCombinaison(usager);
                //  si oui, s'assurer que le nom du site est différent
                //  si nom du site est == on bloque et on averti
                //  si différent, 


                // b) Faire le insert into tblInfos ET le insert into jctTblInfos
                using (OleDbConnection connection = new OleDbConnection(m_maconnetionstring))
                {
                    OleDbCommand command = new OleDbCommand();
                    OleDbTransaction transaction = null;
                    // Set the Connection to the new OleDbConnection.
                    command.Connection = connection;
                    try
                    {
                        // Open the connection and start the transaction.
                        connection.Open();
                        transaction = connection.BeginTransaction();
                        // Assign transaction object for a pending local transaction.
                        command.Transaction = transaction;

                        // Execute the commands.
                        command.CommandText = "INSERT INTO tblInfos VALUES ("
                                                 + prochainNo + ","
                                                 + " '" + CorrigeInput(m_siteInfos.NomSite) + "',"
                                                 + " '" + CorrigeInput(m_siteInfos.Adresse) + "', "
                                                 + " '" + CorrigeInput(m_siteInfos.Identifiant) + "', "
                                                 + " '" + CorrigeInput(m_siteInfos.MotPass) + "', "
                                                 + " '" + CorrigeInput(m_siteInfos.InfosCompl)
                                                 + "')";

                        command.ExecuteNonQuery();

                        // Assign transaction object for a pending local transaction.
                        command.CommandText = "INSERT INTO jctTblInfos VALUES(" + prochainNo + "," + usager.IdUsager + "," + usager.IdCategorie + "," + usager.IdSousCategorie + "," + usager.IdSite + ")";
                        command.ExecuteNonQuery();

                        // Commit the transaction.
                        transaction.Commit();
                        reussite = true;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                    return reussite;
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                throw ;
            }
        }
        internal bool ModifierCombinaisonSecret(SiteInfos m_siteInfos)
        {
            string szUpdate = string.Empty;
            bool reussite = false;
            //" '" + m_siteInfos.NomSite + "',"
            szUpdate = "UPDATE tblInfos SET tblInfos.NomSite = " + "'" + CorrigeInput(m_siteInfos.NomSite) + "',"
                + "tblInfos.Adresse = " + "'" + m_siteInfos.Adresse + "', "
                + "tblInfos.Identifiant = " + " '" + CorrigeInput(m_siteInfos.Identifiant) + "', "
                + "tblInfos.MotPass = " + "'" + CorrigeInput(m_siteInfos.MotPass) + "', "
                + "tblInfos.InfosCompl = " + "'" + CorrigeInput( m_siteInfos.InfosCompl) + "'"
                + " WHERE tblInfos.IdInfos = " + + m_siteInfos.Id ;


            try
            {
                using (OleDbConnection connection = new OleDbConnection(m_maconnetionstring))
                {
                    OleDbCommand command = new OleDbCommand();
                    OleDbTransaction transaction = null;
                    // Set the Connection to the new OleDbConnection.
                    command.Connection = connection;
                    try
                    {
                        // Open the connection and start the transaction.
                        connection.Open();
                        transaction = connection.BeginTransaction();
                        // Assign transaction object for a pending local transaction.
                        command.Transaction = transaction;

                        // Execute the commands.
                        command.CommandText = szUpdate;

                        command.ExecuteNonQuery();

                        // Commit the transaction.
                        transaction.Commit();
                        reussite = true;
                    }
                    catch (Exception ex1)
                    {
                        throw;
                    }
                }
                    return reussite;
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                throw;
            }
        }
        private List<int> IdDeCombinaison(Usager_v2 usager)
        {
            string szSelect;
            List<int> lstIds = new List<int>();
            szSelect = "SELECT IdInfos FROM jctTblInfos as jct WHERE jct.IdUsager = " + usager.IdUsager;
            // Ajouter les autres champs de la combinaison

            m_DataTable = new DataTable();
            m_DataTable.Clear();
            m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
            OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
            m_dataAdatper.Fill(m_DataTable);
            if (m_DataTable.Rows.Count > 0)
            {
                foreach (DataRow row in m_DataTable.Rows)
                {                    
                    lstIds.Add(Convert.ToInt32(row["IdInfos"]));
                }
            }
            
            return lstIds;
        }

        internal void ObtenirLesSitesInfos(ref List<SiteInfos> m_lstSiteInfos, Usager_v2 usager)
        {
            string szSelect;
            string szAND_Catego = string.Empty;
            string szAND_SousCatego = string.Empty;
            string szAND_Site = string.Empty;
            string szORDERBY = string.Empty;
            szSelect = "SELECT tblInfos.* FROM tblInfos INNER JOIN jctTblInfos ON tblInFos.IdInfos = jctTblInfos.IdInfos "
                + "WHERE jctTblInfos.IdUsager = " + usager.IdUsager;
            if (usager.IdCategorie­ > 0)
            {
                szAND_Catego = " AND jctTblInfos.IdCategorie = " + usager.IdCategorie;
            }
            if(usager.IdSousCategorie > 0)
            {
                szAND_SousCatego = " AND jctTblInfos.IdSousCategorie = " + usager.IdSousCategorie;
            }
            if (usager.IdSite > 0)
            {
                szAND_Site = " AND jctTblInfos.IdSite = " + usager.IdSite;
            }
            szORDERBY = " ORDER BY tblInfos.NomSite";
            szSelect += szAND_Catego + szAND_SousCatego + szAND_Site + szORDERBY;

            m_DataTable = new DataTable();
            m_DataTable.Clear();
            m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
            OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
            m_dataAdatper.Fill(m_DataTable);
            if (m_DataTable.Rows.Count > 0)
            {
                
                for(int i = 0; i < m_DataTable.Rows.Count; i++)
                {
                    SiteInfos unsite = new SiteInfos();
                    DataRow row = m_DataTable.Rows[i];
                    unsite.Id = (int)row["IdInfos"];
                    unsite.NomSite = row["NomSite"].ToString();
                    unsite.Adresse = row["Adresse"].ToString();
                    unsite.Identifiant = row["Identifiant"].ToString();
                    unsite.MotPass = row["MotPass"].ToString();

                    m_lstSiteInfos.Add(unsite);
                }
                
            }
        }
        internal string ObtenirInfosComplementaires(object unid)
        {
            string szSelect;
            string ret = string.Empty;
            szSelect = "SELECT InfosCompl FROM TblInfos as ti WHERE ti.IdInfos = " + unid;

            m_DataTable = new DataTable();
            m_DataTable.Clear();
            m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
            OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
            try
            {
                m_dataAdatper.Fill(m_DataTable);
                if (m_DataTable.Rows.Count == 1)
                {
                    ret = m_DataTable.Rows[0]["InfosCompl"].ToString();
                }
                    return ret;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal void RecupererUnEnregistrement(SiteInfos m_siteInfos)
        {
            string szSelect = string.Empty;
            szSelect = "SELECT * from tblInfos WHERE tblInfos.IdInfos = " + m_siteInfos.Id;
            m_DataTable = new DataTable();
            m_DataTable.Clear();
            m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
            OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);

            try
            {
                m_dataAdatper.Fill(m_DataTable);
                if (m_DataTable.Rows.Count == 1)
                {
                    m_siteInfos.NomSite = m_DataTable.Rows[0]["NomSite"].ToString();
                    m_siteInfos.Adresse = m_DataTable.Rows[0]["Adresse"].ToString();
                    m_siteInfos.Identifiant = m_DataTable.Rows[0]["Identifiant"].ToString();
                    m_siteInfos.MotPass = m_DataTable.Rows[0]["MotPass"].ToString();
                    m_siteInfos.InfosCompl = m_DataTable.Rows[0]["InfosCompl"].ToString();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        internal string ExtraireMpsUsager(int iSelect)
        {
            string szSelect = string.Empty;
            szSelect = "SELECT MotSecret from tblMtpsUsager WHERE tblMtpsUsager.IdUsager = " + iSelect;

            m_DataTable = new DataTable();
            m_DataTable.Clear();
            m_dataAdatper = new OleDbDataAdapter(szSelect, m_cnADONetConnection);
            OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);
            try
            {
                string retour = string.Empty;
                m_dataAdatper.Fill(m_DataTable);
                if (m_DataTable.Rows.Count == 1)
                {
                    retour = m_DataTable.Rows[0]["MotSecret"].ToString();
                }
                    int i = 0;
                i = 9;
                return retour;
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

        internal bool ModifierUnMotDePasse(int idUsager, string ancienMot, string motSaisi)
        {
            bool succes = false;
            string szUpdate = string.Empty;
            szUpdate = "UPDATE tblMtpsUsager SET MotSecret = '" + motSaisi + "' WHERE tblMtpsUsager.IdUsager = " + idUsager;
            m_DataTable = new DataTable();
            m_DataTable.Clear();
            m_dataAdatper = new OleDbDataAdapter(szUpdate, m_cnADONetConnection);
            OleDbCommandBuilder m_cbCommandBuilder = new OleDbCommandBuilder(m_dataAdatper);

            try
            {
                using (OleDbConnection connection = new OleDbConnection(m_maconnetionstring))
                {

                    string retour = string.Empty;
                    OleDbCommand command = new OleDbCommand();
                    command.CommandText = "";
                    command.CommandText = szUpdate;
                    // Set the Connection to the new OleDbConnection.
                    command.Connection = connection;
                    connection.Open();

                    command.ExecuteNonQuery();
                    succes = true;
                }
                    

                //m_dataAdatper.Fill(m_DataTable);
                //if (m_DataTable.Rows.Count == 1)
                //{
                //    retour = m_DataTable.Rows[0]["MotSecret"].ToString();
                //}
                //int i = 0;
                //i = 9;
                return succes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        internal bool AjouterMtpsUsager_v2(int m_IdUsager, string text)
        {
            string szInsert = "INSERT INTO tblMtpsUsager VALUES(" + m_IdUsager + ", '" + text + "')";
            OleDbCommand command = new OleDbCommand(szInsert, m_cnADONetConnection);
            try
            {
                command.ExecuteNonQuery();                
            }
            catch(Exception ex)
            {
                throw;
            }

            return true;
        }

        internal List<string> ObtenirListeUsagers(ref Usager_v2 U, string filtre, string text)
        {
            string table = string.Empty;
            string nomId = string.Empty;
            string szSelect = string.Empty;
            List<string> lalst = new List<string>();
            switch (filtre)
            {
                case "Site":
                    table = "jctSousCategorieSite";
                    nomId = "IdSite";
                    //szSelect= ConstruireSelectModifFiltre(ref U, filtre, text);
                    break;
            }
            return lalst;
            //throw new NotImplementedException();
        }


        #endregion
    }
}
#endregion