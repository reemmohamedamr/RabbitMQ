﻿using MicroRabbit.MVC.Models.DTO;
using Newtonsoft.Json;

namespace MicroRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;
        public TransferService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task Transfer(TransferDTO transferDTO)
        {
            var uri = "https://localhost:44322/api/Banking";
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDTO),System.Text.Encoding.UTF8
                ,"application/json");
            var response=await _apiClient.PostAsync(uri,transferContent);
            response.EnsureSuccessStatusCode();

        }
    }
}
