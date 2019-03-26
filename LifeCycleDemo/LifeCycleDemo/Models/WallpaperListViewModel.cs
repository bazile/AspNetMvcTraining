using System.Collections.Generic;

namespace LifeCycleDemo.Models
{
    public class WallpaperListViewModel
    {
        public int Page { get; set; }

        public IEnumerable<WallpaperViewModel> Wallpapers { get; set; }
    }
}
