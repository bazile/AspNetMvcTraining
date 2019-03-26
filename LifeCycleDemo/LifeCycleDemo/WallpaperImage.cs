using LifeCycleDemo.EF;
using System;
using System.Web;

namespace LifeCycleDemo
{
    public class WallpaperImage : IHttpHandler
    {
        /// <summary>
        /// Вам потребуется настроить этот обработчик в файле Web.config вашего 
        /// веб-сайта и зарегистрировать его с помощью IIS, чтобы затем воспользоваться им.
        /// см. на этой странице: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return true; }
        }

        //myhandler?id=1
        public void ProcessRequest(HttpContext context)
        {
            byte[] imageBytes = null;
            int id;
            if (int.TryParse(context.Request.QueryString["id"], out id))
            {
                using (var db = new WallpaperContext())
                {
                    var wallpaper = db.Wallpapers.Find(id);
                    if (wallpaper != null)
                    {
                        imageBytes = wallpaper.ImagesBytes;
                    }
                }
            }

            if (imageBytes == null)
            {
                context.Response.StatusCode = 404;
            }
            else
            {
                context.Response.StatusCode = 200;
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(imageBytes);
            }
        }

        #endregion
    }
}
