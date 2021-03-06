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

      Get["/viewTheClientsForThisStylist/{id}"] = parameters => {
        Dictionary<string, object> Model = new Dictionary<string, object>();
        Stylist SelectedStylists = Stylist.Find(parameters.id);
        List<Client> StylistsClients = SelectedStylists.GetClients();
        Model.Add("stylists", SelectedStylists);
        Model.Add("clients", StylistsClients);
        return View["viewTheClientsForThisStylist.cshtml", Model];
      };

      Get["stylist/edit/{id}"] = parameters => {
        Stylist SelectedStylists = Stylist.Find(parameters.id);
        return View["stylist_edit.cshtml", SelectedStylists];
      };

      Patch["stylist/edit/{id}"] = parameters => {
        Stylist SelectedStylists = Stylist.Find(parameters.id);
        SelectedStylists.Update(Request.Form["stylist-name"]);
        return View["index.cshtml", SelectedStylists];
      };

      Get["client/edit/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        return View["client_edit.cshtml", SelectedClient];
      };

      Patch["client/edit/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        SelectedClient.Update(Request.Form["client-name"]);
        return View["index.cshtml", SelectedClient];
      };

      Get["stylist/delete/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        return View["stylist_delete.cshtml", SelectedStylist];
      };
      Delete["stylist/delete/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        SelectedStylist.Delete();
        return View["index.cshtml"];
      };

      Get["client/delete/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        return View["client_delete.cshtml", SelectedClient];
      };
      Delete["client/delete/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        SelectedClient.Delete();
        return View["index.cshtml"];
      };


    }
  }
}
