﻿using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Core.Utils.BlobStorage;
using SISGRAFH.Infraestructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Services
{
    public class PedidoService : IPedidoService
    {
        private static IUnitOfWork _unitOfWork;
        private static IFileStorage _fileStorage;


        public PedidoService(IUnitOfWork unitOfWork, IFileStorage fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<IEnumerable<object>> GetPedidos()
        {
            return await _unitOfWork.Pedido.GetPedidos(); 
        }

        public async Task<IEnumerable<object>> GetPedidosByCliente(string id)
        {
            return await _unitOfWork.Pedido.GetPedidosByCliente(id);
        }
        public async Task<IEnumerable<object>> GetTrackigPedidosByCliente(string id)
        {
            var cliente = await _unitOfWork.Cliente.GetClienteByUsuario(id);
            if(cliente is null)
            {
                return null;
            }
            return await _unitOfWork.Pedido.GetTrackigPedidosByCliente(cliente.Id);
        }

        public async Task<IEnumerable<object>> GetProductosByPedido(string id)
        {
            return await _unitOfWork.Pedido.GetProductosByPedido(id);
        }

        public async Task<bePedido> GetPedidosById(string id)
        {
            return await _unitOfWork.Pedido.GetByIdAsync(id);
        }

        public async Task<bePedido> GetPedidosById_solicitud(string id_solicitud)
        {
            return await _unitOfWork.Pedido.GetPedidosById_solicitud(id_solicitud);
        }
    }
}
