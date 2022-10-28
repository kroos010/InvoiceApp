using FluentValidation;
using InvoiceApp.Application.MappingProfiles;
using InvoiceApp.Application.Models.Debtor;
using InvoiceApp.Application.Models.User;
using InvoiceApp.Application.Services;
using InvoiceApp.Application.Services.Contracts;
using InvoiceApp.Application.Validators.Debtor;
using InvoiceApp.Application.Validators.User;
using InvoiceApp.DataAccess.UnitOfWork;
using InvoiceApp.DataAccess.UnitOfWork.Contracts;
using InvoiceApp.Shared.Services;
using InvoiceApp.Shared.Services.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InvoiceApp.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddServices(env);

        services.RegisterAutoMapper();

        services.AddValidationServices(env);

        return services;
    }

    private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        // services.AddScoped<IWeatherForecastService, WeatherForecastService>();
        // services.AddScoped<ITodoListService, TodoListService>();
        // services.AddScoped<ITodoItemService, TodoItemService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IDebtorService, DebtorService>();
        
        services.AddScoped<IClaimService, ClaimService>();
        // services.AddScoped<ITemplateService, TemplateService>();

        // if (env.IsDevelopment())
        //     services.AddScoped<IEmailService, DevEmailService>();
        // else
        //     services.AddScoped<IEmailService, EmailService>();
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
    }

    private static void AddValidationServices(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddScoped<IValidator<CreateUserModel>, CreateUserModelValidator>();
        
        services.AddScoped<IValidator<CreateDebtorModel>, CreateDebtorModelValidator>();
        services.AddScoped<IValidator<UpdateDebtorModel>, UpdateDebtorModelValidator>();
    }

    public static void AddEmailConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        // services.AddSingleton(configuration.GetSection("SmtpSettings").Get<SmtpSettings>());
    }
}