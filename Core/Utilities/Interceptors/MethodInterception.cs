using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors //12.gun
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //Interception == araya giren (Basladiginda, xta aldiginda, bitdiyinde zad [])
        //invocation == bizim metodlarimiz(add,delete zad)
        protected virtual void OnBefore(IInvocation invocation) { } //Metodun evvelinde
        protected virtual void OnAfter(IInvocation invocation) { } //Metodun sonunda
        protected virtual void OnException(IInvocation invocation, System.Exception e) { } //Hata verdiyinde, bunlar aspectdi. ValidationAspect'de isdediyimizin icini doldurub islediriy []. Meselen hata alanda logla
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
