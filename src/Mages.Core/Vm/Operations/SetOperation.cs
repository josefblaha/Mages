﻿namespace Mages.Core.Vm.Operations
{
    using Mages.Core.Runtime;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Takes three values from the stack and pushes one.
    /// </summary>
    sealed class SetOperation : IOperation
    {
        public static readonly IOperation Instance = new SetOperation();

        private SetOperation()
        {
        }

        public void Invoke(IExecutionContext context)
        {
            var value = context.Pop();
            var obj = context.Pop() as IDictionary<String, Object>;
            var name = context.Pop() as String;

            if (obj != null && name != null)
            {
                obj.SetProperty(name, value);
            }

            context.Push(value);
        }
    }
}
