using System;
using System.Collections.Generic;

// This method is only in-memory store the reponse data
// But it does not hinder from demonstrating how ASP.NEt Core and model binding
namespace PartyInvites.Models
{
    // statisc is for ease of storing and retrieving data
    // a more sophisticalted approach should be dependency injection
    public static class Repository
    {
        private static List<GuestResponse> responses = new List<GuestResponse>();
        // Reponses is an expression-bodied member
        // Reponses is a readonly property, and it returns the private value responses
        public static IEnumerable<GuestResponse> Responses => responses;
        public static void AddResponse(GuestResponse response)
        {
            responses.Add(response);
        }
    }
}