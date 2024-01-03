using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace CRUD_BASICO.Models.TableViewModels
{
    public class UserTableViewModels
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Edad { get; set; }
        public string Email { get; set; }

    }
}