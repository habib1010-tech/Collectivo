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
    public class CategorieService : ICategorieService
    {
        private readonly IDapperService _dapperService;

        public CategorieService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }


        public Task<int> Create(CategorieModel Categorie)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdCategorie", Categorie.IdCategorie, DbType.Int32, ParameterDirection.Output);
            dbPara.Add("LibelleCategorie", Categorie.LibelleCategorie, DbType.String, ParameterDirection.Input);
            var Out = Task.FromResult(_dapperService.Insert<int>("Categorie_add", ref dbPara, commandType: CommandType.StoredProcedure));
            var ReturnValue = dbPara.Get<int>("IdCategorie");
            return Task.FromResult(ReturnValue);
        }

        public Task<CategorieModel> GetById(int id)
        {
            var Categorie = Task.FromResult(_dapperService.Get<CategorieModel>($"SELECT * FROM vehicule_categorie WHERE IdCategorie = '{id}'", null, commandType: CommandType.Text));
            return Categorie;
        }

        public Task<int> Delete(int id)
        {
            var deleteCategorie = Task.FromResult(_dapperService.Execute($"DELETE FROM vehicule_categorie WHERE IdCategorie = '{id}'", null, commandType: CommandType.Text));
            return deleteCategorie;
        }

        public Task<int> Count(string condition)
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var CountCategorie = Task.FromResult(_dapperService.Get<int>($"SELECT COUNT(*) FROM vehicule_categorie WHERE 1=1 {condition}", null, commandType: CommandType.Text));
            return CountCategorie;
        }

        public Task<List<CategorieModel>> ListAll(string condition = "", string orderBy = "1", string direction = "DESC")
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var Categorie = Task.FromResult(_dapperService.GetAll<CategorieModel>($"SELECT IdCategorie,LibelleCategorie FROM vehicule_categorie WHERE 1=1 {condition} ORDER BY {orderBy} {direction}  ", null, commandType: CommandType.Text));
            return Categorie;
        }

        public Task<int> Update(CategorieModel Categorie)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdCategorie", Categorie.IdCategorie);
            dbPara.Add("LibelleCategorie", Categorie.LibelleCategorie, DbType.String);
            var updateCategorie = Task.FromResult(_dapperService.Update<int>("Categorie_Update", dbPara, commandType: CommandType.StoredProcedure));

            return updateCategorie;
        }

       
    }
}
