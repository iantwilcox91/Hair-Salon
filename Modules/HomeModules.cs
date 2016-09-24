using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace HairSalon
{
  public class Homemodule : NancyModule
  {
    public Homemodule()
    {
      Get["/"] = _ => {
        List<Stylist> AllStylists = Stylist.GetAll();
        return View["index.cshtml", AllStylists];
      };

      Get["/stylists"] = _ => {
        List<Stylist> AllStylists = Stylist.GetAll();
        return View["stylists.cshtml", AllStylists];
      };

      Get["/addAnotherStylist"] = _ => {
        List<Client> AllClients = Client.GetAll();
        return View["addAnotherStylist.cshtml", AllClients];
      };

      Get["/addNewClientToStylist"] = _ => {
        List<Client> AllClients = Client.GetAll();
        return View["addNewClientToStylist.cshtml", AllClients];
      };
    }
  }
}
