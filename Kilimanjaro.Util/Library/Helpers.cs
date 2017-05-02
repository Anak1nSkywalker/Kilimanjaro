using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kilimanjaro.RepositoryEF;
using System.Web.WebPages.Html;

namespace Kilimanjaro.Util.Library
{
    public class Helpers
    {
        private static Context context = new Context();

        public static List<SelectListItem> FillDropDownList<T>() where T : class
        {
            return Helpers.GetDropDownList<T>("Description", "Id", string.Empty);
        }

        public static List<SelectListItem> FillDropDownList<T>(string id) where T : class
        {
            return Helpers.GetDropDownList<T>("Description", "Id", id);
        }

        private static List<SelectListItem> GetDropDownList<T>(
           string text, string value, string selected) where T : class
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "-Selecione uma opção-", Value = string.Empty });
            IQueryable<T> result = context.Set<T>();
            var lisData = (from items in result
                           select items).AsEnumerable().Select(m => new SelectListItem
                           {
                               Text = (string)m.GetType().GetProperty(text).GetValue(m),
                               Value = (string)m.GetType().GetProperty(value).GetValue(m).ToString(),
                               Selected = (selected != string.Empty) ? ((string)
                                 m.GetType().GetProperty(value).GetValue(m).ToString() ==
                                 selected ? true : false) : false,
                           }).ToList();
            list.AddRange(lisData);
            return list;
        }
    }
}
