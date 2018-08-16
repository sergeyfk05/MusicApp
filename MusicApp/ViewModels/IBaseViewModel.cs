using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.ViewModels
{
    internal interface IBaseViewModel
    {
        string Title { get; set; }
        string ActivePageText { get; set; }
    }
}
