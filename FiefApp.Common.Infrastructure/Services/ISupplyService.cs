﻿using FiefApp.Common.Infrastructure.DataModels;

namespace FiefApp.Common.Infrastructure.Services
{
    public interface ISupplyService
    {
        void SaveToFiefService(SupplyDataModel dataModel);
        SupplyDataModel GetDataModelFromFiefService();

        bool WithdrawSilver(int amount);
        bool DepositSilver(int amount);
        bool WithdrawBase(int amount);
        bool DepositBase(int amount);
        bool WithdrawLuxury(int amount);
        bool DepositLuxury(int amount);
        bool WithdrawIron(int amount);
        bool DepositIron(int amount);
        bool WithdrawStone(int amount);
        bool DepositStone(int amount);
        bool WithdrawWood(int amount);
        bool DepositWood(int amount);
    }
}