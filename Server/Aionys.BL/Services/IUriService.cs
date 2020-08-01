using Aionys.Contractss.Requests;
using System;


namespace Aionys.BL.Services
{
    public interface IUriService
    {
        Uri GetNoteUri(string noteId);

        Uri GetAllNotesUri(PaginationQuery pagination = null);
    }
}
