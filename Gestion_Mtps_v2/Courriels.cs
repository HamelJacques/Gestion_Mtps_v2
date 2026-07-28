// Decompiled with JetBrains decompiler
// Type: Rapports.Courriels
// Assembly: Rapports, Version=4.7.3.4, Culture=neutral, PublicKeyToken=null
// MVID: 950EFD5F-5FAC-48BD-BA0C-0ABC7B9793D4
// Assembly location: D:\Developpements\Decompiles\Rapports_Decompiler\Rapports.exe

using System;
using System.Net;
using System.Net.Mail;

//#nullable disable
namespace Gestion_Mtps
{ 

    internal class Courriels
    {
      private string messageBody;
      private string cheminFichierErreur;

      public Courriels()
      {
        this.messageBody = string.Empty;
        this.cheminFichierErreur = string.Empty;
      }

      public Courriels(string leMessage, string chFichierErreur)
      {
        string str = Environment.NewLine + Environment.MachineName;
        this.messageBody = leMessage + str;
        this.cheminFichierErreur = chFichierErreur;
        this.EnvoieCourriel();
      }

        public void EnvoiCourriel(string message)
        {
            this.messageBody = message;
            bool ret = this.EnvoieCourriel();
        }

      private bool EnvoieCourriel()
      {
        try
        {
          new SmtpClient("in-v3.mailjet.com", 587)
          {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = ((ICredentialsByHost) new NetworkCredential("f2517f2b6307f3f329cfd0b84f28c2b1", "f31031f074e4d39ded6ca8173754cf68"))
          }.Send(new MailMessage()
          {
            From = new MailAddress("hamel_jacques@hotmail.com"),
            To = {
              "hamel_jacques@hotmail.com"
            },
            Subject = "Sauvegarde",
            Body = this.messageBody,
            IsBodyHtml = false
          });
          return true;
        }
        catch (Exception ex)
        {
          Console.WriteLine((object) ex);
          return false;
        }
      }

      private bool EnvoieCourriel_old()
      {
        MailMessage message = new MailMessage();
        SmtpClient smtpClient = new SmtpClient();
        try
        {
          message.From = new MailAddress("hamel_jacques@hotmail.com");
          message.To.Add(new MailAddress("hamel_jacques@hotmail.com"));
          message.Subject = "Le Nom du Cours";
          message.IsBodyHtml = false;
          message.Body = this.messageBody;
          if (System.IO.File.Exists(this.cheminFichierErreur))
            message.Attachments.Add(new Attachment(this.cheminFichierErreur));
          smtpClient.Port = 587;
          smtpClient.Host = "in-v3.mailjet.com";
          smtpClient.EnableSsl = true;
          smtpClient.UseDefaultCredentials = false;
          smtpClient.Credentials = (ICredentialsByHost) new NetworkCredential("hamel_jacques@hotmail.com", "ajmah3refait");
          smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
          smtpClient.Send(message);
          return true;
        }
        catch (Exception ex)
        {
          ex.ToString();
          return false;
        }
      }
    }
}