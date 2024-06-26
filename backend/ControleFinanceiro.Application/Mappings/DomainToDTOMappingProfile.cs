﻿using AutoMapper;
using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Tipo, TipoDTO>().ReverseMap();
            CreateMap<Funcao, FuncaoDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Cartao, CartaoDTO>().ReverseMap();
            CreateMap<Despesa, DespesaDTO>().ReverseMap();
            CreateMap<Mes, MesDTO>().ReverseMap();
            CreateMap<Ganho, GanhoDTO>().ReverseMap();
        }
    }
}
