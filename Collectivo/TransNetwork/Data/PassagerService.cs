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
    public class PassagerService  : IPassagerService
    {
        private readonly IDapperService _dapperService;

        public PassagerService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }


        public Task<int> Create(PassagerModel Passager)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdPassager", Passager.IdPassager, DbType.Int32, ParameterDirection.Output);
            dbPara.Add("IdUtilisateur", Passager.IdUtilisateur, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("CodeReference", Passager.CodeReference, DbType.String, ParameterDirection.Input);
            dbPara.Add("NomPassager", Passager.NomPassager, DbType.String, ParameterDirection.Input);
            dbPara.Add("Mobile", Passager.Mobile, DbType.String, ParameterDirection.Input);
            var Out = Task.FromResult(_dapperService.Insert<int>("Passager_add", ref dbPara, commandType: CommandType.StoredProcedure));
            var ReturnValue = dbPara.Get<int>("IdPassager");
            return Task.FromResult(ReturnValue);
        }

        public Task<PassagerModel> GetById(int id)
        {
            var Passager = Task.FromResult(_dapperService.Get<PassagerModel>($"SELECT * FROM passager WHERE IdPassager = '{id}'", null, commandType: CommandType.Text));
            return Passager;
        }

        public Task<int> Delete(int id)
        {
            var deletePassager = Task.FromResult(_dapperService.Execute($"DELETE FROM passager WHERE IdPassager = '{id}'", null, commandType: CommandType.Text));
            return deletePassager;
        }

        public Task<int> Count(string condition)
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var CountPassager = Task.FromResult(_dapperService.Get<int>($"SELECT COUNT(*) FROM passager WHERE 1=1 {condition}", null, commandType: CommandType.Text));
            return CountPassager;
        }

        public Task<List<PassagerModel>> ListAll(string condition = "", string orderBy = "1", string direction = "DESC")
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var Passager = Task.FromResult(_dapperService.GetAll<PassagerModel>($"SELECT IdPassager,utilisateur.IdUtilisateur,NomUtilisateur,CodeReference,NomPassager,passager.Mobile FROM passager LEFT JOIN utilisateur ON utilisateur.IdUtilisateur = passager.IdUtilisateur WHERE 1 =1 {condition} ORDER BY {orderBy} {direction}  ", null, commandType: CommandType.Text));
            return Passager;
        }

        public Task<int> Update(PassagerModel Passager)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdPassager", Passager.IdPassager, DbType.Int32);
            dbPara.Add("IdUtilisateur", Passager.IdUtilisateur, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("CodeReference", Passager.CodeReference, DbType.String, ParameterDirection.Input);
            dbPara.Add("NomPassager", Passager.NomPassager, DbType.String, ParameterDirection.Input);
            dbPara.Add("Mobile", Passager.Mobile, DbType.String, ParameterDirection.Input);
            var updatePassager = Task.FromResult(_dapperService.Update<int>("Passager_Update", dbPara, commandType: CommandType.StoredProcedure));

            return updatePassager;
        }


    }
}