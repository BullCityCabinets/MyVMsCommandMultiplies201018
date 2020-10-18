using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyProject.ViewModels
{
public class BaseVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));            
        }



        public virtual void Initialize(object parameter)   //see NavigationService.NavigatTo()... this is used to pass "Item Selected" info to the next viewmodel called.
        {
        
        }
















    }
}
