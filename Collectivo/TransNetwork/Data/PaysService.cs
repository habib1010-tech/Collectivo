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
    public class PaysService : IPaysService
    {
        private readonly IDapperService _dapperService;

        public PaysService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }

       
        public Task<int> Create(PaysModel pays)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdPays", pays.IdPays, DbType.Int32, ParameterDirection.Output);
            dbPara.Add("LibellePays", pays.LibellePays, DbType.String, ParameterDirection.Input);
            var Out = Task.FromResult(_dapperService.Insert<int>("Pays_add", ref dbPara, commandType: CommandType.StoredProcedure));
            var ReturnValue = dbPara.Get<int>("IdPays");
            return Task.FromResult(ReturnValue);
        }

        public Task<PaysModel> GetById(int id)
        {
            var pays = Task.FromResult(_dapperService.Get<PaysModel>($"SELECT * FROM pays WHERE IdPays = '{id}'", null, commandType: CommandType.Text));
            return pays;
        }

        public Task<int> Delete(int id)
        {
            var deletepays = Task.FromResult(_dapperService.Execute($"DELETE FROM pays WHERE IdPays = '{id}'", null, commandType: CommandType.Text));
            return deletepays;
        }

        public Task<int> Count(string condition)
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var Countpays = Task.FromResult(_dapperService.Get<int>($"SELECT COUNT(*) FROM pays WHERE 1=1 {condition}", null, commandType: CommandType.Text));
            return Countpays;
        }

        public Task<List<PaysModel>> ListAll(string condition = "", string orderBy = "1", string direction = "DESC")
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var pays = Task.FromResult(_dapperService.GetAll<PaysModel>($"SELECT IdPays,LibellePays FROM pays WHERE 1=1 {condition} ORDER BY {orderBy} {direction}  ", null, commandType: CommandType.Text));
            return pays;
        }

        public Task<int> Update(PaysModel pays)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdPays", pays.IdPays);
            dbPara.Add("LibellePays", pays.LibellePays, DbType.String);
            var updatepays = Task.FromResult(_dapperService.Update<int>("Pays_Update", dbPara, commandType: CommandType.StoredProcedure));
        
            return updatepays;
        }


    }
}
