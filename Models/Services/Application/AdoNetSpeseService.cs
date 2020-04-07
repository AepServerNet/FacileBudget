using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FacileBudget.Models.InputModels;
using FacileBudget.Models.Options;
using FacileBudget.Models.Services.Infrastructure;
using FacileBudget.Models.ValueTypes;
using FacileBudget.Models.ViewModels;

namespace FacileBudget.Models.Services.Application
{
    public class AdoNetSpeseService : ISpeseService
    {
        private readonly ILogger<AdoNetSpeseService> logger;
        private readonly IDatabaseAccessor db;
        private readonly IOptionsMonitor<SpeseOptions> speseOptions;
        public AdoNetSpeseService(ILogger<AdoNetSpeseService> logger, IDatabaseAccessor db, IOptionsMonitor<SpeseOptions> speseOptions)
        {
            this.speseOptions = speseOptions;
            this.logger = logger;
            this.db = db;
        }
        public async Task<ListViewModel<SpeseViewModel>> GetSpeseAsync(SpeseListInputModel model)
        {
            FormattableString query = $@"SELECT Id, ... FROM tabella ORDER BY Id DESC LIMIT {model.Limit} OFFSET {model.Offset}; 
            SELECT COUNT(*) FROM tabella";
            DataSet dataSet = await db.QueryAsync(query);
            var dataTable = dataSet.Tables[0];
            var speseList = new List<SpeseViewModel>();
            foreach (DataRow speseRow in dataTable.Rows)
            {
                SpeseViewModel speseViewModel = SpeseViewModel.FromDataRow(speseRow);
                speseList.Add(speseViewModel);
            }

            ListViewModel<SpeseViewModel> result = new ListViewModel<SpeseViewModel>
            {
                Results = speseList,
                TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0])
            };

            return result;
        }
    }
}