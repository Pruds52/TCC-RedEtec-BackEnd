using Microsoft.AspNetCore.Mvc;
using RedEtecAPI.VM;

namespace RedEtecAPI.Controllers
{
    public class CensuraController : Controller
    {
        public bool CensurarMensagem(string mensagem)
        {
            var censuraList = new CensuraList();

            foreach (var item in censuraList.PalavrasCensuradas)
                if (mensagem.ToLower().Contains(item))
                    return true;

            return false;
        }
    }
}
