﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Home
    {
        public IQueryable<Fabricante> fabricantes;
        public IQueryable<Categoria> categorias;
        public IQueryable<Produto> produtos;
    }
}