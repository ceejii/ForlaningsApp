﻿using FiefApp.Common.Infrastructure.DataModels;

namespace FiefApp.Common.Infrastructure.Services
{
    public interface IBoatbuildingService
    {
        bool CheckShipyardPossibility(int index);
        BoatbuildingDataModel GetAllBoatbuildingDataModel();
        int GetNewBuildingBoatId(int index);
        int GetNewBoatbuilderId(int index);
    }
}