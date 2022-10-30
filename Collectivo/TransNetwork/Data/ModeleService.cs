using Dapper;
using System.Data;
using TransNetwork.Models;
using static TransNetwork.Interfaces.Interfaces;

namespace TransNetwork.Data
{
    public class ModeleService : IModeleService
    {
        private readonly IDapperService _dapperService;

        public ModeleService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }


        public Task<int> Create(ModeleModel Modele)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdModele", Modele.IdModele, DbType.Int32, ParameterDirection.Output);
            dbPara.Add("IdMarque", Modele.IdMarque, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("LibelleModele", Modele.LibelleModele, DbType.String, ParameterDirection.Input);
            var Out = Task.FromResult(_dapperService.Insert<int>("Modele_add", ref dbPara, commandType: CommandType.StoredProcedure));
            var ReturnValue = dbPara.Get<int>("IdModele");
            return Task.FromResult(ReturnValue);
        }

        public Task<ModeleModel> GetById(int id)
        {
            var Modele = Task.FromResult(_dapperService.Get<ModeleModel>($"SELECT * FROM vehicule_modele WHERE IdModele = '{id}'", null, commandType: CommandType.Text));
            return Modele;
        }

        public Task<int> Delete(int id)
        {
            var deleteModele = Task.FromResult(_dapperService.Execute($"DELETE FROM vehicule_modele WHERE IdModele = '{id}'", null, commandType: CommandType.Text));
            return deleteModele;
        }

        public Task<int> Count(string condition)
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var CountModele = Task.FromResult(_dapperService.Get<int>($"SELECT COUNT(*) FROM vehicule_modele WHERE 1=1 {condition}", null, commandType: CommandType.Text));
            return CountModele;
        }

        public Task<List<ModeleModel>> ListAll(string condition = "", string orderBy = "1", string direction = "DESC")
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var Modele = Task.FromResult(_dapperService.GetAll<ModeleModel>($"SELECT IdModele,IdMarque,LibelleModele FROM vehicule_modele WHERE 1=1 {condition} ORDER BY {orderBy} {direction}  ", null, commandType: CommandType.Text));
            return Modele;
        }

        public Task<int> Update(ModeleModel Modele)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdModele", Modele.IdModele);
            dbPara.Add("IdMarque", Modele.IdMarque, DbType.Int32);
            dbPara.Add("LibelleModele", Modele.LibelleModele, DbType.String);
            var updateModele = Task.FromResult(_dapperService.Update<int>("Modele_Update", dbPara, commandType: CommandType.StoredProcedure));

            return updateModele;
        }


    }
}
