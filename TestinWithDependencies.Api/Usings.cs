global using System;
global using System.Threading.Tasks;
global using System.Collections.Generic;
global using System.Text;
global using System.Data;
global using System.Diagnostics;

global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.OpenApi.Models;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Logging;
global using Microsoft.Data.Sqlite;
global using Microsoft.Extensions.Options;

global using TestinWithDependencies.Api.Model;
global using TestinWithDependencies.Api.Services;
global using TestinWithDependencies.Api.Data;
global using TestinWithDependencies.Api.Options;
global using TestinWithDependencies.Api.Repositories;

global using Dapper;

