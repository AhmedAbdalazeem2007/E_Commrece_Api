global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using System.Reflection;
global using Web_Repository.Context;
global using Web_Repository;
global using Microsoft.AspNetCore.Mvc;
global using Api_Core.Repositories;
global using Api_Core.Models;
global using Api_Core.Specifications;
global using AutoMapper;
global using Api_PL.Dtos;
global using Api_PL.Errors;
global using Api_PL.Helpers;
global using Api_PL.Extensions;
global using Microsoft.AspNetCore.Http.HttpResults;
global using Microsoft.Extensions.DependencyInjection;
global using StackExchange.Redis;
global using Web_Repository.Identity;
global using Api_Core.Models.Identity;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.Extensions.Options;
global using MimeKit;
global using System.Net;
global using System.Net.Mail;
global using Api_Core.Services;
global using Api_Sercices;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;



namespace Api_PL
{
    public class Global
    {
    }
}
