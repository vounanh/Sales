using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.TeamFoundation.MVVM;

namespace Sales
{
    partial class MainWindowViewModel : ModelBase
    {
        public short Year
        {
            get
            {
                return Years.Item;
            }
            set
            {
                if (Years.Item == value) return;
                Years.Item = value;
                RaisePropertyChanged("Year");
            }
        }

        public Section Section
        {
            get
            {
                return Sections.Item;
            }
            set
            {
                if (Sections.Item == value) return;
                Sections.Item = value;
                RaisePropertyChanged("Section");
            }
        }

        private SalesMonthModel _item;
        public SalesMonthModel Item
        {
            get
            {
                return _item;
            }
            set
            {
                if (_item == value) return;
                _item = value;
                RaisePropertyChanged("Item");
            }
        }

        public IEnumerable<SalesMonthModel> Items
        {
            get
            {
                return SalesModel.MonthModels;
            }
        }

        private ICommand _ListCommand;
        public ICommand ListCommand
        {
            get
            {
                if (_ListCommand == null)
                {
                    _ListCommand = new RelayCommand(
                    ExecuteListCommand, CanExecuteListCommand);
                }
                return _ListCommand;
            }
        }

        private void ExecuteListCommand(object x)
        {
            ListViewModel.ShowDialog(Item);
            Item = null;
            Renew();
        }

        private bool CanExecuteListCommand(object x)
        {
            return Item != null;
        }

        private void ExecuteReadCommand()
        {
            Renew();
        }

        private void ExecutePrintCommand()
        {
            //todo: 未実装(Sales.MainWindowViewModel.ExecutePrintCommand())
            throw new System.NotImplementedException();
        }

        private void ExecuteImportCommand()
        {
            //todo: 未実装(Sales.MainWindowViewModel.ExecuteImportCommand())
            throw new System.NotImplementedException();
        }

        private void ExecuteExportCommand()
        {
            //todo: 未実装(Sales.MainWindowViewModel.ExecuteExportCommand())
            throw new System.NotImplementedException();
        }

        private void ExecuteHelpCommand(object x)
        {
            //todo: 未実装(Sales.MainWindowViewModel.ExecuteHelpCommand())
            throw new System.NotImplementedException();
        }

        private void ExecuteAboutCommand(object x)
        {
            //todo: 未実装(Sales.MainWindowViewModel.ExecuteAboutCommand())
            throw new System.NotImplementedException();
        }

        private void Renew()
        {
            Item = null;
            SalesModel.Renew();
            RaisePropertyChanged("Items");
        }
    }
}
