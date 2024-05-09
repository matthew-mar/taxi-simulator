using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DbPackage.Models;
using Godot;
using TaxiSimulator.Common.Contracts.Processes;

namespace TaxiSimulator.Services.Db.Processes {
    [Serializable]
    public struct CompaniesJson {
        public List<Company> Companies { get; set; }
    }

    public class FillInitial : IProcess {
        public event IProcess.ProcessEventHandler Completed;

        private static string CompaniesJsonFilePath 
            => ProjectSettings.GlobalizePath("res://companies.json");

        public async Task RunAsync() {
            await CreatePlayer();
            await CreateCompanies();
            Completed?.Invoke(null);
        }

        private static async Task CreatePlayer() => await DbService.Instance.DbProvider
            .PlayerRepository
            .CreatePlayerAsync();

        private static async Task CreateCompanies() {
            using var streamReader = new StreamReader(CompaniesJsonFilePath);
            var companies = await JsonSerializer
                .DeserializeAsync<CompaniesJson>(streamReader.BaseStream);
            await DbService.Instance.DbProvider
                .CompanyRepository
                .CreateManyCompaniesAsync(companies.Companies);
        }
    }
}
