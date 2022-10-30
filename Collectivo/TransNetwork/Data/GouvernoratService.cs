using Dapper;
using System.Data;
using TransNetwork.Models;
using static TransNetwork.Interfaces.Interfaces;

namespace TransNetwork.Data
{
    public class GouvernoratService : IGouvernoratService
    {
        private readonly IDapperService _dapperService;

        public GouvernoratService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }


        public Task<int> Create(GouvernoratModel Gouvernorat)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdGouvernorat", Gouvernorat.IdGouvernorat, DbType.Int32, ParameterDirection.Output);
            dbPara.Add("IdPays", Gouvernorat.IdPays, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("LibelleGouvernorat", Gouvernorat.LibelleGouvernorat, DbType.String, ParameterDirection.Input);
            var Out = Task.FromResult(_dapperService.Insert<int>("Gouvernorat_add", ref dbPara, commandType: CommandType.StoredProcedure));
            var ReturnValue = dbPara.Get<int>("IdGouvernorat");
            return Task.FromResult(ReturnValue);
        }

        public Task<GouvernoratModel> GetById(int id)
        {
            var Gouvernorat = Task.FromResult(_dapperService.Get<GouvernoratModel>($"SELECT * FROM gouvernorat WHERE IdGouvernorat = '{id}'", null, commandType: CommandType.Text));
            return Gouvernorat;
        }

        public Task<int> Delete(int id)
        {
            var deleteGouvernorat = Task.FromResult(_dapperService.Execute($"DELETE FROM gouvernorat WHERE IdGouvernorat = '{id}'", null, commandType: CommandType.Text));
            return deleteGouvernorat;
        }

        public Task<int> Count(string condition)
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var CountGouvernorat = Task.FromResult(_dapperService.Get<int>($"SELECT COUNT(*) FROM gouvernorat WHERE 1=1 {condition}", null, commandType: CommandType.Text));
            return CountGouvernorat;
        }

        public Task<List<GouvernoratModel>> ListAll(string condition = "", string orderBy = "1", string direction = "DESC")
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var Gouvernorat = Task.FromResult(_dapperService.GetAll<GouvernoratModel>($"SELECT IdGouvernorat,IdPays,LibelleGouvernorat FROM gouvernorat WHERE 1=1 {condition} ORDER BY {orderBy} {direction}  ", null, commandType: CommandType.Text));
            return Gouvernorat;
        }

        public Task<int> Update(GouvernoratModel Gouvernorat)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdGouvernorat", Gouvernorat.IdGouvernorat);
            dbPara.Add("IdPays", Gouvernorat.IdPays, DbType.Int32);
            dbPara.Add("LibelleGouvernorat", Gouvernorat.LibelleGouvernorat, DbType.String);
            var updateGouvernorat = Task.FromResult(_dapperService.Update<int>("Gouvernorat_Update", dbPara, commandType: CommandType.StoredProcedure));

            return updateGouvernorat;
        }


    }
}
