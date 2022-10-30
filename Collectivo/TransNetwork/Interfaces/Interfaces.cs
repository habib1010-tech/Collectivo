using Dapper;
using System.Data;
using System.Data.Common;
using TransNetwork.Models;

namespace TransNetwork.Interfaces
{
    public class Interfaces
    {
        public interface IDapperService : IDisposable
        {
            DbConnection GetConnection();

            T Get<T>(string sp, DynamicParameters parms,
                CommandType commandType = CommandType.StoredProcedure);

            List<T> GetAll<T>(string sp, DynamicParameters parms,
                CommandType commandType = CommandType.StoredProcedure);

            int Execute(string sp, DynamicParameters parms,
                CommandType commandType = CommandType.StoredProcedure);

            T Insert<T>(string sp, ref DynamicParameters parms,
                CommandType commandType = CommandType.StoredProcedure);

            T Update<T>(string sp, DynamicParameters parms,
                CommandType commandType = CommandType.StoredProcedure);
        }

        public interface IPaysService
        {
            Task<int> Create(PaysModel pays);
            Task<int> Delete(int idPays);
            Task<int> Count(string condition);
            Task<int> Update(PaysModel pays);
            Task<PaysModel> GetById(int idPays);
            Task<List<PaysModel>> ListAll(string condition, string orderBy, string direction);
        }

        public interface IGouvernoratService
        {
            Task<int> Create(GouvernoratModel gouvernorats);
            Task<int> Delete(int idGouvernorat);
            Task<int> Count(string condition);
            Task<int> Update(GouvernoratModel gouvernorats);
            Task<GouvernoratModel> GetById(int idGouvernorat);
            Task<List<GouvernoratModel>> ListAll(string condition, string orderBy, string direction);
        }

        public interface IDelegationService
        {
            Task<int> Create(DelegationModel delegations);
            Task<int> Delete(int idDelegation);
            Task<int> Count(string condition);
            Task<int> Update(DelegationModel delegations);
            Task<DelegationModel> GetById(int idDelegation);
            Task<List<DelegationModel>> ListAll(string condition, string orderBy, string direction);
        }

        public interface ICategorieService
        {
            Task<int> Create(CategorieModel categorie);
            Task<int> Delete(int idCategorie);
            Task<int> Count(string condition);
            Task<int> Update(CategorieModel categorie);
            Task<CategorieModel> GetById(int idCategorie);
            Task<List<CategorieModel>> ListAll(string condition, string orderBy, string direction);

        }

        public interface IMarqueService
        {
            Task<int> Create(MarqueModel Marque);
            Task<int> Delete(int idMarque);
            Task<int> Count(string condition);
            Task<int> Update(MarqueModel Marque);
            Task<MarqueModel> GetById(int idMarque);
            Task<List<MarqueModel>> ListAll(string condition, string orderBy, string direction);
        }

        public interface IModeleService
        {
            Task<int> Create(ModeleModel Modeles);
            Task<int> Delete(int idModele);
            Task<int> Count(string condition);
            Task<int> Update(ModeleModel Modeles);
            Task<ModeleModel> GetById(int idModele);
            Task<List<ModeleModel>> ListAll(string condition, string orderBy, string direction);
        }

        public interface ICiviliteService
        {
            Task<int> Create(CiviliteModel Civilites);
            Task<int> Delete(int idCivilite);
            Task<int> Count(string condition);
            Task<int> Update(CiviliteModel Civilites);
            Task<CiviliteModel> GetById(int idCivilite);
            Task<List<CiviliteModel>> ListAll(string condition, string orderBy, string direction);
        }

        public interface IRoleService
        {
            Task<int> Create(RoleModel Roles);
            Task<int> Delete(int idRole);
            Task<int> Count(string condition);
            Task<int> Update(RoleModel Roles);
            Task<RoleModel> GetById(int idRole);
            Task<List<RoleModel>> ListAll(string condition, string orderBy, string direction);
        }

        public interface IVehiculeService
        {
            Task<int> Create(VehiculeModel Vehicules);
            Task<int> Delete(int idVehicule);
            Task<int> Count(string condition);
            Task<int> Update(VehiculeModel Vehicules);
            Task<VehiculeModel> GetById(int idVehicule);
            Task<List<VehiculeModel>> ListAll(string condition, string orderBy, string direction);
        }

        public interface IRoleUtilisateurService
        {
            Task<int> Create(RoleUtilisateurModel roleUtilisateur);
            Task<int> Delete(int idRole,int idUtilisateur);
            Task<int> Delete(int idUtilisateur);
            Task<int> Count(string condition);
            Task<RoleUtilisateurModel> GetById(int idRole, int idUtilisateur);
            Task<List<RoleUtilisateurModel>> ListAll(string condition, string orderBy, string direction);
        }

        public interface IUtilisateurService
        {
            Task<int> Create(UtilisateurModel Utilisateurs);
            Task<int> Delete(int idUtilisateur);
            Task<int> Count(string condition);
            Task<int> Update(UtilisateurModel Utilisateurs);
            Task<UtilisateurModel> GetById(int idUtilisateur);
            Task<UtilisateurModel> GetByEmail(string email);
            Task<List<UtilisateurModel>> ListAll(string condition, string orderBy, string direction);
        }

        public interface IPassagerService
        {
            Task<int> Create(PassagerModel Passagers);
            Task<int> Delete(int idPassager);
            Task<int> Count(string condition);
            Task<int> Update(PassagerModel Passagers);
            Task<PassagerModel> GetById(int idPassager);
            Task<List<PassagerModel>> ListAll(string condition, string orderBy, string direction);
        }

        public interface IConducteurService
        {
            Task<int> Create(ConducteurModel Conducteurs);
            Task<int> Delete(int idConducteur);
            Task<int> Count(string condition);
            Task<int> Update(ConducteurModel Conducteurs);
            Task<ConducteurModel> GetById(int idConducteur);
            Task<List<ConducteurModel>> ListAll(string condition, string orderBy, string direction);
        }

        public interface IActiviteService
        {
            Task<int> Create(ActiviteModel Activite);
            Task<int> Delete(int idActivite);
            Task<int> Count(string condition);
            Task<int> Update(ActiviteModel Activite);
            Task<ActiviteModel> GetById(int idActivite);
            Task<List<ActiviteModel>> ListAll(string condition, string orderBy, string direction);
        }

    }
}
