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
    public class VehiculeService : IVehiculeService
    {
        private readonly IDapperService _dapperService;

        public VehiculeService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }


        public Task<int> Create(VehiculeModel Vehicule)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdVehicule", Vehicule.IdVehicule, DbType.Int32, ParameterDirection.Output);
            dbPara.Add("IdCategorie", Vehicule.IdCategorie, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("IdMarque", Vehicule.IdMarque, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("IdModele", Vehicule.IdModele, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("CodeReference", Vehicule.CodeReference, DbType.String, ParameterDirection.Input);
            dbPara.Add("Matricule", Vehicule.Matricule, DbType.String, ParameterDirection.Input);
            dbPara.Add("NbrPlaces", Vehicule.NbrPlaces, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("Annee", Vehicule.Annee, DbType.Int32, ParameterDirection.Input);
            dbPara.Add("Kilometrage", Vehicule.Kilometrage, DbType.Int32, ParameterDirection.Input);
            var Out = Task.FromResult(_dapperService.Insert<int>("Vehicule_add", ref dbPara, commandType: CommandType.StoredProcedure));
            var ReturnValue = dbPara.Get<int>("IdVehicule");
            return Task.FromResult(ReturnValue);
        }

        public Task<VehiculeModel> GetById(int id)
        {
            var Vehicule = Task.FromResult(_dapperService.Get<VehiculeModel>($"SELECT * FROM vehicule WHERE IdVehicule = '{id}'", null, commandType: CommandType.Text));
            return Vehicule;
        }

        public Task<int> Delete(int id)
        {
            var deleteVehicule = Task.FromResult(_dapperService.Execute($"DELETE FROM vehicule WHERE IdVehicule = '{id}'", null, commandType: CommandType.Text));
            return deleteVehicule;
        }

        public Task<int> Count(string condition)
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var CountVehicule = Task.FromResult(_dapperService.Get<int>($"SELECT COUNT(*) FROM vehicule WHERE 1=1 {condition}", null, commandType: CommandType.Text));
            return CountVehicule;
        }

        public Task<List<VehiculeModel>> ListAll(string condition = "", string orderBy = "1", string direction = "DESC")
        {
            if (condition != "") condition = " AND (" + condition + ")";
            var Vehicule = Task.FromResult(_dapperService.GetAll<VehiculeModel>($"SELECT vehicule.IdVehicule,vehicule.IdCategorie,vehicule.IdMarque,vehicule.IdModele,vehicule.CodeReference,vehicule.Matricule,vehicule.NbrPlaces,vehicule.Annee,vehicule.Kilometrage,vehicule_categorie.LibelleCategorie,vehicule_marque.LibelleMarque,vehicule_modele.LibelleModele FROM vehicule LEFT JOIN vehicule_categorie ON vehicule_categorie.IdCategorie = vehicule.IdCategorie LEFT JOIN vehicule_marque ON vehicule_marque.IdMarque = vehicule.IdMarque LEFT JOIN vehicule_modele ON vehicule_modele.IdMarque = vehicule.IdMarque AND vehicule_modele.IdModele = vehicule.IdModele WHERE 1 =1 {condition} ORDER BY {orderBy} {direction}  ", null, commandType: CommandType.Text));
            return Vehicule;
        }

        public Task<int> Update(VehiculeModel Vehicule)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("IdVehicule", Vehicule.IdVehicule, DbType.Int32);
            dbPara.Add("IdCategorie", Vehicule.IdCategorie);
            dbPara.Add("IdMarque", Vehicule.IdMarque);
            dbPara.Add("IdModele", Vehicule.IdModele);
            dbPara.Add("CodeReference", Vehicule.CodeReference);
            dbPara.Add("Matricule", Vehicule.Matricule);
            dbPara.Add("NbrPlaces", Vehicule.NbrPlaces);
            dbPara.Add("Annee", Vehicule.Annee);
            dbPara.Add("Kilometrage", Vehicule.Kilometrage);
            var updateVehicule = Task.FromResult(_dapperService.Update<int>("Vehicule_Update", dbPara, commandType: CommandType.StoredProcedure));

            return updateVehicule;
        }


    }
}