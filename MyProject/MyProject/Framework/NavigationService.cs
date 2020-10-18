using MyProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace MyProject.Framework
{
    public class NavigationService 
    {
        private Dictionary<string, Type> pages { get; } = new Dictionary<string, Type>();
        public Page MainPage => Application.Current.MainPage;
        public void Configure(string key, Type pageType) => pages[key] = pageType;  //See Services/ ViewNames.cs
        public void GoBack() => MainPage.Navigation.PopAsync();

        public void NavigateTo(string pageKey, object parameter = null)  //See ViewNames.cs
        {
            if (pages.TryGetValue(pageKey, out Type pageType))
            {
                var page = (Page)Activator.CreateInstance(pageType);
                //page.SetNavigationArgs(parameter);

                MainPage.Navigation.PushAsync(page);
                (page.BindingContext as BaseVM).Initialize(parameter);  //See BaseVM.cs
            }
            else
            {
                throw new ArgumentException($"This page doesn't exist: {pageKey}.", nameof(pageKey));
            }
        }
    }


    public static class NavigationExtensions //Allows arguments to be added when calling pages!!!!!!!!!!!!!!!!!!!!
    {
        private static ConditionalWeakTable<Page, object> arguments = new ConditionalWeakTable<Page, object>();

        public static object GetNavigationArgs(this Page page)
        {
            object argument;
            arguments.TryGetValue(page, out argument);

            return argument;
        }
        public static void SetNavigationArgs(this Page page, object args)
            => arguments.Add(page, args);
    }



}
