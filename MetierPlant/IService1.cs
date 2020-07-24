using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MetierPlant.Models;

namespace MetierPlant
{

    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: ajoutez vos opérations de service ici
        //PROFILS
        [OperationContract]
        bool AddProfil(Profil p);
        [OperationContract]
        List<Profil> ListProfil();

        //UTILISATEURS
        [OperationContract]
        bool AddUtilisateur(Utilisateur u);
        [OperationContract]
        bool UpdateUtilisateur(Utilisateur u);
        [OperationContract]
        bool DeleteUtilisateur(int? id);
        [OperationContract]
        List<Utilisateur> ListUtilisateur();
        [OperationContract]
        Utilisateur getUtilisateurById(int? id);

        //FRUITIERS
        [OperationContract]
        bool AddFruitier(Fruitier f);
        [OperationContract]
        bool UpdateFruitier(Fruitier f);
        [OperationContract]
        bool DeleteFruitier(int? id);
        [OperationContract]
        List<Fruitier> ListFruitier();
        [OperationContract]
        Fruitier getFruitierById(int? id);

        //MARECHERS
        [OperationContract]
        bool AddMarecher(Marecher m);
        [OperationContract]
        bool UpdateMarecher(Marecher m);
        [OperationContract]
        bool DeleteMarecher(int? id);
        [OperationContract]
        List<Marecher> ListMarecher();
        [OperationContract]
        Marecher getMarecherById(int? id);
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

}
