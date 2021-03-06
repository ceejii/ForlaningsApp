﻿using System;
using FiefApp.Common.Infrastructure;
using FiefApp.Common.Infrastructure.DataModels;
using FiefApp.Common.Infrastructure.EventAggregatorEvents;
using FiefApp.Common.Infrastructure.Services;
using Prism.Events;

namespace FiefApp.Module.Weather
{
    public class WeatherViewModel : ViewModelBaseClass
    {
        private readonly IBaseService _baseService;
        private readonly IWeatherService _weatherService;
        private readonly IEventAggregator _eventAggregator;

        public WeatherViewModel(
            IBaseService baseService,
            IWeatherService weatherService,
            IEventAggregator eventAggregator
            ) : base(baseService)
        {
            _baseService = baseService;
            _weatherService = weatherService;
            _eventAggregator = eventAggregator;

            TabName = "Väder/Dagsverk";

            _eventAggregator.GetEvent<NewFiefLoadedEvent>().Subscribe(ExecuteNewFiefLoadedEvent);
        }

        #region DataModel

        private WeatherDataModel _dataModel;
        public WeatherDataModel DataModel
        {
            get => _dataModel;
            set => SetProperty(ref _dataModel, value);
        }

        #endregion

        protected override void SaveData(int index = -1)
        {
            _baseService.SetDataModel(DataModel, index == -1 ? Index : index);
        }

        protected override void LoadData()
        {
            DataModel = Index
                        == 0 ? _weatherService.GetAllWeatherDataModels()
                : _baseService.GetDataModel<WeatherDataModel>(Index);
            
            GetInformationSetDataModel();
            UpdateFiefCollection();
        }

        private void ExecuteNewFiefLoadedEvent()
        {
            Index = 1;
            LoadData();
        }

        private void GetInformationSetDataModel()
        {
            GetTotalAmountOfSerfs();
            GetTotalAmountOfSlaves();
            GetSubsidiaryData();
            GetForecasts();
            GetManorAcresSetManorDaysWork();
        }

        #region Methods : GetInformationSetDataModel

        private void GetTotalAmountOfSerfs()
        {
            DataModel.Serfs = _weatherService.GetTotalAmountOfSerfs(Index);
        }

        private void GetTotalAmountOfSlaves()
        {
            DataModel.Slaves = _weatherService.GetTotalAmountOfSlaves(Index);
        }

        private void GetSubsidiaryData()
        {
            DataModel.NumberOfSubsidiaries = _weatherService.GetTotalNumberOfSubsidaries(Index);
            DataModel.SubsidiariesDayswork = _weatherService.GetTotalAmountOfDaysworkFromSubsidiaries(Index);
        }

        private void GetForecasts()
        {
            DataModel.ThisYearSilver = _weatherService.GetForecastForSilver(Index);
            DataModel.ThisYearBase = _weatherService.GetForecastForBase(Index);
            DataModel.ThisYearLuxury = _weatherService.GetForecastForLuxury(Index);
            DataModel.ThisYearIron = _weatherService.GetForecastForIron(Index);
            DataModel.ThisYearStone = _weatherService.GetForecastForStone(Index);
            DataModel.ThisYearWood = _weatherService.GetForecastForWood(Index);
        }

        private void GetManorAcresSetManorDaysWork()
        {
            int acres = _weatherService.GetManorAcres(Index);

            DataModel.ManorDaysWork = Convert.ToInt32(Math.Ceiling((decimal)acres / 6 * 80));
        }

        #endregion
    }
}
