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
            _name = name;
            _view = view;
            _viewModel = viewModel;
        }
        internal string Name
        {
            get { return _name; }
        }
        private string _name;
        internal Type View
        {
            get { return _view; }
        }
        private Type _view;
        internal IViewModel ViewModel
        {
            get { return _viewModel; ; }
        }
        private IViewModel _viewModel;
    }
}
