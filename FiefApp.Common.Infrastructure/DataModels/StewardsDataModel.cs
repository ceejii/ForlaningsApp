﻿using FiefApp.Common.Infrastructure.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FiefApp.Common.Infrastructure.DataModels
{
    public class StewardsDataModel : INotifyPropertyChanged, ICloneable, IDataModelBase
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<StewardModel> _stewardsCollection = new ObservableCollection<StewardModel>();
        public ObservableCollection<StewardModel> StewardsCollection
        {
            get => _stewardsCollection;
            set
            {
                _stewardsCollection = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<IndustryModel> _industryCollection = new ObservableCollection<IndustryModel>();
        public ObservableCollection<IndustryModel> IndustryCollection
        {
            get => _industryCollection;
            set
            {
                _industryCollection = value;
                NotifyPropertyChanged();
            }
        }


        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region ICloneable

        public object Clone()
        {
            return MemberwiseClone();
        }

        #endregion
    }
}
