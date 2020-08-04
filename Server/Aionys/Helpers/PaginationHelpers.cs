using Aionys.BL.Services;
using Aionys.Contractss.Requests;
using Aionys.Contractss.Responses;
using Aionys.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aionys.Helpers
{
    public class PaginationHelpers
    {
        /// <summary>
        /// Настройки пагинации
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uriService">интерфейс</param>
        /// <param name="pagination">фильтр для пагинации</param>
        /// <param name="response">возвращает лист данных</param>
        /// <returns>возвращает данные, номер страницы, размер страницы,
        /// параметры для получения следующей страницы и для предыдущей</returns>
        public static PagedResponse<T> CreatePaginatedResponse<T>(IUriService uriService, PaginationFilter pagination, List<T> response)
        {
            var nextPage = pagination.PageNumber >= 1
               ? uriService.GetAllNotesUri(new PaginationQuery(pagination.PageNumber + 1, pagination.PageSize)).ToString()
               : null;

            var previousPage = pagination.PageNumber - 1 >= 1
                ? uriService.GetAllNotesUri(new PaginationQuery(pagination.PageNumber - 1, pagination.PageSize)).ToString()
                : null;

            return new PagedResponse<T>
            {
                Data = response,
                PageNumber = pagination.PageNumber >= 1 ? pagination.PageNumber : (int?)null,
                PageSize = pagination.PageSize >= 1 ? pagination.PageSize : (int?)null,
                NextPage = response.Any() ? nextPage : null,
                PreviousPage = previousPage
            };
        }
    }
}
