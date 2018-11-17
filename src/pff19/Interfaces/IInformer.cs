using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pff19.DataAccess.Models;

namespace pff19.Interfaces
{
    public interface IInformer
    {
        void InformAboutContactRequest(ContactRequest contactRequest, string url);
    }
}
