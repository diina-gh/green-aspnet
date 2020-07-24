using MetierPlant.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MetierPlant
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        private bdGreenContext db = new bdGreenContext();
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        //PROFILS
        public bool AddProfil(Profil p)
        {
            bool rep = false;
            try
            {
                db.profils.Add(p);
                db.SaveChanges();
                rep = true;
            }
            catch (Exception ex)
            {

            }
            return rep;
        }
        public List<Profil> ListProfil()
        {
            return db.profils.ToList();
        }

        //UTILISATEURS
        public bool AddUtilisateur(Utilisateur u)
        {
            bool rep = false;
            try
            {
                db.utilisateurs.Add(u);
                db.SaveChanges();
                rep = true;
            }
            catch (Exception ex)
            {

            }
            return rep;
        }

        public bool UpdateUtilisateur(Utilisateur u)
        {
            bool rep = false;
            try
            {
                db.Entry(u).State = EntityState.Modified;
                db.SaveChanges();
                rep = true;
            }
            catch (Exception ex)
            {

            }
            return rep;
        }

        public bool DeleteUtilisateur(int? id)
        {
            bool rep = false;
            try
            {
                Utilisateur u = db.utilisateurs.Find(id);
                db.utilisateurs.Remove(u);
                db.SaveChanges();
                rep = true;
            }
            catch (Exception ex)
            {

            }
            return rep;
        }

        public List<Utilisateur> ListUtilisateur()
        {
            return db.utilisateurs.ToList();
        }

        public Utilisateur getUtilisateurById(int? id)
        {
            return db.utilisateurs.Find(id);
        }


        //FRUITIERS
        public bool AddFruitier(Fruitier f)
        {
            bool rep = false;
            try
            {
                db.fruitiers.Add(f);
                db.SaveChanges();
                rep = true;
            }
            catch (Exception ex)
            {

            }
            return rep;
        }

        public bool UpdateFruitier(Fruitier f)
        {
            bool rep = false;
            try
            {
                db.Entry(f).State = EntityState.Modified;
                db.SaveChanges();
                rep = true;
            }
            catch (Exception ex)
            {

            }
            return rep;
        }

        public bool DeleteFruitier(int? id)
        {
            bool rep = false;
            try
            {
                Fruitier f = db.fruitiers.Find(id);
                db.fruitiers.Remove(f);
                db.SaveChanges();
                rep = true;
            }
            catch (Exception ex)
            {

            }
            return rep;
        }

        public List<Fruitier> ListFruitier()
        {
            return db.fruitiers.ToList();
        }

        public Fruitier getFruitierById(int? id)
        {
            return db.fruitiers.Find(id);
        }

        //MARECHERS
        public bool AddMarecher(Marecher m)
        {
            bool rep = false;
            try
            {
                db.marechers.Add(m);
                db.SaveChanges();
                rep = true;
            }
            catch (Exception ex)
            {

            }
            return rep;
        }

        public bool UpdateMarecher(Marecher m)
        {
            bool rep = false;
            try
            {
                db.Entry(m).State = EntityState.Modified;
                db.SaveChanges();
                rep = true;
            }
            catch (Exception ex)
            {

            }
            return rep;
        }

        public bool DeleteMarecher(int? id)
        {
            bool rep = false;
            try
            {
                Marecher m = db.marechers.Find(id);
                db.marechers.Remove(m);
                db.SaveChanges();
                rep = true;
            }
            catch (Exception ex)
            {

            }
            return rep;
        }

        public List<Marecher> ListMarecher()
        {
            return db.marechers.ToList();
        }

        public Marecher getMarecherById(int? id)
        {
            return db.marechers.Find(id);
        }
    }
}
