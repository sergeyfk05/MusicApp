using MusicApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    internal class ViewInfo
    {
        internal ViewInfo(string name, Type view, IViewModel viewModel)
        {
            this.name = name;
            this.view = view;
            this.viewModel = viewModel;
        }
        internal string Name
        {
            get { return name; }
        }
        private string name;

        internal Type View
        {
            get { return view; }
        }
        private Type view;

        internal IViewModel ViewModel
        {
            get { return viewModel; ; }
        }
        private IViewModel viewModel;
    }
}
