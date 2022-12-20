using System;

namespace Features.Core.Scripts
{
    public class ActionSubscriptionNotFound : Exception
    {
        public ActionSubscriptionNotFound() : base("Trying To Remove an Action not present on the Event Bus") { }
    }
}