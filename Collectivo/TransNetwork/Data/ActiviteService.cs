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
    public class ActiviteService : IActiviteService
    {
        private readonly IDapperService _dapperService;

        public ActiviteService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }

        public Task<int> Create(ActiviteModel activites)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdActivite", activites.IdActivite, DbType.Int32, ParameterDirection.InputOutput);
            dbPara.Add("IdVehicule", activites.IdVehicule, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("IdConducteur", activites.IdConducteur, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("ActivitePrincipale", activites.ActivitePrincipale, DbType.Boolean, ParameterDirection.Input);
            dbPara.Add("DateDebutActivite", activites.DateDebutActivite, DbType.Date, ParameterDirection.Input);
            dbPara.Add("DateFinActivite", activites.DateFinActivite, DbType.Date, ParameterDirection.Input);
            dbPara.Add("Active", activites.Active, DbType.Boolean, ParameterDirection.Input);
            var Out = Task.FromResult(_dapperService.Insert<int>("Activite_Add", ref dbPara, commandType: CommandType.StoredProcedure));
            var ReturnValue = dbPara.Get<int>("IdActivite");
            
            return Task.FromResult(ReturnValue);
        }

        public Task<ActiviteModel> GetById(int id)
        {
            var activites = Task.FromResult(_dapperService.Get<ActiviteModel>($"SELECT * FROM activite WHERE activite.IdActivite = '{id}'", null, commandType: CommandType.Text));
            return activites;
        }
       

        public Task<int> Delete(int id)
        {
            var deleteactivites = Task.FromResult(_dapperService.Execute($"DELETE FROM activite WHERE IdActivite = '{id}'", null, commandType: CommandType.Text));
            return deleteactivites;
        }

        public Task<int> Count(string condition)
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var Countactivites = Task.FromResult(_dapperService.Get<int>($"SELECT COUNT(*) FROM activite WHERE 1=1 {condition}", null, commandType: CommandType.Text));
            return Countactivites;
        }

        public Task<List<ActiviteModel>> ListAll(string condition = "", string orderBy = "1", string direction = "DESC")
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var activites = Task.FromResult(_dapperService.GetAll<ActiviteModel>($"SELECT activite.IdActivite,activite.IdConducteur,activite.IdVehicule,ActivitePrincipale,DateDebutActivite,DateFinActivite,active,NomConducteur,LibelleCategorie + ',' + LibelleMarque + ',' + LibelleModele + ',' + Matricule AS NomVehicule FROM activite LEFT JOIN conducteur ON conducteur.IdConducteur = activite.IdConducteur LEFT JOIN vehicule on vehicule.IdVehicule = activite.IdVehicule LEFT JOIN vehicule_categorie on vehicule_categorie.IdCategorie = vehicule.IdCategorie LEFT JOIN vehicule_marque on vehicule_marque.IdMarque = vehicule.IdMarque LEFT JOIN vehicule_modele on vehicule_modele.IdModele = vehicule.IdModele WHERE 1=1 {condition} ORDER BY {orderBy} {direction}  ", null, commandType: CommandType.Text));
            return activites;
        }

       
        public Task<int> Update(ActiviteModel activites)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdActivite", activites.IdActivite);
            dbPara.Add("IdVehicule", activites.IdVehicule, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("IdConducteur", activites.IdConducteur, DbType.Int32);
            dbPara.Add("ActivitePrincipale", activites.ActivitePrincipale, DbType.Boolean);
            dbPara.Add("DateDebutActivite", activites.DateDebutActivite, DbType.Date);
            dbPara.Add("DateFinActivite", activites.DateFinActivite, DbType.Date);
            dbPara.Add("Active", activites.Active, DbType.Boolean);
            var updateactivites = Task.FromResult(_dapperService.Update<int>("Activite_Update", dbPara, commandType: CommandType.StoredProcedure));
          
            return updateactivites;
        }


    }
}