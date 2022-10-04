using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;


public static class Persistance
{
    private static string repertoireApplication = Environment.CurrentDirectory + @"\"  ;

    public static IList ChargerDonnees(string nomFichier)
    {
        FileStream fs = null;
        IList listeItem = null;
        
        try
        {
            fs = new FileStream(repertoireApplication+nomFichier, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                listeItem = (IList)formatter.Deserialize(fs);
            }
            catch (SerializationException err)
            {
                FichierLog(err);
            }
            finally
            {
                fs.Close();
            }


        }
        catch (Exception erreur)
        {
            FichierLog(erreur);
        }
        return listeItem;

    }

    public static void SauvegarderDonnees(string nomFichier, IList collection)
    {
        FileStream file = null;
        
        try
        {
            file = File.Open(repertoireApplication + nomFichier, FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, collection);
        }
        catch (Exception err)
        {
            FichierLog(err);
        }
        finally
        {
            if (file != null)
                file.Close();
        }

    }

    public static object ChargerObjet(string nomFichier)
    {
        FileStream fs = null;
        object objet = null;
        
        try
        {
            fs = new FileStream(repertoireApplication+nomFichier, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                objet = (object)formatter.Deserialize(fs);
            }
            catch (SerializationException erreur)
            {
                FichierLog(erreur);
            }
            finally
            {
                fs.Close();
            }


        }
        catch (Exception erreur)
        {
            FichierLog(erreur);
        }
        return objet;
    }

    public static void SauvegarderObjet(string nomFichier, object obj)
    {
        FileStream file = null ;
        try
        {
            file = File.Open(repertoireApplication + nomFichier, FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, obj);
        }
        catch (Exception err)
        {
            FichierLog(err);
        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }

    private static void FichierLog(Exception exception)
    {
        string path = repertoireApplication + @"\erreur";
        StreamWriter sw = new StreamWriter(path,true);
        sw.WriteLine("Date : " + DateTime.Now + " Message : " + exception.Message);
        sw.Close();
       
    }
}

