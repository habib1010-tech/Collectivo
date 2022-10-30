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
   
        public class CiviliteService : ICiviliteService
    {
        private readonly IDapperService _dapperService;

        public CiviliteService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }

       
        public Task<int> Create(CiviliteModel Civilite)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdCivilite", Civilite.IdCivilite, DbType.Int32, ParameterDirection.Output);
            dbPara.Add("LibelleCivilite", Civilite.LibelleCivilite, DbType.String, ParameterDirection.Input);
            var Out = Task.FromResult(_dapperService.Insert<int>("Civilite_add", ref dbPara, commandType: CommandType.StoredProcedure));
            var ReturnValue = dbPara.Get<int>("IdCivilite");
            return Task.FromResult(ReturnValue);
        }

        public Task<CiviliteModel> GetById(int id)
        {
            var Civilite = Task.FromResult(_dapperService.Get<CiviliteModel>($"SELECT * FROM civilite WHERE IdCivilite = '{id}'", null, commandType: CommandType.Text));
            return Civilite;
        }

        public Task<int> Delete(int id)
        {
            var deleteCivilite = Task.FromResult(_dapperService.Execute($"DELETE FROM civilite WHERE IdCivilite = '{id}'", null, commandType: CommandType.Text));
            return deleteCivilite;
        }

        public Task<int> Count(string condition)
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var CountCivilite = Task.FromResult(_dapperService.Get<int>($"SELECT COUNT(*) FROM civilite WHERE 1=1 {condition}", null, commandType: CommandType.Text));
            return CountCivilite;
        }

        public Task<List<CiviliteModel>> ListAll(string condition = "", string orderBy = "1", string direction = "DESC")
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var Civilite = Task.FromResult(_dapperService.GetAll<CiviliteModel>($"SELECT IdCivilite,LibelleCivilite FROM civilite WHERE 1=1 {condition} ORDER BY {orderBy} {direction}  ", null, commandType: CommandType.Text));
            return Civilite;
        }

        public Task<int> Update(CiviliteModel Civilite)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdCivilite", Civilite.IdCivilite);
            dbPara.Add("LibelleCivilite", Civilite.LibelleCivilite, DbType.String);
            var updateCivilite = Task.FromResult(_dapperService.Update<int>("Civilite_Update", dbPara, commandType: CommandType.StoredProcedure));
        
            return updateCivilite;
        }


    }
}

