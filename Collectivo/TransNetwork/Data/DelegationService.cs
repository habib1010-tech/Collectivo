using Dapper;
using System.Data;
using TransNetwork.Models;
using static TransNetwork.Interfaces.Interfaces;

namespace TransNetwork.Data
{
    public class DelegationService: IDelegationService
    {
        private readonly IDapperService _dapperService;

        public DelegationService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }


        public Task<int> Create(DelegationModel Delegation)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdDelegation", Delegation.IdDelegation, DbType.Int32, ParameterDirection.Output);
            dbPara.Add("IdGouvernorat", Delegation.IdGouvernorat, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("LibelleDelegation", Delegation.LibelleDelegation, DbType.String, ParameterDirection.Input);
            var Out = Task.FromResult(_dapperService.Insert<int>("Delegation_add", ref dbPara, commandType: CommandType.StoredProcedure));
            var ReturnValue = dbPara.Get<int>("IdDelegation");
            return Task.FromResult(ReturnValue);
        }

        public Task<DelegationModel> GetById(int id)
        {
            var Delegation = Task.FromResult(_dapperService.Get<DelegationModel>($"SELECT * FROM delegation WHERE IdDelegation = '{id}'", null, commandType: CommandType.Text));
            return Delegation;
        }

        public Task<int> Delete(int id)
        {
            var deleteDelegation = Task.FromResult(_dapperService.Execute($"DELETE FROM delegation WHERE IdDelegation = '{id}'", null, commandType: CommandType.Text));
            return deleteDelegation;
        }

        public Task<int> Count(string condition)
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var CountDelegation = Task.FromResult(_dapperService.Get<int>($"SELECT COUNT(*) FROM delegation WHERE 1=1 {condition}", null, commandType: CommandType.Text));
            return CountDelegation;
        }

        public Task<List<DelegationModel>> ListAll(string condition = "", string orderBy = "1", string direction = "DESC")
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var Delegation = Task.FromResult(_dapperService.GetAll<DelegationModel>($"SELECT IdDelegation,IdGouvernorat,LibelleDelegation FROM delegation WHERE 1=1 {condition} ORDER BY {orderBy} {direction}  ", null, commandType: CommandType.Text));
            return Delegation;
        }

        public Task<int> Update(DelegationModel Delegation)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdDelegation", Delegation.IdDelegation);
            dbPara.Add("IdGouvernorat", Delegation.IdGouvernorat, DbType.Int32);
            dbPara.Add("LibelleDelegation", Delegation.LibelleDelegation, DbType.String);
            var updateDelegation = Task.FromResult(_dapperService.Update<int>("Delegation_Update", dbPara, commandType: CommandType.StoredProcedure));

            return updateDelegation;
        }


    }
}
