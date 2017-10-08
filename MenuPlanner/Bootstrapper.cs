using LightInject;
using MenuPlanner.Business.Services.Contracts;
using MenuPlanner.Business.Services.Implementations;
using MenuPlanner.UI.ViewModel;
using MenuPlanner.UI.Views;
using System.Windows;
using MenuPlanner.Modules;
using System.Globalization;
using System.Windows.Markup;
using MenuPlanner.UI.Managers;
using MenuPlanner.UI.Models;
using MenuPlanner.UI.ViewModel.Popups;
using AutoMapper;
using MenuPlanner.Business.BusinessObjects;
using MenuPlanner.DataAccess.EntityFramework.Domain;
using MenuPlanner.Business.Repositories;
using MenuPlanner.DataAccess.EntityFramework.Repositories;
using System;
using MenuPlanner.DataAccess.EntityFramework;
using System.Data.Entity;
using System.IO;
using MenuPlanner.Common.Popups.Managers;
using MenuPlanner.Modules.Profiles.Models;
using MenuPlanner.Modules.Profiles.ViewModels;
using MenuPlanner.Utils.Transverse;
using MenuPlanner.Utils.Helpers;

namespace MenuPlanner
{
    public class Bootstrapper : ICompositionRoot
    {
        private IServiceContainer _container;
        private IServiceRegistry _registry;

        public void Run()
        {
            Mapper.Initialize(cfg => 
                {
                    cfg.CreateMap<Meal, MealModel>();
                    cfg.CreateMap<MealModel, Meal>();
                    cfg.CreateMap<MealSchedule, MealScheduleModel>();
                    cfg.CreateMap<MealDto, Meal>();
                    cfg.CreateMap<Meal, MealDto>();
                    cfg.CreateMap<Business.BusinessObjects.Profile, ProfileModel>();
                    cfg.CreateMap<ProfileModel, Business.BusinessObjects.Profile>();

                    cfg.CreateMap<ProfileDto, Business.BusinessObjects.Profile>()
                       .ForMember(dest => dest.SelectedTimes, opt => opt.MapFrom(src => EnumUtils.ListFromMask<TimeSlot>((TimeSlot)src.SelectedTimes)));
                    cfg.CreateMap<Business.BusinessObjects.Profile, ProfileDto>()
                       .ForMember(dest => dest.SelectedTimes, opt => opt.MapFrom(src => EnumUtils.TimeSlotMaskFromList(src.SelectedTimes)));
                });

            SetDataDirectory();


            _container = new ServiceContainer();

            _container.RegisterAssembly(typeof(Bootstrapper).Assembly);

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("fr-FR");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("fr-FR");

            FrameworkElement.LanguageProperty.OverrideMetadata(
                    typeof(FrameworkElement),
                    new FrameworkPropertyMetadata(
                          XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            InitializeMainWindow();
        }

        private void SetDataDirectory()
        {
            var data = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "MenuPlanner");

            if (!Directory.Exists(data))
            {
                Directory.CreateDirectory(data);
            }

            AppDomain.CurrentDomain.SetData("DataDirectory", data);
        }

        private void InitializeMainWindow()
        {
            Application.Current.MainWindow = new MainWindow { DataContext = _container.GetInstance<MainWindowViewModel>() };
            Application.Current.MainWindow.Show();
        }

        private void RegisterMvvm()
        {
            _registry.Register<MainWindowViewModel>();
            _registry.Register<PlanningEditionViewModel>();
            _registry.Register<ProfileEditionViewModel>();
            _registry.Register<PrintingViewModel>();
            _registry.Register<IPage, PlanningViewModel>(new PerContainerLifetime());
        }

        private void RegisterServices()
        {
            _registry.Register<IProfileService, ProfileService>();
            _registry.Register<IMealService, MealService>();
            _registry.Register<ISessionService, SessionService>(new PerContainerLifetime());

            _registry.Register<IProfileRepository, EntityProfileRepository>();
            _registry.Register<IMealRepository, EntityMealRepository>();
        }

        public void Compose(IServiceRegistry serviceRegistry)
        {
            _registry = serviceRegistry;

            RegisterMvvm();
            RegisterServices();

            _registry.Register<IPaginationManager, PaginationManager>();
            _registry.Register<IPopupManager, PopupManager>(new PerContainerLifetime());

            // Module Registration
            _registry.RegisterAssembly(typeof(IModule).Assembly, (serviceType, implementingType) => serviceType == typeof(IModule));
        }
    }
}
