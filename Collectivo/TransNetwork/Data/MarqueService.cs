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
    public class MarqueService : IMarqueService
    {
        private readonly IDapperService _dapperService;

        public MarqueService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }


        public Task<int> Create(MarqueModel Marque)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdMarque", Marque.IdMarque, DbType.Int32, ParameterDirection.Output);
            dbPara.Add("LibelleMarque", Marque.LibelleMarque, DbType.String, ParameterDirection.Input);
            var Out = Task.FromResult(_dapperService.Insert<int>("Marque_add", ref dbPara, commandType: CommandType.StoredProcedure));
            var ReturnValue = dbPara.Get<int>("IdMarque");
            return Task.FromResult(ReturnValue);
        }

        public Task<MarqueModel> GetById(int id)
        {
            var Marque = Task.FromResult(_dapperService.Get<MarqueModel>($"SELECT * FROM vehicule_marque WHERE IdMarque = '{id}'", null, commandType: CommandType.Text));
            return Marque;
        }

        public Task<int> Delete(int id)
        {
            var deleteMarque = Task.FromResult(_dapperService.Execute($"DELETE FROM vehicule_marque WHERE IdMarque = '{id}'", null, commandType: CommandType.Text));
            return deleteMarque;
        }

        public Task<int> Count(string condition)
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var CountMarque = Task.FromResult(_dapperService.Get<int>($"SELECT COUNT(*) FROM vehicule_marque WHERE 1=1 {condition}", null, commandType: CommandType.Text));
            return CountMarque;
        }

        public Task<List<MarqueModel>> ListAll(string condition = "", string orderBy = "1", string direction = "DESC")
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var Marque = Task.FromResult(_dapperService.GetAll<MarqueModel>($"SELECT IdMarque,LibelleMarque FROM vehicule_marque WHERE 1=1 {condition} ORDER BY {orderBy} {direction}  ", null, commandType: CommandType.Text));
            return Marque;
        }

        public Task<int> Update(MarqueModel Marque)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdMarque", Marque.IdMarque);
            dbPara.Add("LibelleMarque", Marque.LibelleMarque, DbType.String);
            var updateMarque = Task.FromResult(_dapperService.Update<int>("Marque_Update", dbPara, commandType: CommandType.StoredProcedure));

            return updateMarque;
        }


    }
}
