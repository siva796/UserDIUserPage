using Carousel.DataAcess.Interfaces;
using Carousel.DataAcess.Repositories;
using System;

using Unity;
using Unity.Extension;

namespace WebApiCarousel
{
   
        public class UnityExtension : UnityContainerExtension
        {
            protected override void Initialize()
            {
                Container.RegisterType<IUserRepository, UserRepository>();

            }
        }
    
}