using Aionys.Contractss;
using Aionys.Contractss.Requests;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aionys.BL.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination">параметры для пагинации</param>
        /// <returns></returns>
        public Uri GetAllNotesUri(PaginationQuery pagination = null)
        {
            var uri = new Uri(_baseUri);

            if (pagination == null)
            {
                return uri;
            }
                
            var modifiedUri = QueryHelpers.AddQueryString(_baseUri, "pageNumber", pagination.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", pagination.PageSize.ToString());

            return new Uri(modifiedUri);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="noteId">note Id</param>
        /// <returns></returns>
        public Uri GetNoteUri(string noteId)
        {
            return new Uri(_baseUri + ApiRouts.Notes.GetAll.Replace("{noteId}", noteId));
        }
    }
}
