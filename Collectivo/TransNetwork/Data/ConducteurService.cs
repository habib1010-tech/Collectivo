using TransNetwork.Interfaces;
using TransNetwork.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static TransNetwork.Interfaces.Interfaces;

namespace TransNetwork.Data
{
    public class ConducteurService : IConducteurService
    {
        private readonly IDapperService _dapperService;

        public ConducteurService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }


        public Task<int> Create(ConducteurModel Conducteur)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdConducteur", Conducteur.IdConducteur, DbType.Int32, ParameterDirection.Output);
            dbPara.Add("IdUtilisateur", Conducteur.IdUtilisateur, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("CodeReference", Conducteur.CodeReference, DbType.String, ParameterDirection.Input);
            dbPara.Add("NomConducteur", Conducteur.NomConducteur, DbType.String, ParameterDirection.Input);
            dbPara.Add("Mobile", Conducteur.Mobile, DbType.String, ParameterDirection.Input);
            var Out = Task.FromResult(_dapperService.Insert<int>("Conducteur_add", ref dbPara, commandType: CommandType.StoredProcedure));
            var ReturnValue = dbPara.Get<int>("IdConducteur");
            return Task.FromResult(ReturnValue);
        }

        public Task<ConducteurModel> GetById(int id)
        {
            var Conducteur = Task.FromResult(_dapperService.Get<ConducteurModel>($"SELECT * FROM conducteur WHERE IdConducteur = '{id}'", null, commandType: CommandType.Text));
            return Conducteur;
        }

        public Task<int> Delete(int id)
        {
            var deleteConducteur = Task.FromResult(_dapperService.Execute($"DELETE FROM conducteur WHERE IdUtilisateur = '{id}'", null, commandType: CommandType.Text));
            return deleteConducteur;
        }

        public Task<int> Count(string condition)
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var CountConducteur = Task.FromResult(_dapperService.Get<int>($"SELECT COUNT(*) FROM conducteur WHERE 1=1 {condition}", null, commandType: CommandType.Text));
            return CountConducteur;
        }

        public Task<List<ConducteurModel>> ListAll(string condition = "", string orderBy = "1", string direction = "DESC")
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var Conducteur = Task.FromResult(_dapperService.GetAll<ConducteurModel>($"SELECT IdConducteur,utilisateur.IdUtilisateur,NomUtilisateur,CodeReference,NomConducteur,conducteur.Mobile FROM conducteur LEFT JOIN utilisateur ON utilisateur.IdUtilisateur = conducteur.IdUtilisateur WHERE 1 =1 {condition} ORDER BY {orderBy} {direction}  ", null, commandType: CommandType.Text));
            return Conducteur;
        }

        public Task<int> Update(ConducteurModel Conducteur)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdConducteur", Conducteur.IdConducteur, DbType.Int32);
            dbPara.Add("IdUtilisateur", Conducteur.IdUtilisateur, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("CodeReference", Conducteur.CodeReference, DbType.String, ParameterDirection.Input);
            dbPara.Add("NomConducteur", Conducteur.NomConducteur, DbType.String, ParameterDirection.Input);
            dbPara.Add("Mobile", Conducteur.Mobile, DbType.String, ParameterDirection.Input);
            var updateConducteur = Task.FromResult(_dapperService.Update<int>("Conducteur_Update", dbPara, commandType: CommandType.StoredProcedure));

            return updateConducteur;
        }


    }
}