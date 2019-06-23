namespace UniversityXamarin.Infrastructure
{
    
    using System;
    using System.Collections.Generic;
    using System.Text;
    using UniversityXamarin.ViewModels;

    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
