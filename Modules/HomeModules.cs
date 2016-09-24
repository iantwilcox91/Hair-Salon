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

      Get["/clients"] = _ => {
        List<Client> AllClients = Client.GetAll();
        return View["clients.cshtml", AllClients];
      };

      Get["/addAnotherStylist"] = _ => {
        List<Client> AllClients = Client.GetAll();
        return View["addAnotherStylist.cshtml", AllClients];
      };

      Get["/addNewClientToStylist"] = _ => {
        List<Stylist> AllStylists = Stylist.GetAll();
        return View["addNewClientToStylist.cshtml", AllStylists];
      };

      Post["/addedNewClientToStylist"] = _ => {
        Client newClient = new Client(Request.Form["client-name"],   Request.Form["stylist-id"]);
        newClient.Save();
        return View["addedNewClientToStylist.cshtml"];
      };

      Post["/addedNewStylist"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();
        return View["addedNewStylist.cshtml"];
      };

      Get["/deleteAllStylists"] = _ => {
        Stylist.DeleteAll();
        return View["deleteAllStylists.cshtml"];
      };

      Get["/deleteAllClients"] = _ => {
        Client.DeleteAll();
        return View["deleteAllClients.cshtml"];
      };



//this link doesnt work - breaks page
      Get["/viewTheClientsForThisStylist/{id}"] = parameters => {
        Dictionary<string, object> Model = new Dictionary<string, object>();
        var SelectedStylists = Stylist.Find(parameters.id);
        var StylistsClients = SelectedStylists.GetClients();
        Model.Add("stylists", SelectedStylists);
        Model.Add("clients", StylistsClients);
        return View["viewTheClientsForThisStylist.cshtml", Model];
      };
    }
  }
}
