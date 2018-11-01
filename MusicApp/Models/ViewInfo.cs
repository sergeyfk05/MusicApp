using MusicApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class ViewInfo
    {
        public ViewInfo(string name, Type view, IViewModel viewModel)
        {
            this.name = name;
            this.view = view;
            this.viewModel = viewModel;
        }
        public string Name
        {
            get { return name; }
        }
        private string name;

        public Type View
        {
            get { return view; }
        }
        private Type view;

        public IViewModel ViewModel
        {
            get { return viewModel; ; }
        }
        private IViewModel viewModel;
    }
}
