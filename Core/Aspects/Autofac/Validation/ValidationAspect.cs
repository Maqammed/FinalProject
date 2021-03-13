using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    //Aspect == Metodun basinda, axirinda ve ya hata verende calisacaq yapi
    //Instance == Ornek
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir dogrulama sinifi deyil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation) //OnBEfore yeniki oncesinde isle, bu aspectdir. diger MethodInterception'de olan aspect'leride ezip islede bilersen
                                                                 //basa dusmedinse https://youtu.be/zdpPm7Q6YE0 arxaya sar
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
